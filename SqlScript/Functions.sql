use QuanLyNhanVien
go
--Hàm tìm kiếm nhân viên
create FUNCTION SearchNhanVien(@SearchInfo varchar(100),
@SearchProperties varchar(100))
RETURNS @tbl TABLE
(
    MaNV varchar(100),
	HoTen VARCHAR(50),
    GioiTinh VARCHAR(4),
	NgaySinh date,
	QueQuan varchar(50),
	SoDT char(10),
	MaCV char(10),
	MaPB char(10),
	LuongCB int,
	Password char(10)
)
AS
begin
    IF  (@SearchProperties = 'MaNV')
		insert into @tbl SELECT * FROM NhanVien WHERE MaNV like @SearchInfo+'%'
    ELSE IF (@SearchProperties = 'HoTen')
		insert into @tbl SELECT * FROM NhanVien WHERE HoTen like @SearchInfo+'%'
    ELSE IF (@SearchProperties = 'SoDT')
		insert into @tbl SELECT * FROM NhanVien WHERE SoDT like @SearchInfo+'%'
	return
end
go