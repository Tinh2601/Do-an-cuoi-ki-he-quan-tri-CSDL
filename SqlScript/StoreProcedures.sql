use QuanLyNhanVien
go
--------NHÂN VIÊN----------
--Thủ tục thêm nhân viên
create proc spInsertNhanVien
@MaNV int, @Hoten varchar(50), @GioiTinh varchar(4), @NgSinh date, 
@QueQuan varchar(50), @SoDT char(10), @MaCV char(10), @MaPB char(10), 
@LuongCB int, @Password char(10)
as
begin
	insert into NhanVien values(@MaNV, @Hoten, @GioiTinh, @NgSinh, @QueQuan, @SoDT, @MaCV, @MaPB, @LuongCB, @Password)
end
go
--Thủ tục cập nhật nhân viên
create proc spUpdateNhanVien
@MaNV int, @Hoten varchar(50), @GioiTinh varchar(4), @NgSinh date, 
@QueQuan varchar(50), @SoDT char(10), @MaCV char(10), @MaPB char(10), 
@LuongCB int, @Password char(10)
as
begin
	update NhanVien set HoTen = @Hoten, GioiTinh = @GioiTinh, NgaySinh = @NgSinh, QueQuan = @QueQuan, 
		SoDT = @SoDT, MaCV = @MaCV, MaPB = @MaPB, LuongCB = @LuongCB, Password = @Password
		where MaNV = @MaNV
end
go
-- thủ tục lấy danh sách nhân viên
create proc spLayDSNhanVien
as
begin
	select * from NhanVien
end
go
--Thủ tục xóa nhân viên
create proc spDeleteNhanVien
@MaNV int
as
begin
	delete from NhanVien where MaNV = @MaNV
end
go
------CHỨC VỤ---------
-- Thủ tục thêm chức vụ
create proc spInsertChucvu
@MaCV char(10),@TenChucVu nvarchar(50),@PhuCapCV int
as
begin
	
	insert into ChucVu values(@MaCV ,@TenChucVu,@PhuCapCV)
end
go
-- Thủ tục gọi view danh sách chức vụ
create proc spLayDSChucVu
as
begin
	select * from Chucvu_View
end
go
-- hàm sửa chức vụ
create procedure spUpdateChucvu
	@MaCV char(10),@TenChucVu nvarchar(50),@PhuCapCV int
as
begin
	update ChucVu
	set
		TenChucVu = @TenChucVu,
		PhuCapCV = @PhuCapCV
	where MaCV = @MaCV
end 
go
--- hàm xóa chưc vụ 
create proc spDeleteChucvu
@MaCV char(10)
as
begin
	delete from ChucVu where MaCV = @MaCV
end
go
-------DỰ ÁN----------
--Thủ tục lấy danh sách dự án
create proc spLayDSDuAn
as
begin
	select * from DuAn
end
go
-- Thủ tục Insert dự án
create proc spInsertDuAn
@MaDA CHAR(10), @TenDA VARCHAR(50), @NgayBD DATE, @NgayKT DATE, @DoanhThu int, @TinhTrang Varchar(50), @MaPB char(10)
as
begin
	insert into DuAn values(@MaDA, @TenDA, @NgayBD, @NgayKT, @DoanhThu, @TinhTrang, @MaPB)
end
go
-- Thủ tục update dự án
create proc spUpdateDuAn
@MaDA CHAR(10), @TenDA VARCHAR(50), @NgayBD DATE, @NgayKT DATE, @DoanhThu int, @TinhTrang Varchar(50), @MaPB char(10)
as
begin
	update DuAn set TenDA = @TenDA, NgayBD = @NgayBD, NgayKT = @NgayKT, DoanhThu = @DoanhThu, TinhTrang = @TinhTrang, MaPB = @MaPB
		where MaDA = @MaDA
end
go
-- Thủ tục delete dự án
create proc spDeleteDuAn
@MaDA char(10)
as
begin
	delete from DuAn where MaDA = @MaDA
end
go
---Thủ tục gọi View bảng lương nhân viên
create proc spLayBangLuong
as
	select* from SalaryCount_View
go
-------PHÒNG BAN--------
---Thủ tục lấy danh sách phòng ban
create proc spLayDSPhongBan
as
begin
	select * from PhongBan
end
go
-- Thủ tục Insert phòng ban
create proc spInsertPhongBan
@MaPB char(10), @TenPB varchar(50), @DiaChi varchar(50), @TrPhong int
as
begin
	insert into PhongBan values(@MaPB, @TenPB, @DiaChi, @TrPhong)
end
go
-- Thủ tục Update Phòng ban
create proc spUpdatePhongBan
@MaPB char(10), @TenPB varchar(50), @DiaChi varchar(50), @TrPhong int
as
begin
	update PhongBan set TenPB = @TenPB, DiaChi = @DiaChi, TrPhong = @TrPhong
		where MaPB = @MaPB
