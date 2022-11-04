create database De_8
use De_8

create table DATHANG(
	MaDH nvarchar(10) not null primary key,
	SoBan nvarchar(20),
	DoUong nvarchar(50),
	SoLuong int,
	Gia int,
	Ngay date,
);

insert into DATHANG values
(N'MH01', N'Bàn 1', N'Nước lọc',2, 10, '4/13/2022'),
(N'MH02', N'Bàn 1', N'Nước mận',3, 20, '5/17/2022'),
(N'MH03', N'Bàn 1', N'Nước táo',1, 16, '4/13/2022'),
(N'MH04', N'Bàn 2', N'Nước mơ',1, 10, '7/3/2022'),
(N'MH05', N'Bàn 3', N'Nước lọc',6, 10, '4/30/2022'),
(N'MH06', N'Bàn 3', N'Nước mận',2, 20, '1/18/2022'),
(N'MH07', N'Bàn 4', N'Nước táo',1, 16, '4/13/2022'),
(N'MH08', N'Bàn 5', N'Nước cất',1, 50, '1/9/2022'),
(N'MH09', N'Bàn 5', N'Nước lọc',3, 10, '4/11/2022'),
(N'MH010', N'Bàn 6', N'Nước xoài',1, 24, '4/11/2022')

select * from DATHANG
where (DoUong = N'Nước mận')and (ngay between '6/26/2022' and '6/26/2022')