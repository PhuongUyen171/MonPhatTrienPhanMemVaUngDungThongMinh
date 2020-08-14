-- TẠO DATABASE --
CREATE DATABASE QLShopMP
USE QLShopMP
GO
---------------------TẠO BẢNG -----------------------

CREATE TABLE THE_LOAI_SAN_PHAM
(
	MaLoaiSP nvarchar(10) PRIMARY KEY,
	TenLoaiSP nvarchar(30)
)

CREATE TABLE THUONG_HIEU
(
	MaTH nvarchar(10) PRIMARY KEY,
	TenTH nvarchar(50),
	Images nvarchar(max)
)

CREATE TABLE SAN_PHAM
(
	MaSP nvarchar(20) PRIMARY KEY,
	MaLoaiSP nvarchar(10),
	TenSP nvarchar(100),
	DonViTinh nvarchar(10),
	SoLuong int,
	GiaBan money,
	GiaVon money,
	TrangThai bit,
	HinhAnh nvarchar(max),
	MoTa nvarchar(max),
	MaTH nvarchar(10),
	FOREIGN KEY(MaLoaiSP) REFERENCES THE_LOAI_SAN_PHAM(MaLoaiSP),
	FOREIGN KEY(MaTH) REFERENCES THUONG_HIEU(MaTH)
)

CREATE TABLE CHI_TIET_PHIEU_TRA_HANG_NHAP
(
	MaPTN nvarchar(10) NOT NULL,
	MaSP nvarchar(20) NOT NULL,
	SoLuong int,
	GiaTra money,
	PRIMARY KEY(MaPTN,MaSP),
	FOREIGN KEY(MaSP) REFERENCES SAN_PHAM(MaSP),
)


CREATE TABLE CHUC_VU
(
	MaCV nvarchar(10) PRIMARY KEY,
	TenCV nvarchar(30)
)

CREATE TABLE LOAI_KHACH_HANG
(
	MaLoaiKH nvarchar(20) PRIMARY KEY,
	TenLoaiKH nvarchar(30),
	GioiHanDuoi money,
	GioiHanTren money,
	GiamGia int
)

CREATE TABLE KHACH_HANG
(
	MaKH nvarchar(20) PRIMARY KEY,
	TenKH nvarchar(30),
	MaLoaiKH nvarchar(20),
	NgaySinh DATE,
	NgayDangKy DATE,
	CMND char(12),
	Email nvarchar(max) DEFAULT N'Chưa xác định',
	SDT  char(11),
	DiaChi nvarchar(max) DEFAULT N'Chưa xác định',
	TongTienMua money,
	FOREIGN KEY(MaLoaiKH) REFERENCES LOAI_KHACH_HANG(MaLoaiKH)
)

CREATE TABLE NHAN_VIEN
(
	MaNV nvarchar(10)  PRIMARY KEY,
	TenNV nvarchar(30),
	MaCV nvarchar(10),
	NgaySinh date,
	CMND char(12),
	Email nvarchar(max) DEFAULT N'Chưa xác định',
	SDT char(11) DEFAULT N'Chưa xác định',
	Luong money,
	FOREIGN KEY(MaCV) REFERENCES CHUC_VU(MaCV)
)

CREATE TABLE HOA_DON
(	
	MaHD int identity  PRIMARY KEY,
	MaKH nvarchar(20),
	MaNV nvarchar(10),
	ThoiGian datetime,
	GiamGia int,
	TongTien money,
	FOREIGN KEY(MaNV) REFERENCES NHAN_VIEN(MaNV),
	FOREIGN KEY(MaKH) REFERENCES KHACH_HANG(MaKH)
)

CREATE TABLE CHI_TIET_HOA_DON
(
	MaHD int  NOT NULL,
	MaSP nvarchar(20)  NOT NULL,
	GiaVon money,
	GiaBan money,
	SoLuong int,
	PRIMARY KEY(MaHD,MaSP),
	FOREIGN KEY(MaHD) REFERENCES HOA_DON(MaHD),
	FOREIGN KEY(MaSP) REFERENCES SAN_PHAM(MaSP)
)

CREATE TABLE DANG_NHAP
(
	MaNV nvarchar(10),
	TaiKhoan nvarchar(22)  PRIMARY KEY,
	MatKhau nvarchar(100),
	TinhTrang bit,
	FOREIGN KEY(MaNV) REFERENCES NHAN_VIEN(MaNV)
)

CREATE TABLE MAN_HINH
(
	MaMH nvarchar(30) PRIMARY KEY,
	TenMH nvarchar(50)
)

CREATE TABLE NHOM_NGUOI_DUNG
(
  MaNhom nvarchar(10) PRIMARY KEY,
  TenNhom nvarchar(30)
)

CREATE TABLE PHAN_QUYEN
(
	MaNhom nvarchar(10) NOT NULL,
	MaMH nvarchar(30) NOT NULL,
	CoQuyen bit,
	PRIMARY KEY(MaNhom,MaMH),
	FOREIGN KEY(MaNhom) REFERENCES NHOM_NGUOI_DUNG(MaNhom),
	FOREIGN KEY(MaMH) REFERENCES MAN_HINH(MaMH)
)

CREATE TABLE NGUOI_DUNG_NHOM_NGUOI_DUNG
(
	TaiKhoan nvarchar(22) PRIMARY KEY,
	MaNhom nvarchar(10),
	FOREIGN KEY(MaNhom) REFERENCES NHOM_NGUOI_DUNG(MaNhom),
	FOREIGN KEY(TaiKhoan) REFERENCES DANG_NHAP(TaiKhoan)
)

