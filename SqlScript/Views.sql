use QuanLyNhanVien
go
----VIEWS-----
-- Một view có tên phòng ban,  tên người quản lý và lương của người quản lý của mọi phòng ban.
create view DeptManagerSalary_View as 
select pb.MaPB, nv.HoTen, nv.LuongCB 
from NhanVien nv, PhongBan pb 
where nv.MaNV = pb.TrPhong;
go
-- View Danh sách nhân viên
create view DSNhanVien_View as
select MaNV, HoTen, GioiTinh, NgaySinh, QueQuan, SoDT, TenChucVu, TenPB, LuongCB, Password
from NhanVien nv, PhongBan pb, ChucVu cv
where nv.MaCV = cv.MaCV and nv.MaPB = pb.MaPB
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