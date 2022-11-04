create database De_14
use De_14

create table SanPham(
	TenSP nvarchar(30) not null primary key,
	DonGia float,
	SoLuongTon int,
);

create table ChiTietHD(
	MaCTHD int identity(1,1) not null primary key,
	TenSP nvarchar(30) not null,
	SoLuongBan int,
	ThanhTien float,
	foreign key (TenSP) references SanPham(TenSP)
);

drop table ChiTietHD
drop table SanPham

insert into SanPham values
(N'Táo Đỏ', 80.6, 36),
(N'Táo Đen', 12, 46),
(N'Táo Vàng',34.8, 89),
(N'Táo Tím', 89, 100)

insert into ChiTietHD values
(N'Táo Đỏ', 10, 806),
(N'Táo Đỏ', 1, 80.6),
(N'Táo Đen', 1, 12)
