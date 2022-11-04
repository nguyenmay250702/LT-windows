CREATE DATABASE QUAN_LY_CUA_HANG_BAN_SACH;
USE QUAN_LY_CUA_HANG_BAN_SACH;

--1. tạo quan hệ
CREATE TABLE SACH(
maSach CHAR(10) NOT NULL,
tenSach NVARCHAR(100) NOT NULL,
tacGia NVARCHAR(50),
nhaXuatBan NVARCHAR(50),
phanLoai NVARCHAR(30),
tonKho INT,
giaBan INT,
PRIMARY KEY(maSach),
);

CREATE TABLE HOADON(
maHoaDon CHAR(10) NOT NULL,
maSach CHAR(10) NOT NULL,
tenSachBan NVARCHAR(50) DEFAULT 'NULL',
ngayBan DATE,
giaSachBan INT DEFAULT -1,
soLuong INT,
tongGia INT DEFAULT -1,
PRIMARY KEY (maHoaDon),
FOREIGN KEY (maSach) REFERENCES dbo.SACH
);

--2. thêm dữ liệu
INSERT INTO dbo.SACH VALUES
('0000000001', N'Thanh Xuân Có Cậu Là Đủ Rồi', N'Văn Học Trẻ', N'Nhà xuất bản Dân Trí', N'Tiểu thuyết', 50, 63000),
('0000000002', N'Câu Chuyện Tương Lai Mà Tôi Bỏ Lỡ', N'', N'Nhà Xuất Bản Thế Giới', N'Tiểu thuyết', 55, 77000),
('0000000003', N'Nắng Cuối Chiều', N'', N'Nhà xuất bản Dân Trí', N'Tiểu thuyết', 45, 70000),
('0000000004', N'Chuyện Tình Không Tên', N'Vũ Thành An', N'Công ty Phương Nam Book', N'Tiểu thuyết', 35, 133000),
('0000000005', N'Tiếng anh chuyên ngành', N'', N'Đại Học Bách Khoa Hà Nội', N'Giáo trình', 40, 50000),
('0000000006', N'Hành trình kỳ diệu', N'Nguyễn Thị Phương', N'Nhà xuất bản Nghệ An', N'Văn học nghệ thuật', 40, 70000),
('0000000007', N'Ra bờ suối ngắm hoa kèn hồng', N'Nguyễn Nhật Ánh', N'Nhà xuất bản Trẻ', N'Văn học nghệ thuật', 30, 116000),
('0000000008', N'Sức Bật Cho Thế Hệ Mới', N'Nguyễn Hồng', N'Nhà xuất bản Tri thức', N'Khoa học công nghệ', 55, 58000),
('0000000009', N'Giáo Trình Kinh Tế Chính Trị Mác – Lênin', N'', N'Nhà Xuất Bản Chính Trị Quốc Gia Sự Thật', N'Giáo trình', 40, 59000),
('0000000010', N'Giáo Trình C++ Và Lập Trình Hướng Đối Tượng', N'', N'Đại Học Bách Khoa Hà Nội', N'Giáo trình', 40, 97000)

INSERT INTO dbo.HOADON (maHoaDon, maSach, ngayBan, soLuong) VALUES 
('HD-0000001','0000000001','2020-5-25',1),
('HD-0000002','0000000002','2020-3-10',1),
('HD-0000003','0000000010','2020-3-10',3),
('HD-0000004','0000000003','2020-6-11',1),
('HD-0000005','0000000005','2020-9-22',2),
('HD-0000006','0000000008','2020-11-11',2),
('HD-0000007','0000000006','2020-5-10',1)

--drop table SACH
--drop table HOADON

select * from SACH