use QuanLyNhanVien
--Tạo ROLE
Create Role Administrator AUTHORIZATION db_owner
go
Create Role Employee
go
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