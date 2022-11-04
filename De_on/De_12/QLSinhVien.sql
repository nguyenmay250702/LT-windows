create database QLSinhVien;
use QLSinhVien;

create table Khoa(
	MaKhoa nchar(6) not null primary key,
	TenKhoa nchar(30)
);

create table Mon(
	MaMH nchar(6) not null primary key,
	TenMH nchar(50),
	SoTiet int
);

create table SinhVien(
	MaSo int not null primary key,
	MaKhoa nchar(6) not null,
	HoTen nvarchar(50),
	NgaySinh datetime,
	GioiTinh bit,
	DiaChi nvarchar(50),
	DienThoai int,
	foreign key (MaKhoa) references Khoa(MaKhoa) on delete cascade on update cascade
);

create table KetQua(
	MaSo int not null,
	MaMH nchar(6) not null,
	Diem int,
	foreign key (MaSo) references SinhVien(MaSo) on delete cascade on update cascade,
	foreign key (MaMH) references Mon(MaMH) on delete cascade on update cascade
);

drop table KetQua;
drop table SinhVien;
drop table Khoa;
drop table Mon;

insert into Khoa values
('MK01', N'Công nghệ thông tin'),
('MK02', N'Kinh tế'),
('MK03', N'Cơ khí'),
('MK04', N'Xây dựng'),
('MK05', N'Kiến trúc')

insert into Mon values
('MMH01', N'LT python', 38),
('MMH02', N'LT windown', 23),
('MMH03', N'TA1', 46),
('MMH04', N'TA2',23),
('MMH05', N'TACN', 27)

insert into SinhVien values
(001, 'MK01', N'Nguyễn Văn A', '1/14/2002', 0, N'Hà nội', 111111),
(002, 'MK02', N'Nguyễn Thị B', '3/25/2021', 1, N'Hà nội', 222222),
(003, 'MK03', N'Nguyễn Văn C', '6/30/2022', 0, N'Hà nội', 777777),
(004, 'MK04', N'Nguyễn Văn D', '11/30/2022', 0, N'Hà nội', 666666),
(005, 'MK04', N'Nguyễn Thị E', '4/27/2022', 1, N'Hà nội', 555555)

insert into KetQua values
(001, 'MMH01', 8),
(001, 'MMH02', 4),
(002, 'MMH01', 6),
(003, 'MMH03', 7),
(004, 'MMH02', 6)