CREATE TABLE PHIEU_KIEM_KHO
(
	MaKiemKho nvarchar(30) PRIMARY KEY,
	ThoiGian datetime,
	TongChenhLech int,
	MaNV nvarchar(10),
	GhiChu nvarchar(200),
	TrangThai bit,
	FOREIGN KEY(MaNV) REFERENCES NHAN_VIEN(MaNV)
)

CREATE TABLE CHI_TIET_PHIEU_KIEM_KHO
(
	MaKiemKho nvarchar(30) NOT NULL,
	MaSP nvarchar(20) NOT NULL,
	SoLuong int,
	SoLuongThucTe int,
	ChenhLech int,
	PRIMARY KEY(MaKiemKho,MaSP),
	FOREIGN KEY(MaKiemKho) REFERENCES PHIEU_KIEM_KHO(MaKiemKho),
	FOREIGN KEY(MaSP) REFERENCES SAN_PHAM(MaSP)
)

CREATE TABLE NHA_CUNG_CAP
(
	MaNCC nvarchar(10) PRIMARY KEY,
	TenNCC nvarchar(70),
	MaSoThue char(13),
	DiaChi nvarchar(max),
	Email nvarchar(max),
	SDT char(11),
	TongTien money
)

CREATE TABLE PHIEU_NHAP
(
	MaPN nvarchar(30) PRIMARY KEY,
	MaNV nvarchar(10),
	MaNCC nvarchar(10),
	ThoiGian date,
	GiamGia int,
	TongTien money,
	FOREIGN KEY(MaNCC) REFERENCES NHA_CUNG_CAP(MaNCC),
	FOREIGN KEY(MaNV) REFERENCES NHAN_VIEN(MaNV)
)

CREATE TABLE CHI_TIET_PHIEU_NHAP
(
	MaPN nvarchar(30)  NOT NULL,
	MaSP nvarchar(20)  NOT NULL,
	GiaNhap money,
	GiamGia int,
	SoLuong int,
	PRIMARY KEY(MaPN,MaSP),
	FOREIGN KEY(MaPN) REFERENCES PHIEU_NHAP(MaPN),
	FOREIGN KEY(MaSP) REFERENCES SAN_PHAM(MaSP)
)

CREATE TABLE PHIEU_TRA_HANG_NHAP
(
	MaPTN nvarchar(10) PRIMARY KEY,
	MaNCC nvarchar(10),
	MaNV nvarchar(10),
	FOREIGN KEY(MaNCC) REFERENCES NHA_CUNG_CAP(MaNCC),
	FOREIGN KEY(MaNV) REFERENCES NHAN_VIEN(MaNV)
)

CREATE TABLE CHI_TIET_PHIEU_TRA_HANG_BAN
(
	MaPTB nvarchar(30)  NOT NULL,
	MaSP nvarchar(20)  NOT NULL,
	SoLuong int,
	PRIMARY KEY(MaPTB,MaSP),
	FOREIGN KEY(MaSP) REFERENCES SAN_PHAM(MaSP)
)

CREATE TABLE PHIEU_TRA_HANG_BAN
(
	MaPTB nvarchar(30) PRIMARY KEY,
	MaHD int,
	MaNV nvarchar(30),
	MaKH nvarchar(20),
	ChiPhi money,
	TongTien money,
	ThoiGian datetime,
	FOREIGN KEY(MaHD) REFERENCES HOA_DON(MaHD)
)

CREATE TABLE HOAT_DONG
(
	MaHoatDong nvarchar(20) PRIMARY KEY,
	MaNV nvarchar(10),
	HoatDong nvarchar(30),
	ThoiGian datetime,
	GiaTri money,
	FOREIGN KEY(MaNV) REFERENCES NHAN_VIEN(MaNV)
)


INSERT INTO THE_LOAI_SAN_PHAM(MaLoaiSP,TenLoaiSP) VALUES
('SRM',N'Sữa rửa mặt'),
('TTB',N'Tẩy tế bào chết'),
('KN',N'Kem nền'),
('MN',N'Mặt nạ'),
('KCN',N'Kem Chống nắng'),
('TN',N'Toner'),
('DA',N'Dưỡng Ẩm'),
('NHH',N'Nước Hoa Hồng'),
('SR',N'Serum'),
('KKD',N'Kem che khuyết điểm'),
('SM',N'Son môi'),
('NH',N'Nước Hoa'),
('DT',N'Dưỡng tóc'),
('RM',N'Răng miệng')

INSERT INTO THUONG_HIEU(MaTH,TenTH,Images) VALUES 
('TH001',N'THE BODY SHOP',N'THE BODY SHOP.jpg'),
('TH002',N'BAEUTY TREATS',N'BAEUTY TREATS.jpg'),
('TH003',N'BIORÉP',N'BIORÉP.jpg'),
('TH004',N'CALVIN KLEIN',N'CALVIN KLEIN.jpg'),
('TH005',N'CETAPHIL',N'CETAPHIL.jpg'),
('TH006',N'CHANEL',N'CHANEL.jpg'),
('TH007',N'HANEDA COLLAGEN',N'HANEDA COLLAGEN.jpg'),
('TH008',N'LA GIRL',N'LA GIRL.jpg'),
('TH009',N'OLAY',N'OLAY.jpg'),
('TH010',N'THE SKIN FACE',N'THE SKIN FACE.jpg')