end
go
-- Thủ tục delete Phòng ban
create proc spDeletePhongBan
@MaPB char(10)
as
begin
	delete from PhongBan where MaPB = @MaPB
end
go
--------
-- Thủ tục lấy danh sách bảng chấm công
create proc spLayDSChamCong
as
	select * from ChamCong
go
-- Thủ tục Insert chấm công
create proc spInsertChamCong
@MaNV int, @Thang int, @Nam int, @SoNgayDiLam int
as
begin
	insert into ChamCong values(@MaNV, @Thang, @Nam, @SoNgayDiLam)
end
go
-- Thủ tục Update chấm công
create proc spUpdateChamCong
@MaNV int, @Thang int, @Nam int, @SoNgayDiLam int
as
begin
	Update ChamCong set SoNgayDiLam = @SoNgayDiLam
	where MaNV = @MaNV and Thang = @Thang and Nam = @Nam
end
go
---- Thủ tục Delete chấm công
create proc spDeleteChamCong
@MaNV int, @Thang int, @Nam int
as
	delete from ChamCong where MaNV = @MaNV and Thang = @Thang and Nam = @Nam
go
----Tham gia dự án-----------
---- Lấy danh sách tham gia dự án và tên dự án
create proc spLayDSThamGiaDA
@MaNV int
as
	select tgda.MaDA, TenDA, NgayThamGia, PhuCap, MaNV from ThamGiaDA tgda, DuAn da where tgda.MaDA = da.MaDA and MaNV = @MaNV
go
create proc spInsertThamGiaDA
@MaDA char(10), @MaNV int, @NgayThamGia date, @PhuCap int
as
begin
	insert into ThamGiaDA values(@MaDA, @MaNV, @NgayThamGia, @PhuCap)
end
go
-- Thủ tục delete nhân viên khỏi dự án
create proc spDeleteThamGiaDA
@MaDA char(10), @MaNV int
as
begin
	delete from ThamGiaDA where MaDA = @MaDA and MaNV = @MaNV
end
go
---- Thủ tục lấy danh sách nhân viên tham gia dự án đó
create proc spDSNhanVienCuaDA
@MaDA char(10)
as
begin
	select tgda.MaNV, nv.HoTen, tgda.NgayThamGia, tgda.PhuCap from ThamGiaDA tgda, NhanVien nv
	where tgda.MaNV = nv.MaNV and MaDA = @MaDA
end
go
---- Thủ tục lấy danh sách nhân viên còn lại không tham gia vào dự án đó
create proc spDSNhanVienKhongCoTrongDuAn
@MaDA char(10)
as
begin
	select nv.MaNV, nv.HoTen from NhanVien nv left join (select * From ThamGiaDA where MaDA = @MaDA) tgda on nv.MaNV = tgda.MaNV
	where tgda.MaNV is null
end
go
-----------HỢP ĐỒNG------------
---- Thủ tục lấy danh sách hợp đồng
create proc spLayDSHopDong
as
	select * from HDLaoDong
go
---- Thủ tục Insert hợp đồng
create proc spInsertHopDong
@MaHD char(10), @LoaiHD varchar(50), @NgayBD date, @MaNV int
as
begin
	Insert into HDLaoDong values(@MaHD, @LoaiHD, @NgayBD, @MaNV);
end
go
---- Thủ tục update hợp đồng
create proc spUpdateHopDong
@MaHD char(10), @LoaiHD varchar(50), @NgayBD date, @MaNV int
as
begin
	update HDLaoDong set LoaiHD = @LoaiHD, NgayBD = @NgayBD
	where MaHD = @MaHD and MaNV = @MaNV
end
go
---- Thủ tục delete hợp đồng
create proc spDeleteHopDong
@MaNV int
as
begin
	delete from HDLaoDong where MaNV = @MaNV
end
go
---- Kiểm tra tài khoản đăng nhập
create proc spAccountCheck(
@maNV int,
@pass char(30)
)
as
begin 
	select * from Account where  maNV = @maNV and pass = @pass
end
go 
---- Thủ tục đổi mật khẩu tài khoản đăng nhập
create proc spChangePassword
@MaNV int,
@NewPassword char(30)
as
begin
	update Account set pass = @NewPassword where maNV = @MaNV
end
go
-- Thủ tục lấy danh sách tài khoản
create procedure spLayDSTaiKhoan
as
	select * from Account
go
-- Thủ tục chỉnh sửa mật khẩu và quyền của tài khoản
create procedure spUpdateTaiKhoan
	@maNV int, @Pass char(30), @Quyen int
as
begin
	update Account
	set
		Quyen = @Quyen,
		pass = @Pass
	where maNV = @maNV
end 
go