create database QuanLyNhanVien
go
use QuanLyNhanVien
go
--nhân viên
create table NhanVien
(
	MaNV int primary key ,
	HoTen varchar(50) not null,
	GioiTinh varchar(4) not null,
	NgaySinh date,
	QueQuan varchar(50),
	SoDT char(10),
	MaCV char(10),
	MaPB char(10),
	LuongCB int,
	password char(30) not null
)
go
--chức vụ
create table ChucVu
(
	MaCV char(10) primary key,
	TenChucVu varchar(50) not null,
	PhuCapCV int
)
go

--phòng ban
create table PhongBan
(
	MaPB char(10) primary key,
	TenPB varchar(50),
	DiaChi varchar(50),
	TrPhong int NULL,
)
go
create table DuAn
(
	MaDA char(10) primary key,
	TenDA varchar(50),
	NgayBD date,
	NgayKT date,
	DoanhThu int,
	TinhTrang varchar(50),
	MaPB char(10)
)
go
--tham gia dự án
create table ThamGiaDA
(
	MaDA char(10),
	MaNV  int,
	NgayThamGia date not null,
	PhuCap int not null,
	primary key(MaDA,MaNV)
)
go
--hợp đồng lao động
create table HDLaoDong
(
	MaHD char(10) primary key,
	LoaiHD varchar(50),
	NgayBD date,
	MaNV int
)
go

--thân nhân
create table ThanNhan
(
	MaTN char(10) ,
	MaNV int,
	HoTen varchar(50) not null,
	GioiTinh varchar(10),
	NgaySinh date,
	QuanHe varchar(50),
	
	primary key (MaTN,MaNV)
)

go
--bảng Chấm công nhân viên
create table ChamCong
(
	MaNV int,
	Thang int CHECK(Thang > 0 AND Thang<13),
	Nam int CHECK(Nam > 0),
	SoNgayDiLam int,
	primary key(MaNV, Thang, Nam)
)
go
-- Bảng tài khoản đăng nhập
create table Account (
	maNV int,
	pass char(30) not null,
	Quyen int , -- 0: Nhân Viên; 1: Quản lý
	primary key(maNV)
)
go 
---- Ràng Buộc
--KHÓA NGOẠI
-- NhanVien
alter table NhanVien add foreign key(MaCV) references ChucVu(MaCV);
go
alter table NhanVien add foreign key(MaPB) references PhongBan(MaPB);
go
--PhongBan
alter table PhongBan add foreign key(TrPhong) references NhanVien(MaNV);
go
-- Du an
alter table DuAn add foreign key (MaPB) references PhongBan(MaPB);
go
--ThamGiaDA
alter table ThamGiaDA add foreign key(MaNV) references NhanVien(MaNV);
go
alter table ThamGiaDA add foreign key(MaDA) references DuAn(MaDA);
go
--HDLaoDong
alter table HDLaoDong add foreign key(MaNV) references NhanVien(MaNV);
go
--ThanNhan
alter table ThanNhan add foreign key(MaNV) references NhanVien(MaNV);
go
--Cham Cong
alter table ChamCong add foreign key(MaNV) references NhanVien(MaNV);
-- Ràng buộc khác
-- Trong mỗi dự án, ngày bắt đầu phải nhỏ hơn ngày kết thúc
alter table DuAn add constraint TimeProject check (NgayBD < NgayKT)
go
-- Số ngày đi làm của nhân viên trong tháng phải dưới 27
alter table ChamCong add constraint DayWorkCount check(SoNgayDiLam < 27)
go
-- Tuổi của mỗi nhân viên phải trên 18 và dưới 65
alter table NhanVien add constraint ageConstraint check((YEAR(GETDATE()) - Year(NgaySinh)) > 18 AND (YEAR(GETDATE()) - Year(NgaySinh)) < 65)
go
/*
alter table NhanVien add constraint SalaryManager check(NhanVien.LuongCB < (--Trưởng phòng của nhân viên đó trong phòng ban)) 
go
*/
--------PHÂN QUYỀN USER--------------
--Tạo ROLE
Create Role Administrator AUTHORIZATION db_owner
go

