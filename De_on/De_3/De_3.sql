create database De_3
use De_3

create table SINHVIEN(
	MaSV char(10) not null primary key,
	HoTen nvarchar(30),
	NgaySinh date default'1/1/2002',
	GioiTinh nvarchar(20),
	NoiSinh nvarchar(40)
);

insert into SINHVIEN (MaSV, HoTen, GioiTinh, NoiSinh)
values
('M01', N'Nguyễn thị Hà', N'Nữ', N'Hà Nội'),
('M02', N'Nguyễn thị Hương', N'Nữ', N'Hải phòng')

select * from SINHVIEN