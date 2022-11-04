create database De_13
use De_13

create table Truyen(
	MaTruyen char(10) not null primary key,
	TenTruyen nvarchar(30),
	DonGiaNgay float
);

--identity(1,1) đánh số tự động tăng dần bắt đầu từ 1, mỗi lần tăng thêm 1
create table PhieuMuon(
	MaPM int identity(1,1) not null primary key,
	TenKhach nvarchar(30),
	SoDT char(10),
	TenTruyenPM nvarchar(20),
	NgayMuon date,
	NgayTra date,
	ThanhTien float,
	GhiChu nvarchar(50)
);

drop table Truyen
drop table PhieuMuon

insert into Truyen values 
('MT01', N'Thạch sanh', 45.8),
('MT02', N'Cô bé khăn đỏ', 36),
('MT03', N'Cừu và sói', 67.98),
('MT04', N'Conan', 56)

insert into PhieuMuon values
(N'NT Mai','0111111111', N'Thạch sanh', '6/23/2022', '7/1/2022', 200.4, null),
(N'BV Thành','0222222222', N'Conan',  '4/13/2022', '7/1/2022', 146, null)

select * from PhieuMuon