INSERT INTO SAN_PHAM(MaSP,MaLoaiSP,TenSP,DonViTinh,SoLuong,GiaBan,GiaVon,TrangThai,HinhAnh,MoTa,MaTH) VALUES
('SP001','SR',N'Serum trị mụn',N'Lọ',50,300000,250000,1,N'Tinh Chất The Body Shop Tea Tree.jpg',N'Chiết xuất từ tinh dầu lá Tràm Trà tinh khiết.Cải thiện kết cấu và khuyết điểm của làn da. Cho làn da tươi trẻ, khỏe khoắn và căng bóng.','TH001'),
('SP002','TTB',N'Tẩy Tế Bào Chết Body Scentio Riceberry Cream 200gr',N'Lọ',30,100000,80000,1,N'Tẩy Tế Bào Chết Body Scentio Riceberry Cream 200gr.jpg',N'Chiết xuất từ tinh chất gạo lứt bổ sung thêm dưỡng chất.Vitamin A và các chất chống oxy hóa tự nhiên mạnh mẽ.','TH002'),
('SP003','SM',N'Son Lì Make Up For Ever Artist Liquid Matte',N'Thỏi',30,300000,250000,1,N'Son Lì Make Up For Ever Artist Liquid Matte.jpg',N'Chất son lì nhưng vô cùng mịn mượt, lên màu chuẩn','TH003'),
('SP004','NH',N'Nước Hoa Nữ Christian Dior Miss Dior Eau De Parfum',N'Lọ',40,800000,700000,1,N'Nước Hoa Nữ Christian Dior Miss Dior Eau De Parfum.jpg',N'Phong cách giản dị, thân thiện quyến rũ ','TH004'),
('SP005','KN',N'Kem nền dạng bột Innisfree',N'Hủ',50,270000,250000,1,N'Phấn Phủ Dạng Bột Innisfree No Sebum Moisture Powder 5g.jpg',N'Thiết kế tỉ mỉ từng chi tiết nhỏ để các nàng có nhiều lựa chọn cho tone da của mình.Chứa hàm lượng dưỡng ẩm cao giúp da được duy trì cung cấp độ ẩm cả ngày','TH005'),
('SP006','RM',N'Bột Than Hoạt Tính Đánh Trắng Răng Teeth Whitening',N'Cái',50,150000,120000,1,N'Bột Than Hoạt Tính Đánh Trắng Răng Teeth Whitening.jpg',N'Toàn bộ thành phần tự nhiên có tính hiệu quả cao trong việc loại bỏ hoàn toàn các tác nhân gây xấu cho răng như cà phê, thuốc lá, rượu, sô đa,…','TH006'),
('SP007','MN',N'Cám Gạo Trà Xanh',N'Bịch',50,120000,100000,1,N'Cám Gạo Trà Xanh.jpg',N'Giảm mụn đầu đen, mụn trứng cá... và se khít lỗ chân lông.Chống oxy hóa cao, chống lão hóa','TH007'),
('SP008','DT',N'Dầu Gội Cho Tóc Nhuộm TRESemmé Color Radiance 250ml',N'Chai',50,150000,100000,1,N'Dầu Gội Cho Tóc Nhuộm TRESemmé Color Radiance 250ml.jpg',N'Tăng cường ánh màu giúp điều chỉnh sắc độ màu và giữ màu tóc nhuộm sống động như ý.','TH008'),
('SP009','DT',N'Dầu Gội Tóc Thường Dưỡng Sinh Gia Truyền Hương Như 500ml',N'Chai',50,200000,180000,1,N'Dầu Gội Tóc Thường Dưỡng Sinh Gia Truyền Hương Như 500ml.jpg',N'Thành phần từ thảo dược thiên nhiên giàu dưỡng chất.','TH009'),
('SP010','DT',N'Dầu Gội Xả Head Shoulder 2 In 1 Dry Scalp Care 950ml',N'Chai',50,100000,80000,1,N'Dầu Gội Xả Head Shoulder 2 In 1 Dry Scalp Care 950ml.jpg',N'Giúp bảo vệ và chăm sóc da đầu của bạn trước những tác động từ môi trường','TH010'),
('SP011','DT',N'Dầu Xả Biotin & Collagen Thickening 400ml',N'Chai',30,70000,60000,1,N'Dầu Xả Biotin & Collagen Thickening 400ml.jpg',N'Cung cấp độ ẩm và bổ sung các axit amin, khoáng chất','TH001'),
('SP012','SR',N'Dưỡng Mắt 3W Clinic Collagen Lifting Eye Cream 35ml',N'Cái',50,130000,120000,1,N'Dưỡng Mắt 3W Clinic Collagen Lifting Eye Cream 35ml.jpg',N'Xóa nếp nhăn hiệu quả, tăng cường độ đàn hồi.Giảm sự kích ứng da và mệt mỏi của vùng mắt.','TH002'),
('SP013','DA',N'Dưỡng Trắng Innisfree Jeju Cherry Blossom Tone-Up Cream',N'Hủ',30,150000,140000,1,N'Dưỡng Trắng Innisfree Jeju Cherry Blossom Tone-Up Cream.jpg',N'Hỗ trợ nâng tone da, giúp cải thiện tông da trắng sáng','TH003'),
('SP014','DA',N'Gel Rửa Tay Bath Body Works Japanese Cherry Blossom',N'Chai',50,60000,40000,1,N'Gel Rửa Tay Bath Body Works Japanese Cherry Blossom.jpg',N'Gel Rửa Tay Bath Body Works Japanese Cherry Blossom','TH004'),
('SP015','DA',N'Gel Rửa Tay Khô Bath Body Works Honolulu Sun 29ml',N'Chai',40,70000,60000,1,N'Gel Rửa Tay Khô Bath Body Works Honolulu Sun 29ml.jpg',N'Gel Rửa Tay Khô Bath Body Works Honolulu Sun','TH005'),
('SP016','RM',N'Kem Đánh Răng Baking Soda Toothpaste 220g',N'Cái',50,50000,30000,1,N'Kem Đánh Răng Baking Soda Toothpaste 220g.jpg',N'Thành phần Baking soda, chiết xuất thảo dược thiên nhiên.Trung hòa axit trong vòm miệng, loại bỏ mảng bám.','TH006'),
('SP017','RM',N'Kem Đánh Răng Colgate Sensitive Whitening 170g',N'Cái',30,50000,30000,1,N'Kem Đánh Răng Colgate Sensitive Whitening 170g.jpg',N'Kem Đánh Răng Colgate Sensitive Whitening ','TH007'),
('SP018','RM',N'Kem Đánh Răng Crest 3D White Radiant Mint 99gr',N'Cái',50,70000,50000,1,N'Kem Đánh Răng Crest 3D White Radiant Mint 99gr.jpg',N'Sản phẩm giúp đánh bật mọi vết bẩn, ố vàng trên răng tích tụ suốt hơn mười năm qua, và trả lại hàm răng trắng bóng','TH008'),
('SP019','DA',N'Kem Dưỡng Da Tay Mamonde Flower Scented 50ml',N'Lọ',60,90000,80000,1,N'Kem Dưỡng Da Tay Mamonde Flower Scented 50ml.jpg',N'Cung cấp độ ẩm cao và dưỡng chất làm mờ các vết thâm xạn.Giúp cung cấp dưỡng chất cho da tay thêm mềm mịn.','TH009'),
('SP020','SR',N'Kem Dưỡng Mắt Clinique All About Eyes 7ml',N'Lọ',40,180000,160000,1,N'Kem Dưỡng Mắt Clinique All About Eyes 7ml.jpg',N'Chất kem thấm nhanh, không gây nhờn rích. Làm dịu da, tăng cường sản sinh collagen','TH010'),
('SP021','SR',N'Kem Dưỡng Mắt Innisfree Green Tea Seed Eye Cream 30ml',N'Lọ',50,280000,250000,1,N'Kem Dưỡng Mắt Innisfree Green Tea Seed Eye Cream 30ml.jpg',N'Hiệu quả chống oxy hóa của EGCG trà xanh giúp dưỡng ẩm và làm sáng da','TH001'),
('SP022','KN',N'Kem Lót Sugao Snow Whipped Cream SPF 23',N'Hủ',70,290000,250000,1,N'Kem Lót Sugao Snow Whipped Cream SPF 23.jpg',N'Chỉ số chống nắng SPF23 PA+++ ngăn chặn tác hại từ tia UVA và UVB.','TH002'),
('SP023','KN',N'Kem Mắt AHC Ageless Real Eye Cream For Face 30ml',N'Hủ',50,220000,200000,1,N'Kem Mắt AHC Ageless Real Eye Cream For Face 30ml.jpg',N'Chứa hơn 10 loại Peptide giúp ngăn ngừa, chống lão hóa da và săn mịn da','TH003'),
('SP024','KN',N'Kem Nền Innisfree My Foundation 30ml',N'Hủ',50,270000,250000,1,N'Kem Nền Innisfree My Foundation 30ml.jpg',N'Thiết kế tỉ mỉ từng chi tiết nhỏ để các nàng có nhiều lựa chọn cho tone da của mình.Chứa hàm lượng dưỡng ẩm cao giúp da được duy trì cung cấp độ ẩm cả ngày','TH004'),
('SP025','RM',N'Máy Làm Trắng Răng Crest 3D White Light',N'Cái',50,400000,350000,1,N'Máy Làm Trắng Răng Crest 3D White Light.jpg',N'Sản phẩm giúp đánh bật mọi vết bẩn, ố vàng trên răng tích tụ suốt hơn mười năm qua, và trả lại hàm răng trắng bóng','TH005'),
('SP026','TTB',N'Miếng Lột Mụn Đầu Đen Innisfree Jeju Volcanic Nose Pack',N'Cái',50,40000,20000,1,N'Miếng Lột Mụn Đầu Đen Innisfree Jeju Volcanic Nose Pack.jpg',N'Làm sạch các bã nhờn và tạp chất trên da.Tạo cảm giác thư giãn, dễ chịu nhờ hương Lavender','TH006'),
('SP027','DA',N'Muối Tắm A Bonné Snaily Yogurt 350gr',N'Bịch',40,280000,260000,1,N'Muối Tắm A Bonné Snaily Yogurt 350gr.jpg',N'Tẩy tế bào chết và tạp chất cứng đầu. Nuôi dưỡng làn da săn chắc và sáng mịn tự nhiên.','TH007'),
('SP028','DA',N'Muối Tắm Sữa Tẩy Tế Bào Chết A Bonné Spa Milk Salt',N'Bịch',50,270000,250000,1,N'Muối Tắm Sữa Tẩy Tế Bào Chết A Bonné Spa Milk Salt.jpg',N'Xóa mờ các vết thâm ở những vùng khó điều trị. Giúp ngăn ngừa và phòng chống các bệnh về da','TH008'),
('SP029','NH',N'Nước Hoa Nam Gatsby Secret Style 60ml',N'Lọ',40,250000,240000,1,N'Nước Hoa Nam Gatsby Secret Style 60ml.jpg',N'Mùi hương nam tính thể hiện sự nam tính, đầy sức sống','TH009'),
('SP030','NH',N'Nước Hoa Nữ Bvlgari Rose Goldea EDP',N'Lọ',50,300000,250000,1,N'Nước Hoa Nữ Bvlgari Rose Goldea EDP.jpg',N'Sở hữu sự mở đầu rực rỡ với hương hoa, trái cây và tươi mát cùng một lúc','TH010'),
('SP031','NH',N'Nước Hoa Nữ Christian Dior Miss Dior Eau De Parfum',N'Lọ',80,350000,290000,1,N'Nước Hoa Nữ Christian Dior Miss Dior Eau De Parfum.jpg',N'Phong cách giản dị, thân thiện quyến rũ ','TH001'),
('SP032','SR',N'Serum Dưỡng Mi Maybelline Lash Sensational 5.3ml',N'Lọ',70,270000,260000,1,N'Serum Dưỡng Mi Maybelline Lash Sensational 5.3ml.jpg',N'Công thức dưỡng lông mi với arginine và pro-vitamin B5.Mang lại hàng mi khỏe mạnh chỉ sau 4 tuần sử dụng','TH002'),
('SP033','DA',N'Sáp Dưỡng Da Vaseline Blue Seal Vitamin E 50ml',N'Hủ',90,230000,220000,1,N'Sáp Dưỡng Da Vaseline Blue Seal Vitamin E 50ml.jpg',N'Loại bỏ da khô, chết lâu ngày, cải tạo da cho đôi môi sáng hơn, mềm mịn hơn không vết nứt.','TH003'),
('SP034','SM',N'Son Lì Make Up For Ever Artist Liquid Matte',N'Thỏi',50,280000,260000,1,N'Son Lì Make Up For Ever Artist Liquid Matte.jpg',N'Chất son lì nhưng vô cùng mịn mượt, lên màu chuẩn','TH004'),
('SP035','TTB',N'Tẩy Tế Bào Chết ESI Bio SkinCare Face & Body Strawberry 250ml',N'Hủ',40,200000,180000,1,N'Tẩy Tế Bào Chết ESI Bio SkinCare Face & Body Strawberry 250ml.jpg',N'Tẩy sạch mọi bụi bẩn, tế bào chết cứng đầu trên body.Bổ sung dưỡng từ quả trái cây thiên nhiên dưỡng ẩm cho làn da.','TH005')

