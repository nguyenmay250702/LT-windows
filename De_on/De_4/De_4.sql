create database QLDiem
use QLDiem

create table DanhSach(
	MaSV varchar(10) not null primary key,
	TenSV nvarchar(30),
	DiemToan float check(0<= DiemToan and DiemToan <=10),
	DiemVan float check(0<= DiemVan and DiemVan <=10),
	DiemNgoaiNgu float check(0<= DiemNgoaiNgu and DiemNgoaiNgu <=10)
);

drop table DanhSach

insert into DanhSach
values
('MS01', N'Nguyễn Thị A', 6.8, 9, 7.6),
('MS02', N'Nguyễn Văn B', 8.9, 3, 9),
('MS03', N'Phạm Văn C', 5, 3, 9.2),
('MS04', N'Trần Văn D', 8, 4.5, 6),
('MS05', N'Nguyễn Văn E', 2, 3, 8.7)

