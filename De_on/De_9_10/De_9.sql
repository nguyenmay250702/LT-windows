create database De_9
use De_9

create table KhachHang(
	MaKH int not null primary key,
	HoTen nvarchar(30),
	GioiTinh nvarchar(20),
	LoaiPhong nvarchar(1000),
	SoPhongThue int
);

--drop table KhachHang

--delete KhachHang

insert into KhachHang values
(0, N'NG Thị Hà', N'Nữ', N'VIB', 10),
(1, N'NG Văn Ninh', N'Nam', N'Thường', 11),
(2, N'Phạm Văn Hải', N'Nam', N'VIB', 12),
(3, N'Nguyễn Thị Linh', N'Nữ', N'VIB', 13),
(4, N'Nguyễn Hải Hương', N'Nữ', N'Thường', 14)