INSERT INTO CHI_TIET_PHIEU_TRA_HANG_NHAP(MaPTN,MaSP,SoLuong,GiaTra) VALUES
('PTN001','SP001',1,250000),
('PTN002','SP002',1,80000)


INSERT INTO CHUC_VU(MaCV,TenCV) VALUES
('CV001',N'Quản lý trưởng'),
('CV002',N'Nhân viên thu ngân'),
('CV003',N'Thủ kho'),
('CV004',N'Nhân viên tư vấn'),
('CV005',N'Quản lý chi nhánh'),
('CV006',N'Nhân viên bán hàng'),
('CV007',N'Nhân viên giao hàng')

INSERT INTO LOAI_KHACH_HANG(MaLoaiKH,TenLoaiKH,GioiHanDuoi,GioiHanTren,GiamGia) VALUES
('LKH001',N'Đồng',0,4999999,0),
('LKH002',N'Bạc',5000000,9999999,5),
('LKH003',N'Vàng',10000000,19999999,10),
('LKH004',N'Bạch Kim',20000000,49999999,15),
('LKH005',N'Kim Cương',50000000,999999999,20)


SET DATEFORMAT DMY
INSERT INTO KHACH_HANG(MaKH,TenKH,MaLoaiKH,NgaySinh,NgayDangKy,CMND,Email,SDT,DiaChi,TongTienMua) VALUES
('KH001',N'Nguyễn Xuân Nhật','LKH004','26-10-2000','01-01-2020',215766247,'xuannhat111222@gmail.com',01548648562,N'72/34 Dương Đức Hiền,Quận Tân Phú',1000000),
('KH002',N'Nguyễn Phương Uyên','LKH005','17-01-2001','01-01-2020',215445335,'phuonguyen111222@gmail.com',01236865475,N'Số 11,Quận Bình Tân',2000000),
('KH003',N'Nguyễn Phương Trúc','LKH005','17-02-2001','01-01-2020',215032335,'phuongtruc111222@gmail.com',02585348523,N'Số 11,Quận 7',2500000),
('KH004',N'Nguyễn Nhã Uyên','LKH001','17-03-2001','01-01-2020',215729335,'nhauyen111222@gmail.com',02586577773,N'Số 311,Quận Bình Tân',2600000),
('KH005',N'Nguyễn Kiều Phi','LKH002','17-04-2001','01-01-2020',215545335,'kieuphi111222@gmail.com',02586563443,N'Số 141,Quận 2',2100000),
('KH006',N'Nguyễn Mỹ Nương','LKH003','17-05-2001','01-01-2020',214255335,'mynuong111222@gmail.com',02586543453,N'Số 411,Quận 5',3000000),
('KH007',N'Nguyễn Tâm Như','LKH004','17-06-2001','01-01-2020',215765335,'tamnhu121222@gmail.com',02586545555,N'Số 111,Quận Bình Tân',4000000),
('KH008',N'Nguyễn Tú Anh','LKH005','17-07-2001','01-01-2020',215425735,'tuanh113222@gmail.com',02586549977,N'Số 1311,Quận 4',7000000),
('KH009',N'Nguyễn Tuyết Anh','LKH001','17-08-2001','01-01-2020',227545335,'tuyetanh241222@gmail.com',02586546754,N'Số 131,Quận Bình Tân',3500000),
('KH010',N'Nguyễn Hồng Phương','LKH002','17-09-2001','01-01-2020',247445335,'hongphuong11222@gmail.com',02586746523,N'Số 11,Quận 7',6000000),
('KH011',N'Nguyễn Thúy An','LKH003','17-10-2001','01-01-2020',215473635,'thuyan111222@gmail.com',02586541243,N'Số 1211,Quận Thủ Đức',2500000),
('KH012',N'Nguyễn Phỉ Thúy','LKH004','17-11-2000','01-01-2020',215275335,'phithuy111222@gmail.com',02586547546,N'Số 131,Quận 1',2900000),
('KH013',N'Nguyễn Khánh Vi','LKH005','17-12-2001','01-01-2020',215567335,'khanhvi111222@gmail.com',02586542574,N'Số 121,Quận 8',2400000),
('KH014',N'Nguyễn Kiều Hạnh','LKH001','17-01-2002','01-01-2020',214785335,'kieuhanh111222@gmail.com',0258655674,N'Số 211,Quận Bình Tân',3600000),
('KH015',N'Nguyễn Kiều Trang','LKH002','17-01-2003','01-01-2020',228545335,'kieutrang111222@gmail.com',02586545763,N'Số 161,Quận Bình Chánh',1000000),
('KH016',N'Nguyễn Yến Nhi','LKH003','17-01-2004','01-01-2020',215457835,'yennhi111222@gmail.com',02586456797,N'Số 311,Quận Bình Tân',5000000),
('KH017',N'Nguyễn Huyền Trân','LKH004','17-01-2005','01-01-2020',248545335,'huyentran111222@gmail.com',0258642344,N'Số 211,Quận 3',4000000),
('KH018',N'Nguyễn Châu Liên','LKH005','17-04-2002','01-01-2020',213955335,'chaulien111222@gmail.com',02586436754,N'Số 91,Quận 10',4500000),
('KH019',N'Nguyễn Yến Linh','LKH001','17-07-2003','01-01-2020',215285335,'yenlinh111222@gmail.com',02584328523,N'Số 18,Quận 12',2100000),
('KH020',N'Nguyễn Khánh Như','LKH002','17-09-2004','01-01-2020',211705335,'khanhnhu111222@gmail.com',02586542332,N'Số 11,Quận 11',2200000)

