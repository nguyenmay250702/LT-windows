create database De_7
use De_7

create table DATHANG(
	MaDH nvarchar(10) not null primary key,
	SoBan nvarchar(20),
	DoUong nvarchar(50),
	SoLuong int,
	Gia int,
);

drop table DATHANG

insert into DATHANG values
(N'M01', N'Bàn 1', N'Nước Cất', 5, 46000),
(N'M02', N'Bàn 2', N'Nước Dâu', 4, 25000),
(N'M03', N'Bàn 2', N'Nước Táo', 1, 10000),
(N'M04', N'Bàn 3', N'Nước Dâu', 2, 25000),
(N'M05', N'Bàn 4', N'Nước lọc', 1, 36000),
(N'M06', N'Bàn 4', N'Nước Cất', 2, 46000)