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