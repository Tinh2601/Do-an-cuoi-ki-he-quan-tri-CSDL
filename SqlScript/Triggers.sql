use QuanLyNhanVien
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