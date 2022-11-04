create database De_2
use De_2

create table Hang(
	MaHang char(10) not null primary key,
	TenHang nvarchar(30),
	SoLuong int check(SoLuong >= 0),
	DonGia float check(DonGia >= 0)
);

insert into Hang values
('MH01', N'Sách toán', 7, 34.9),
('MH02', N'Sách Văn', 73, 69.9),
('MH03', N'Sách Anh', 16, 46)