SET DATEFORMAT DMY
INSERT INTO NHAN_VIEN(MaNV,TenNV,MaCV,NgaySinh,CMND,Email,SDT,Luong) VALUES
('NV001',N'Nguyễn Thị Nhã Hân','CV001','14-12-1999',215787329,'Hanhan332@gmail.com',01656378461,20000000),
('NV002',N'Nguyễn Thị Bảo Anh','CV006','15-10-1999',234324324,'Baoanh331@gmail.com',01653598443,10000000),
('NV003',N'Nguyễn Thị Bảo Trân','CV002','16-10-1999',215485344,'Baoanh332@gmail.com',01653223424,10000000),
('NV004',N'Nguyễn Thị Bảo Trân','CV003','17-10-1999',215485435,'Baoanh333@gmail.com',01653534567,10000000),
('NV005',N'Nguyễn Thị Bảo Ánh','CV004','18-10-1999',215445424,'Baoanh334@gmail.com',01654398421,10000000),
('NV006',N'Nguyễn Thị Bảo Phượng','CV005','19-10-1999',215488786,'Baoanh335@gmail.com',01653598342,15000000),
('NV007',N'Nguyễn Thị Bảo Ngọc','CV006','20-10-1999',215432444,'Baoanh336@gmail.com',01653564322,10000000),
('NV008',N'Nguyễn Thị Bảo Thanh','CV006','21-10-1999',215485746,'Baoanh337@gmail.com',01653324344,10000000),
('NV009',N'Nguyễn Thị Bảo Diệp','CV006','22-10-1999',215453243,'Baoanh338@gmail.com',01653534234,10000000),
('NV010',N'Nguyễn Thị Bảo Châu','CV006','23-10-1999',215488663,'Baoanh339@gmail.com',01653598764,10000000)


