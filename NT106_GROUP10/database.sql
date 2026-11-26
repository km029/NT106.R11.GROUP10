CREATE DATABASE NT106_GROUP10_DB;
GO

USE NT106_GROUP10_DB;
GO

CREATE TABLE Users
(
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Email NVARCHAR(255) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);
GO

-- code sql thêm bảng phục vụ cho tìm kiếm và kết bạn

-- TẠO BẢNG FRIENDSHIPS LƯU QUAN HỆ KẾT BẠN GIỮA 2 NGƯỜI DÙNG

CREATE TABLE IF NOT EXISTS public.friendships (
    -- Khóa chính tự động sinh chuỗi UUID ngẫu nhiên cho mỗi dòng quan hệ
    id uuid PRIMARY KEY DEFAULT gen_random_uuid(),

    -- ID của người chủ động gửi lời mời kết bạn (liên kết tới bảng profiles; xóa user thì tự xóa dòng này)
    requester_id uuid NOT NULL REFERENCES public.profiles(id) ON DELETE CASCADE,

    -- ID của người nhận lời mời kết bạn (liên kết tới bảng profiles)
    addressee_id uuid NOT NULL REFERENCES public.profiles(id) ON DELETE CASCADE,

    -- Trạng thái quan hệ: chỉ cho phép nhận 1 trong 2 giá trị 'pending' (chờ duyệt) hoặc 'accepted' (đã là bạn)
    status text NOT NULL DEFAULT 'pending' CHECK (status IN ('pending', 'accepted')),

    -- Thời điểm gửi lời mời và thời điểm cập nhật trạng thái gần nhất
    created_at timestamptz NOT NULL DEFAULT now(),
    updated_at timestamptz NOT NULL DEFAULT now(),

    -- Ràng buộc logic: cấm một người tự gửi lời mời kết bạn cho chính mình
    CONSTRAINT friendships_no_self CHECK (requester_id <> addressee_id)
);

-- Tạo chỉ mục duy nhất (Unique Index) chống tạo trùng quan hệ 2 chiều:
-- Hàm LEAST/GREATEST sắp xếp cặp ID theo thứ tự cố định, đảm bảo A->B và B->A chỉ tồn tại tối đa 1 dòng
CREATE UNIQUE INDEX IF NOT EXISTS idx_friendships_unique_pair
ON public.friendships (LEAST(requester_id, addressee_id), GREATEST(requester_id, addressee_id));



-- BẬT BẢO MẬT ROW LEVEL SECURITY (RLS) & PHÂN QUYỀN TRUY CẬP BẢNG

ALTER TABLE public.friendships ENABLE ROW LEVEL SECURITY;

-- Quyền XEM (SELECT): Chỉ cho phép xem những dòng quan hệ mà mình là người gửi hoặc người nhận
DROP POLICY IF EXISTS "Users can view their own friendships" ON public.friendships;
CREATE POLICY "Users can view their own friendships"
ON public.friendships FOR SELECT
TO authenticated
USING (auth.uid() = requester_id OR auth.uid() = addressee_id);

-- Quyền THÊM (INSERT): Chỉ cho phép tạo lời mời khi người gửi (requester_id) chính là tài khoản đang đăng nhập
DROP POLICY IF EXISTS "Users can send friend requests" ON public.friendships;
CREATE POLICY "Users can send friend requests"
ON public.friendships FOR INSERT
TO authenticated
WITH CHECK (auth.uid() = requester_id);

-- Quyền SỬA (UPDATE): Chỉ cho phép người trong cuộc cập nhật trạng thái (ví dụ: người nhận bấm Chấp nhận)
DROP POLICY IF EXISTS "Users can update their friendships" ON public.friendships;
CREATE POLICY "Users can update their friendships"
ON public.friendships FOR UPDATE
TO authenticated
USING (auth.uid() = requester_id OR auth.uid() = addressee_id);

-- Quyền XÓA (DELETE): Chỉ cho phép người trong cuộc xóa dòng quan hệ (hủy lời mời, từ chối hoặc hủy kết bạn)
DROP POLICY IF EXISTS "Users can delete their friendships" ON public.friendships;
CREATE POLICY "Users can delete their friendships"
ON public.friendships FOR DELETE
TO authenticated
USING (auth.uid() = requester_id OR auth.uid() = addressee_id);


--HÀM RPC SEARCH_USERS TÌM KIẾM NGƯỜI DÙNG KÈM TRẠNG THÁI KẾT BẠN
CREATE OR REPLACE FUNCTION public.search_users(p_keyword text)
-- Định nghĩa cấu trúc bảng dữ liệu trả về khớp với các thuộc tính của class UserSearchResult trong C#
RETURNS TABLE (
    id uuid,
    username text,
    display_name text,
    avatar_url text,
    bio text,
    status text,
    friendship_id uuid,
    friend_status text
)
LANGUAGE plpgsql
SECURITY DEFINER -- Chạy hàm với quyền chủ sở hữu database để đọc được thông tin cơ bản từ bảng profiles
SET search_path = public
AS $$
DECLARE
    -- Lấy ID của người dùng đang đăng nhập từ JWT Token gửi kèm trong Header Authorization
    v_current_user uuid := auth.uid();
BEGIN
    RETURN QUERY
    SELECT
        u.id,
        u.username,
        u.display_name,
        u.avatar_url,
        u.bio,
        u.status,
        f.id AS friendship_id, -- Trả về mã dòng quan hệ (nếu chưa kết bạn sẽ là NULL)

        -- Phân loại trạng thái quan hệ giữa người đang tìm kiếm và từng người dùng tìm được
        CASE
            WHEN f.id IS NULL THEN 'none' -- Chưa có quan hệ -> C# hiện nút "Kết bạn"
            WHEN f.status = 'accepted' THEN 'accepted' -- Đã đồng ý -> C# hiện nút "Bạn bè"
            WHEN f.status = 'pending' AND f.requester_id = v_current_user THEN 'pending_sent' -- Mình là người gửi -> hiện "Đã gửi lời mời"
            WHEN f.status = 'pending' AND f.addressee_id = v_current_user THEN 'pending_received' -- Mình là người nhận -> hiện "Chấp nhận"
            ELSE 'none'
        END AS friend_status
    FROM public.profiles u
    -- LEFT JOIN với bảng friendships theo cả 2 chiều gửi/nhận để không bỏ sót người chưa kết bạn
    LEFT JOIN public.friendships f
        ON (f.requester_id = v_current_user AND f.addressee_id = u.id)
        OR (f.addressee_id = v_current_user AND f.requester_id = u.id)
    WHERE
        -- Loại bỏ chính tài khoản của người đang gõ tìm kiếm ra khỏi danh sách kết quả
        u.id <> v_current_user
        AND (
            -- Tìm không phân biệt chữ hoa/thường theo username hoặc tên hiển thị
            u.username ILIKE '%' || trim(p_keyword) || '%'
            OR COALESCE(u.display_name, '') ILIKE '%' || trim(p_keyword) || '%'
        )
    -- Sắp xếp kết quả theo thứ tự bảng chữ cái của username và giới hạn tối đa 20 người/lần tìm
    ORDER BY u.username ASC
    LIMIT 20;
END;
$$;

-- Cấp quyền thực thi hàm search_users cho các tài khoản đã đăng nhập 
GRANT EXECUTE ON FUNCTION public.search_users(text) TO authenticated;

-- Yêu cầu PostgREST làm mới bộ nhớ đệm Schema để nhận diện ngay hàm RPC mới tạo mà không bị lỗi 404
NOTIFY pgrst, 'reload schema';