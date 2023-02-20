use QuanLyNhanVien
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
---Phân quyền cho 1 nhân viên làm admin
Update Account set Quyen = 1 where maNV = 110
go