SET DATEFORMAT DMY
INSERT INTO HOA_DON(MaKH,MaNV,ThoiGian,GiamGia,TongTien) VALUES
('KH001','NV002','12-02-2020 12:00:00','15',850000),
('KH002','NV002','12-02-2020 11:00:00','20',1600000),
('KH003','NV002','12-02-2020 13:00:00','20',1600000),
('KH004','NV002','12-03-2020 12:00:00','20',1600000),
('KH005','NV002','15-04-2020 12:00:00','20',2500000),
('KH006','NV002','18-02-2020 12:00:00','20',1600000),
('KH007','NV002','14-02-2020 12:00:00','20',1600000),
('KH008','NV002','18-02-2020 12:00:00','20',3600000),
('KH009','NV002','17-02-2020 12:00:00','20',4600000),
('KH010','NV002','11-02-2020 12:00:00','20',7600000),
('KH011','NV002','25-02-2020 12:00:00','20',6600000),
('KH012','NV002','22-02-2020 12:00:00','20',5600000),
('KH013','NV002','21-02-2020 12:00:00','20',3200000),
('KH014','NV002','28-02-2020 12:00:00','20',1600000),
('KH015','NV002','25-02-2020 12:00:00','20',1300000),
('KH016','NV002','11-02-2020 12:00:00','20',1600000),
('KH017','NV002','12-03-2020 12:00:00','20',3200000),
('KH018','NV002','12-04-2020 12:00:00','20',3600000),
('KH019','NV002','12-07-2020 12:00:00','20',1995000),
('KH020','NV002','11-06-2020 12:00:00','20',1980000)