Create Role Employee
go
---------TRIGGER---------
create TRIGGER trgigger_DuAn ON DuAn 
FOR INSERT AS
DECLARE @ngayBD date, @ngayKT date                                  
SELECT @ngayBD = DA_in.NgayBD, @ngayKT = DA_in.NgayKT
FROM inserted DA_in
if(@ngayBD > @ngayKT)
BEGIN
	print('Ngay bat dau phai nho hon ngay ket thuc')
	Rollback;
end
go
create trigger trigger_workingday on dbo.ChamCong
FOR INSERT as
begin
	declare @dilam int 
	select @dilam = Luong.SoNgayDiLam from inserted Luong
	if(@dilam > 27) 
	BEGIN
		print'So ngay di lam phai nho hon 27';
	END
end
go
create trigger trigger_invalidBirthDay on dbo.NhanVien
for INSERT as
begin
	declare @NgaySinh date 
	select @NgaySinh = NhanVien.NgaySinh from inserted NhanVien
	if((YEAR(GETDATE()) - Year(@NgaySinh)) < 18 OR (YEAR(GETDATE()) - Year(@NgaySinh)) > 65) 
	BEGIN
		print'So tuoi phai lon hon 18 va nho hon 65';
		rollback;
	END
end
go
--trigger tạo tài khoản và login user tự động khi thêm mới 1 nhân viên
create trigger trigger_AutoCreateAccountAndLogin on dbo.NhanVien
after INSERT as
begin
	declare @MaNV int, @pass char(30), @quyen int, @MaCV char(10), @userName char(30)
	select @MaNV = ins.MaNV, @pass = ins.Password, @MaCV = ins.MaCV from inserted ins
	set @userName = 'User' + cast(@MaNV as char)
	if(@MaCV = 'CV07')
	begin
		set @quyen = 1
		Exec('Create Login ' + @userName + 'With password = ''123'' '+',Default_Database = QuanLyNhanVien' + ',Default_Language = [us_english]' + ',Check_expiration = off' + ',Check_Policy = off')
		Exec('Create User ' + @userName + 'For Login ' + @userName)
		Exec sp_addrolemember Administrator, @userName
	end
	else
	begin
		set @quyen = 0
		Exec('Create Login ' + @userName + 'With password = ''123'' '+',Default_Database = QuanLyNhanVien' + ',Default_Language = [us_english]' + ',Check_expiration = off' + ',Check_Policy = off')
		Exec('Create User ' + @userName + 'For Login ' + @userName)
		Exec sp_addrolemember Employee, @userName
	end
	insert into Account values(@MaNV, @pass, @quyen);
end
go
-- Trigger xóa tài khoản và login user tự động khi xóa 1 nhân viên
create trigger trigger_AutoDeleteAccountAndLogin on dbo.NhanVien
for delete as
begin
	declare @MaNV int, @userName char(30)
	select @MaNV = del.MaNV from deleted del
	set @userName = 'User' + cast(@MaNV as char)

	Exec('Drop login '+ @userName)
	Exec('Drop user '+ @userName)

	delete from Account where maNV = @MaNV
end
go
-- Trigger cập nhật dữ liệu bảng nhân viên khi mật khẩu thay đổi
create trigger trigger_UpdateNhanVienPassword on dbo.Account
after update as
begin
	declare @MaNV int, @Password char(30)
	select @MaNV = ins.maNV, @Password = ins.pass from inserted ins

	update NhanVien set password = @Password where MaNV = @MaNV
