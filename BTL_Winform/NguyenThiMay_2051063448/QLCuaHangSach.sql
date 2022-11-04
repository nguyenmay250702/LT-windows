
/*
Họ tên:		Nguyễn Thị Mây
Lớp:		62TH1
MSV:		2051063448
*/

create database QLCuaHangSach;
use QLCuaHangSach;

--tạo bảng Sách:
create table Sach
(
	maSach char(10) not null primary key,
	tenSach nvarchar(100) not null,
	tacGia nvarchar(100),
	nhaXuatBan nvarchar(100),
	phanLoai nvarchar(60),
	giaBan float check(giaBan >0),
	soLuong int check(soLuong >=0)
);

--Tạo bảng hóa đơn
create table HoaDon
(
	maHD char(10) not null primary key,
	maSach char(10) not null,
	soLuongBan int check(soLuongBan>0),
	ngayBan date,
	thanhTien float,
	foreign key (maSach) references Sach(maSach) on delete cascade on update cascade
	--on delete cascade : khi cột đc tham chiếu tới bị xóa thì giá trị đc tự động xóa theo
	--on update cascade : khi cộ đc tham chiếu đc thay đổi thì giá trị đc thay đổi theo
	--VD: nếu mã sách 'MS01 có cả ở trong bảng hóa đơn và bảng Sách thì khi xóa dòng dữ liệu chứa mã sách 'MS01' 
	--	  thì dữ liệu tương ứng trong bảng hóa đơn có mã sách là 'MS01' tự động đc xóa theo (tương tự với update)
);

--Xóa bảng
--drop table HoaDon
--drop table Sach

--chèn dữ liệu
insert into Sach
values
('MS01', N'Báu vật của đời', N'Hector Malot', N'Nhà xuất bản A', N'Tiểu thuyết', 30, 26),
('MS02', N'Ông già và biển cả', N'Ernest Hemingway', N'Nhà xuất bản B', N'Tiểu thuyết', 100.6, 36),
('MS03', N'Hồ sơ bí ẩn', N'Khố kỳ kỳ', N'Nhà xuất bản C', N'Trinh thám kinh dị', 10, 20),
('MS04', N'Báu vật của đời', N'Mạc ngôn', N'Nhà xuất bản D', N'Tiểu thuyết', 100, 260),
('MS05', N'Khế ước xã hội', N'jean jacques Rousseau', N'Nhà xuất bản E', N'Trính trị', 90.51, 56)

--chèn dữ liệu vào bảng hóa đơn
insert into HoaDon
values
('HD01', 'MS03', 2, '3/25/2019', 20),
('HD02', 'MS04', 3, '6/29/2020', 300),
('HD03', 'MS04', 1, '6/29/2020', 100),
('HD04', 'MS02', 1, '7/29/2020', 100.6),
('HD05', 'MS05', 1, '6/29/2021', 90.51)