INSERT INTO CHI_TIET_HOA_DON(MaHD,MaSP,GiaVon,GiaBan,SoLuong) VALUES
(1,'SP001',250000,300000,1),
(2,'SP002',80000,100000,1),
(3,'SP003',250000,300000,1),
(4,'SP004',700000,800000,1),
(5,'SP005',250000,280000,1)

INSERT INTO DANG_NHAP(MaNV,TaiKhoan,MatKhau,TinhTrang) VALUES
('NV001','TKNV001','1',1),
('NV002','TKNV002','1',1),
('NV003','TKNV003','1',1),
('NV004','TKNV004','1',1),
('NV005','TKNV005','1',1),
('NV006','TKNV006','1',1),
('NV007','TKNV007','1',1),
('NV008','TKNV008','1',1),
('NV009','TKNV009','1',1),
('NV010','TKNV010','1',1)

INSERT INTO MAN_HINH(MaMH,TenMH) VALUES
('MH001',N'Sao lưu'),
('MH002',N'Đổi mật khẩu'),
('MH003',N'Phục hồi'),
('MH004',N'Nhật ký'),
('MH005',N'Phân quyền người dùng'),
('MH006',N'Quản lý người dùng'),
('MH007',N'Tổng quan bán hàng'),
('MH008',N'Các hoạt động gần đây'),
('MH009',N'Danh mục sản phẩm'),
('MH010',N'Thiết lập giá'),
('MH011',N'Kiểm kho'),
('MH012',N'Hóa đơn'),
('MH013',N'Trả hàng'),
('MH014',N'Nhập hàng'),
('MH015',N'Trả hàng nhập'),
('MH016',N'Xuất hủy'),
('MH017',N'Khách hàng'),
('MH018',N'Nhà cung cấp'),
('MH019',N'Sổ quỹ'),
('MH020',N'Báo cáo cuối ngày'),
('MH021',N'Báo cáo bán hàng'),
('MH022',N'Báo cáo đặt hàng'),
('MH023',N'Báo cáo hàng hóa'),
('MH024',N'Báo cáo khách hàng'),
('MH025',N'Báo cáo nhà cung cấp'),
('MH026',N'Báo cáo nhân viên'),
('MH027',N'Báo cáo tài chính'),
('MH028',N'Quét mã')

INSERT INTO NHOM_NGUOI_DUNG(MaNhom,TenNhom) VALUES
('NND001',N'Quản Lý'),
('NND002',N'Nhân viên bán hàng'),
('NND003',N'Nhân viên kho')

INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES
('NND001','MH001',1),
('NND001','MH002',1),
('NND001','MH003',1),
('NND001','MH004',1),
('NND001','MH005',1),
('NND001','MH006',1),
('NND001','MH007',1),
('NND001','MH008',1),
('NND001','MH009',1),
('NND001','MH010',1),
('NND001','MH011',1),
('NND001','MH012',1),
('NND001','MH013',1),
('NND001','MH014',1),
('NND001','MH015',1),
('NND001','MH016',1),
('NND001','MH017',1),
('NND001','MH018',1),
('NND001','MH019',1),
('NND001','MH020',1),
('NND001','MH021',1),
('NND001','MH022',1),
('NND001','MH023',1),
('NND001','MH024',1),
('NND001','MH025',1),
('NND001','MH026',1),
('NND001','MH027',1),
('NND001','MH028',0),
('NND002','MH001',0),
('NND002','MH002',1),
('NND002','MH003',0),
('NND002','MH004',0),
('NND002','MH005',0),
('NND002','MH006',0),
('NND002','MH007',0),
('NND002','MH008',0),
('NND002','MH009',0),
('NND002','MH010',0),
('NND002','MH011',0),
('NND002','MH012',0),
('NND002','MH013',0),
('NND002','MH014',0),
('NND002','MH015',0),
('NND002','MH016',0),
('NND002','MH017',0),
('NND002','MH018',0),
('NND002','MH019',0),
('NND002','MH020',0),
('NND002','MH021',0),
('NND002','MH022',0),
('NND002','MH023',0),
('NND002','MH024',0),
('NND002','MH025',0),
('NND002','MH026',0),
('NND002','MH027',0),
('NND002','MH028',1),
('NND003','MH001',0),
('NND003','MH002',1),
('NND003','MH003',0),
('NND003','MH004',0),
('NND003','MH005',0),
('NND003','MH006',0),
('NND003','MH007',0),
('NND003','MH008',0),
('NND003','MH009',0),
('NND003','MH010',0),
('NND003','MH011',1),
('NND003','MH012',0),
('NND003','MH013',0),
('NND003','MH014',0),
('NND003','MH015',0),
('NND003','MH016',0),
('NND003','MH017',0),
('NND003','MH018',0),
('NND003','MH019',0),
('NND003','MH020',0),
('NND003','MH021',0),
('NND003','MH022',0),
('NND003','MH023',0),
('NND003','MH024',0),
('NND003','MH025',0),
('NND003','MH026',0),
('NND003','MH027',0),
('NND003','MH028',0)