end
go
-------------------------------------
----VIEWS-----
-- Một view có tên phòng ban,  tên người quản lý và lương của người quản lý của mọi phòng ban.
create view DeptManagerSalary_View as 
select pb.MaPB, nv.HoTen, nv.LuongCB 
from NhanVien nv, PhongBan pb 
where nv.MaNV = pb.TrPhong;
go
-- Một view có mã dự án, tên dự án, tình trạng dự án, số lượng nhân viên tham gia vào dự án
create view ProjectStatus_View as
select da.MaDA, da.TenDA, da.tinhTrang, count(tgda.MaNV) as SLNVThamGia from THAMGIADA tgda, DuAn da where tgda.MaDA = da.MaDA
group by da.MaDA, da.TenDA, da.TinhTrang
go
-- View để xem chức vụ
create view Chucvu_View as
select chucvu.MaCV, chucvu.TenChucVu, chucvu.PhuCapCV
from ChucVu chucvu;
go
-----View bảng lương nhân viên
create view SalaryCount_View
as
select cc.MaNV, Thang, Nam, SoNgayDiLam, nv.LuongCB, (tgda.PhuCap + cv.PhuCapCV) as TongPhuCap, (cc.SoNgayDiLam*nv.LuongCB+cv.PhuCapCV) as TongLuong
from ChamCong cc, NhanVien nv, ChucVu cv, ThamGiaDA tgda
where cc.MaNV = nv.MaNV and nv.MaCV = cv.MaCV and cc.MaNV = tgda.MaNV
go
--STORE PROCEDURE & FUNCTION--
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
-- Thủ tục chỉnh sửa QuanLiTaiKhoan cap quyen
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
-------------------------FUNCTION--------------------
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
--- Gán QUYỀN-----
-- Gán quyền cho role Administrator
grant execute to Administrator with grant option
grant select, insert, delete, update to Administrator With Grant Option
--Gán quyền cho ROLE Employee
Grant Update on dbo.Account to Employee
Grant Select,Update on dbo.NhanVien to Employee
Grant Select on dbo.DuAn to Employee
Grant Select on dbo.ThamGiaDA to Employee
Grant Select on dbo.HDLaoDong to Employee
Grant Execute on spLayDSNhanVien to Employee
Grant Execute on spLayDSHopDong to Employee
Grant Execute on spLayDSThamGiaDA to Employee
Grant execute on spAccountCheck to Employee
Grant execute on spChangePassword to Employee
go
--------INSERT DỮ LIỆU VÀO CÁC BẢNG------------
--- Phòng ban
INSERT INTO PhongBan VALUES('PB01', 'Kinh Doanh', 'Tang 3 toa nha A', null);
INSERT INTO PhongBan VALUES('PB02', 'Tai Chinh', 'Tang 1 toa nha B', null);
INSERT INTO PhongBan VALUES('PB03', 'Thiet Ke', 'Tang 2 toa nha A', null);
INSERT INTO PhongBan VALUES('PB04', 'Truyen Thong', 'Tang 1 toa nha B', null);
INSERT INTO PhongBan VALUES('PB05', 'Media', 'Tang 3 toa nha A', null);
INSERT INTO PhongBan VALUES('PB06', 'Hau can', 'Tang 2 toa nha B', null);
go
--- Chức vụ
INSERT INTO ChucVu VALUES('CV01', 'Nhan vien kinh doanh',200)
INSERT INTO ChucVu VALUES('CV02', 'Nhan vien thiet ke',400)
INSERT INTO ChucVu VALUES('CV03', 'Photographer',100)
INSERT INTO ChucVu VALUES('CV04', 'Ke toan',0)
INSERT INTO ChucVu VALUES('CV05', 'Nhan vien noi dung',300)
INSERT INTO ChucVu VALUES('CV06', 'Nhan vien doi ngoai',500)
INSERT INTO ChucVu VALUES('CV07', 'Nhan vien quan ly',150)
go
--- Nhân viên
INSERT INTO NhanVien VALUES(101, 'Nguyen Duc chung', 'Nam', '1990-8-12', 'DongNai', '0334445632', 'CV01', 'PB01', 10000, 'chungnd');
INSERT INTO NhanVien VALUES(102, 'Pham Van Luong', 'Nam', '1991-05-05', 'Long An', '0342456614', 'CV02', 'PB04', 15000, 'luongpv');
INSERT INTO NhanVien VALUES(103, 'Tran Ngoc My', 'Nu', '1996-4-13', 'Dong Nai', '0134445647', 'CV03', 'PB03', 8000, 'mytn');
INSERT INTO NhanVien VALUES(104, 'Nguyen Anh Thu', 'Nu', '1993-6-28', 'Dong Nai', '0434445682', 'CV04', 'PB02', 90000, 'thuna');
INSERT INTO NhanVien VALUES(105, 'Ngo Quang Dieu', 'Nam', '1991-3-27', 'Thanh Pho Ho Chi Minh', '0334445644', 'CV05', 'PB01', 17000, 'dieunq');
INSERT INTO NhanVien VALUES(106, 'Trinh Hoai Duc', 'Nam', '1992-8-25', 'Tien Giang', '0334445633', 'CV06', 'PB06', 6000, 'ducth');
INSERT INTO NhanVien VALUES(107, 'Phan Ngoc Han', 'Nu', '1995-7-17', 'Vinh Long', '036645625', 'CV04', 'PB06', 30000, 'hanpn');
INSERT INTO NhanVien VALUES(108, 'Le Hai', 'Nam', '1994-5-16', 'Quang Ngai', '0323445663', 'CV02', 'PB01', 20000, 'hail');
INSERT INTO NhanVien VALUES(109, 'Nguyen Ngoc Han', 'Nu', '1991-4-22', 'Binh Thuan', '0385445682', 'CV03', 'PB05', 19000, 'hannn');
INSERT INTO NhanVien VALUES(110, 'Tran Chung Kien', 'Nam', '1990-3-11', 'Thanh Pho Ho Chi Minh', '0338745629', 'CV07', 'PB06', 25000, 'kientc');
INSERT INTO NhanVien VALUES(111, 'Nguyen Quoc Bao', 'Nam', '1992-3-9', 'Dong Nai', '0337845644', 'CV01', 'PB06', 10000, 'baonq');
Go

UPDATE PhongBan SET TrPhong = 101 where MaPB = 'PB01'
UPDATE PhongBan SET TrPhong = 103 where MaPB = 'PB02'
UPDATE PhongBan SET TrPhong = 105 where MaPB = 'PB03'
UPDATE PhongBan SET TrPhong = 108 where MaPB = 'PB04'
UPDATE PhongBan SET TrPhong = 110 where MaPB = 'PB05'
UPDATE PhongBan SET TrPhong = 111 where MaPB = 'PB06'
Go

INSERT INTO DuAn VALUES('DA01', 'TenDuAn', '2018-8-12', '2019-6-12', 10000, '70%', 'PB01')
INSERT INTO DuAn VALUES('DA02', 'TenDuAn', '2018-8-12', '2019-6-12', 80000, '45%', 'PB02')
INSERT INTO DuAn VALUES('DA03', 'TenDuAn', '2018-8-12', '2019-6-12', 40000, '60%', 'PB03')
INSERT INTO DuAn VALUES('DA04', 'TenDuAn', '2018-8-12', '2019-6-12', 60000, '75%', 'PB04')
INSERT INTO DuAn VALUES('DA05', 'TenDuAn', '2018-8-12', '2019-6-12', 45000, '100%', 'PB02')
INSERT INTO DuAn VALUES('DA06', 'TenDuAn', '2018-8-12', '2019-6-12', 33000, '30%', 'PB05')
INSERT INTO DuAn VALUES('DA07', 'TenDuAn', '2018-8-12', '2019-6-12', 62000, '10%', 'PB06')
GO