INSERT INTO NGUOI_DUNG_NHOM_NGUOI_DUNG(TaiKhoan,MaNhom) VALUES
('TKNV001','NND001'),
('TKNV002','NND002'),
('TKNV003','NND002'),
('TKNV004','NND002'),
('TKNV005','NND003'),
('TKNV006','NND003')

SET DATEFORMAT DMY
INSERT INTO PHIEU_KIEM_KHO(MaKiemKho,ThoiGian,TongChenhLech,MaNV,GhiChu,TrangThai) VALUES
('KK001','2020-01-01 00:39:13.000',2,'NV001',NULL,1),
('KK002','2020-01-02 00:39:13.000',5,'NV001',N'Thiếu Hàng',0)

INSERT INTO CHI_TIET_PHIEU_KIEM_KHO(MaKiemKho,MaSP,SoLuong,SoLuongThucTe,ChenhLech) VALUES
('KK001','SP001',4,3,1),
('KK001','SP002',12,12,0),
('KK001','SP003',4,4,0),
('KK001','SP004',5,5,0),
('KK001','SP005',13,12,1),
('KK002','SP001',3,-1,4),
('KK002','SP002',12,12,0),
('KK002','SP003',4,4,0),
('KK002','SP004',5,5,0),
('KK002','SP005',13,12,1)

INSERT INTO NHA_CUNG_CAP(MaNCC,TenNCC,MaSoThue,DiaChi,Email,SDT,TongTien) VALUES
('NCC001',N'Boshop','6456656543154',N'111B Nguyễn Lâm, Phường 3, Q.Bình Thạnh. TP.HCM',N'boshop92@gmail.com',19007101 ,0),
('NCC002',N'Wholemartcosmetic','6456656544321',N'335/1 Điện Biên Phủ, P.4, Q.3,TP.HCM',N'wholemart.cosmetic111@gmail.com', 0871099333 ,0),
('NCC003',N'Bigmamacosmetics','6452365927430',N'208 Nguyễn Hữu Cảnh, Quận Bình Thạnh, TP.HCM',N'bigmama@bigmamacosmetics.vn', 02866608100 ,0),
('NCC004',N'Abu','6456656578347',N'Shophouse,Hàm Nghi, Nam Từ Liêm, Hà Nội',N'myphamhanquochcm5@gmail.com',01687641999 ,0),
('NCC005',N'Myphamstar','6456651243457',N'Số 39/29 Đường Khương Hạ, Phường Khương Đình,Hà Nội',N'myphamstar@gmail.com',0981659986 ,0)

SET DATEFORMAT DMY
INSERT INTO PHIEU_NHAP(MaPN,MaNV,MaNCC,ThoiGian,GiamGia,TongTien) VALUES
('PN001','NV001','NCC001','2020-01-01',0,15000000),
('PN002','NV001','NCC002','2020-01-01',0,15000000),
('PN003','NV001','NCC003','2020-01-01',0,15000000)

INSERT INTO CHI_TIET_PHIEU_NHAP(MaPN,MaSP,GiaNhap,GiamGia,SoLuong) VALUES
('PN001','SP001',350000,0,50),
('PN001','SP002',800000,0,50),
('PN001','SP003',250000,0,50),
('PN001','SP004',700000,0,50),
('PN001','SP005',250000,0,50),
('PN002','SP001',350000,0,50),
('PN002','SP002',800000,0,50),
('PN002','SP003',250000,0,50),
('PN002','SP004',700000,0,50),
('PN003','SP001',350000,0,50),
('PN003','SP002',800000,0,50),
('PN003','SP003',700000,0,50)

INSERT INTO PHIEU_TRA_HANG_NHAP(MaPTN,MaNCC,MaNV) VALUES
('PN001','NCC001','NV001'),
('PN002','NCC002','NV001'),
('PN003','NCC003','NV001')

INSERT INTO CHI_TIET_PHIEU_TRA_HANG_BAN(MaPTB,MaSP,SoLuong) VALUES
('PTB001','SP001',10),
('PTB002','SP003',10),
('PTB003','SP004',10)

SET DATEFORMAT DMY
INSERT INTO PHIEU_TRA_HANG_BAN(MaPTB,MaHD,MaKH,MaNV,ChiPhi,TongTien,ThoiGian) VALUES
('PTB001',1,'KH001','NV001',200000,1000000,'2015-01-05 02:53:35.000'),
('PTB002',2,'KH002','NV001',200000,1000000,'2015-01-05 02:53:35.000'),
('PTB003',3,'KH003','NV001',200000,1000000,'2015-01-05 02:53:35.000'),
('PTB004',4,'KH004','NV001',200000,1000000,'2015-01-05 02:53:35.000'),
('PTB005',5,'KH005','NV001',200000,1000000,'2015-01-05 02:53:35.000')

INSERT INTO HOAT_DONG(MaHoatDong,MaNV,HoatDong,ThoiGian,GiaTri) VALUES
(1,'NV001',N'Nhập đơn hàng','2015-01-01 02:39:43.590',80000000),
(2,'NV001',N'Thiết lập giá sản phẩm SP001','2015-01-01 02:39:43.590',80000000),
(3,'NV001',N'Thiết lập giá sản phẩm SP002','2015-01-01 02:39:43.600',20000000),
(4,'NV001',N'Thiết lập giá sản phẩm SP003','2015-01-01 02:39:43.620',20000000),
(5,'NV001',N'Thiết lập giá sản phẩm SP004','2015-01-01 02:39:43.800',40000000)

select * from DANG_NHAP where TaiKhoan='TKNV001' and MatKhau='1'