INSERT INTO HDLaoDong VALUES('HD01', 'LoaiHD', '2018-03-04', 101)
INSERT INTO HDLaoDong VALUES('HD02', 'LoaiHD', '2018-02-06', 102)
INSERT INTO HDLaoDong VALUES('HD03', 'LoaiHD', '2018-05-03', 103)
INSERT INTO HDLaoDong VALUES('HD04', 'LoaiHD', '2018-03-14', 104)
INSERT INTO HDLaoDong VALUES('HD05', 'LoaiHD', '2018-08-02', 105)
INSERT INTO HDLaoDong VALUES('HD06', 'LoaiHD', '2018-07-15', 106)
INSERT INTO HDLaoDong VALUES('HD07', 'LoaiHD', '2018-03-30', 107)
INSERT INTO HDLaoDong VALUES('HD08', 'LoaiHD', '2018-02-27', 108)
INSERT INTO HDLaoDong VALUES('HD09', 'LoaiHD', '2018-10-24', 109)
INSERT INTO HDLaoDong VALUES('HD10', 'LoaiHD', '2018-11-16', 110)
INSERT INTO HDLaoDong VALUES('HD11', 'LoaiHD', '2018-07-23', 111)
GO
--Chấm công
INSERT INTO ChamCong VALUES(101, 1, 2022, 26)
INSERT INTO ChamCong VALUES(102, 1, 2022, 25)
INSERT INTO ChamCong VALUES(103, 1, 2022, 24)
INSERT INTO ChamCong VALUES(104, 1, 2022, 25)
INSERT INTO ChamCong VALUES(105, 1, 2022, 26)
INSERT INTO ChamCong VALUES(106, 1, 2022, 25)
INSERT INTO ChamCong VALUES(107, 1, 2022, 26)
INSERT INTO ChamCong VALUES(108, 1, 2022, 25)
INSERT INTO ChamCong VALUES(109, 1, 2022, 25)
INSERT INTO ChamCong VALUES(110, 1, 2022, 26)
INSERT INTO ChamCong VALUES(111, 1, 2022, 25)
INSERT INTO ChamCong VALUES(101, 2, 2022, 26)
INSERT INTO ChamCong VALUES(102, 2, 2022, 25)
INSERT INTO ChamCong VALUES(103, 2, 2022, 25)
INSERT INTO ChamCong VALUES(104, 2, 2022, 26)
INSERT INTO ChamCong VALUES(105, 2, 2022, 26)
INSERT INTO ChamCong VALUES(106, 2, 2022, 25)
INSERT INTO ChamCong VALUES(107, 2, 2022, 23)
INSERT INTO ChamCong VALUES(108, 2, 2022, 23)
INSERT INTO ChamCong VALUES(109, 2, 2022, 24)
INSERT INTO ChamCong VALUES(110, 2, 2022, 25)
INSERT INTO ChamCong VALUES(111, 2, 2022, 26)
GO
--Tham gia dự án--
INSERT INTO ThamGiaDA VALUES('DA01', 101, '8/12/2018', 300)
INSERT INTO ThamGiaDA VALUES('DA02', 102, '8/12/2018', 200)
INSERT INTO ThamGiaDA VALUES('DA03', 103, '8/12/2018', 100)
INSERT INTO ThamGiaDA VALUES('DA04', 104, '8/12/2018', 150)
INSERT INTO ThamGiaDA VALUES('DA05', 105, '8/12/2018', 350)
INSERT INTO ThamGiaDA VALUES('DA06', 106, '8/12/2018', 250)
INSERT INTO ThamGiaDA VALUES('DA07', 107, '8/12/2018', 250)
INSERT INTO ThamGiaDA VALUES('DA01', 108, '8/12/2018', 300)
INSERT INTO ThamGiaDA VALUES('DA02', 109, '8/12/2018', 150)
INSERT INTO ThamGiaDA VALUES('DA03', 110, '8/12/2018', 200)
INSERT INTO ThamGiaDA VALUES('DA04', 111, '8/12/2018', 250)
GO