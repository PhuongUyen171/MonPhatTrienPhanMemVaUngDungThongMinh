-- TẠO DATABASE --
CREATE DATABASE QLShopMP
USE QLShopMP
GO
---------------------TẠO BẢNG -----------------------

CREATE TABLE THE_LOAI_SAN_PHAM
(
	MaLoaiSP varchar(5) PRIMARY KEY,
	TenLoaiSP nvarchar(30)
)

CREATE TABLE THUONG_HIEU
(
	MaTH varchar(5),
	TenTH nvarchar(50),
	Images nvarchar(150)DEFAULT N'KoXacDinh.jpg',
	CONSTRAINT PK_THIEU PRIMARY KEY(MaTH)
)

CREATE TABLE SAN_PHAM
(
	MaSP varchar(5) PRIMARY KEY,
	MaLoaiSP varchar(5),
	TenSP nvarchar(100),
	DonViTinh nvarchar(10),
	SoLuong int check (SoLuong >=0),
	GiaBan money check (GiaBan >=0),
	GiaVon money check (GiaVon >=0),
	TrangThai bit,
	HinhAnh nvarchar(150),
	MoTa nvarchar(max),
	MaTH varchar(5),
	FOREIGN KEY(MaLoaiSP) REFERENCES THE_LOAI_SAN_PHAM(MaLoaiSP),
	FOREIGN KEY(MaTH) REFERENCES THUONG_HIEU(MaTH)
)

CREATE TABLE CHI_TIET_PHIEU_TRA_HANG_NHAP
(
	MaPTN varchar(5) NOT NULL,
	MaSP varchar(5) NOT NULL,
	SoLuong int check (SoLuong >=0),
	GiaTra money check (GiaTra >=0),
	PRIMARY KEY(MaPTN,MaSP),
	FOREIGN KEY(MaSP) REFERENCES SAN_PHAM(MaSP)
)

CREATE TABLE CHUC_VU
(
	MaCV varchar(5) PRIMARY KEY,
	TenCV nvarchar(30),
	Luong money
)

CREATE TABLE LOAI_KHACH_HANG
(
	MaLoaiKH varchar(5) PRIMARY KEY,
	TenLoaiKH nvarchar(30),
	GioiHanDuoi money check (GioiHanDuoi >=0),
	GioiHanTren money check (GioiHanTren >=0),
	GiamGia int check (GiamGia >=0)
)

CREATE TABLE KHACH_HANG
(
	MaKH varchar(5)  not null,
	TaiKhoan varchar(50),
	Pass varchar(50),
	TenKH nvarchar(30),
	MaLoaiKH varchar(5),
	NgaySinh DATE CHECK(NgaySinh< GETDATE()),
	NgayDangKy DATE ,
	CMND char(12),
	Email nvarchar(max) DEFAULT N'Chưa xác định',
	SDT  char(11),
	DiaChi nvarchar(max) DEFAULT N'Chưa xác định',
	TongTienMua money,
	PRIMARY KEY (MaKH),
	FOREIGN KEY(MaLoaiKH) REFERENCES LOAI_KHACH_HANG(MaLoaiKH)	
)

CREATE TABLE NHAN_VIEN
(
	MaNV varchar(5)  PRIMARY KEY,
	TenNV nvarchar(30),
	MaCV varchar(5),
	NgaySinh date CHECK(NgaySinh< GETDATE()),
	CMND char(12),
	Email nvarchar(max) DEFAULT N'Chưa xác định',
	SDT char(11) DEFAULT N'Chưa xác định',
	Luong money check(Luong >=0),
	FOREIGN KEY(MaCV) REFERENCES CHUC_VU(MaCV)
)

CREATE TABLE HOA_DON
(	
	MaHD INT IDENTITY(1,1)  PRIMARY KEY,
	MaKH varchar(5),
	MaNV varchar(5),
	ThoiGian datetime DEFAULT GETDATE(),
	GiamGia int check(GiamGia >=0),
	TongTien money,
	FOREIGN KEY(MaNV) REFERENCES NHAN_VIEN(MaNV),
	FOREIGN KEY(MaKH) REFERENCES KHACH_HANG(MaKH)
)

CREATE TABLE CHI_TIET_HOA_DON
(
	MaHD int NOT NULL,
	MaSP varchar(5)  NOT NULL,
	GiaVon money check(GiaVon >=0),
	GiaBan money check(GiaBan >=0),
	SoLuong int  check(SoLuong >=0),
	PRIMARY KEY(MaHD,MaSP),
	FOREIGN KEY(MaHD) REFERENCES HOA_DON(MaHD),
	FOREIGN KEY(MaSP) REFERENCES SAN_PHAM(MaSP)
)

CREATE TABLE DANG_NHAP
(
	MaNV varchar(5),
	TaiKhoan varchar(22)  PRIMARY KEY,
	MatKhau varchar(100),
	TinhTrang bit,
	FOREIGN KEY(MaNV) REFERENCES NHAN_VIEN(MaNV)
)

CREATE TABLE MAN_HINH
(
	MaMH varchar(5) PRIMARY KEY,
	TenMH nvarchar(50)
)

CREATE TABLE NHOM_NGUOI_DUNG
(
  MaNhom varchar(5) PRIMARY KEY,
  TenNhom nvarchar(30)
)

CREATE TABLE PHAN_QUYEN
(
	MaNhom varchar(5) NOT NULL,
	MaMH varchar(5) NOT NULL,
	CoQuyen bit,
	PRIMARY KEY(MaNhom,MaMH),
	FOREIGN KEY(MaNhom) REFERENCES NHOM_NGUOI_DUNG(MaNhom),
	FOREIGN KEY(MaMH) REFERENCES MAN_HINH(MaMH)
)

CREATE TABLE NGUOI_DUNG_NHOM_NGUOI_DUNG
(
	TaiKhoan varchar(22) PRIMARY KEY,
	MaNhom varchar(5),
	FOREIGN KEY(MaNhom) REFERENCES NHOM_NGUOI_DUNG(MaNhom),
	FOREIGN KEY(TaiKhoan) REFERENCES DANG_NHAP(TaiKhoan)
)

CREATE TABLE PHIEU_KIEM_KHO
(
	MaKiemKho varchar(5) PRIMARY KEY,
	ThoiGian datetime DEFAULT GETDATE(),
	TongChenhLech int,
	MaNV varchar(5),
	GhiChu nvarchar(200),
	TrangThai bit,
	FOREIGN KEY(MaNV) REFERENCES NHAN_VIEN(MaNV)
)

CREATE TABLE CHI_TIET_PHIEU_KIEM_KHO
(
	MaKiemKho varchar(5) NOT NULL,
	MaSP varchar(5) NOT NULL,
	SoLuong int CHECK (SoLuong >=0),
	SoLuongThucTe int,
	ChenhLech int,
	PRIMARY KEY(MaKiemKho,MaSP),
	FOREIGN KEY(MaKiemKho) REFERENCES PHIEU_KIEM_KHO(MaKiemKho),
	FOREIGN KEY(MaSP) REFERENCES SAN_PHAM(MaSP)
)

CREATE TABLE NHA_CUNG_CAP
(
	MaNCC varchar(5) PRIMARY KEY,
	TenNCC nvarchar(70),
	MaSoThue char(13),
	DiaChi nvarchar(max),
	Email nvarchar(max),
	SDT char(11),
	TongTien money
)

CREATE TABLE PHIEU_NHAP
(
	MaPN varchar(5) PRIMARY KEY,
	MaNV varchar(5),
	MaNCC varchar(5),
	ThoiGian date DEFAULT GETDATE(),
	GiamGia int check(GiamGia >=0),
	TongTien money,
	FOREIGN KEY(MaNCC) REFERENCES NHA_CUNG_CAP(MaNCC),
	FOREIGN KEY(MaNV) REFERENCES NHAN_VIEN(MaNV)
)

CREATE TABLE CHI_TIET_PHIEU_NHAP
(
	MaPN varchar(5)  NOT NULL,
	MaSP varchar(5)  NOT NULL,
	GiaNhap money,
	GiamGia int,
	SoLuong int ,
	PRIMARY KEY(MaPN,MaSP),
	FOREIGN KEY(MaPN) REFERENCES PHIEU_NHAP(MaPN),
	FOREIGN KEY(MaSP) REFERENCES SAN_PHAM(MaSP)
)

CREATE TABLE PHIEU_TRA_HANG_NHAP
(
	MaPTN varchar(5) PRIMARY KEY,
	MaNCC varchar(5),
	MaNV varchar(5),
	FOREIGN KEY(MaNCC) REFERENCES NHA_CUNG_CAP(MaNCC),
	FOREIGN KEY(MaNV) REFERENCES NHAN_VIEN(MaNV)
)

CREATE TABLE CHI_TIET_PHIEU_TRA_HANG_BAN
(
	MaPTB varchar(5)  NOT NULL,
	MaSP varchar(5)  NOT NULL,
	SoLuong int check (SoLuong >=0),
	PRIMARY KEY(MaPTB,MaSP),
	FOREIGN KEY(MaSP) REFERENCES SAN_PHAM(MaSP)
)

CREATE TABLE PHIEU_TRA_HANG_BAN
(
	MaPTB varchar(5) PRIMARY KEY,
	MaHD int,
	MaNV varchar(5),
	MaKH varchar(5),
	ChiPhi money check (ChiPhi >=0),
	TongTien money check (TongTien >=0),
	ThoiGian datetime,
	FOREIGN KEY(MaHD) REFERENCES HOA_DON(MaHD)
)

CREATE TABLE HOAT_DONG
(
	MaHoatDong varchar(5) PRIMARY KEY,
	MaNV varchar(5),
	HoatDong nvarchar(30),
	ThoiGian datetime,
	GiaTri money check (GiaTri >=0),
	FOREIGN KEY(MaNV) REFERENCES NHAN_VIEN(MaNV)
)
CREATE TABLE TIN
(
	MaTin int primary key,
	TieuDe nvarchar(max),
	Hinh nvarchar(max),
	Ngay datetime,
	TomTat nvarchar(max)
)


--=============== TAO RANG BUOC TOAN VEN ==========================--
--Cap nhat tong tien =SoLuong * GiaBan * (1-GiamGia/100)
GO
CREATE TRIGGER TRG_TongTienHD ON CHI_TIET_HOA_DON
FOR INSERT, UPDATE
AS
	BEGIN
	UPDATE HOA_DON SET TongTien =(Select SUM(SoLuong* GiaBan) *(1-GiamGia/100.0) From CHI_TIET_HOA_DON
						WHERE MaHD=(Select MaHD From inserted))
				 Where MaHD=(Select MaHD From inserted)
	UPDATE HOA_DON SET TongTien =(Select SUM(SoLuong* GiaBan) *(1-GiamGia/100.0) From CHI_TIET_HOA_DON
						WHERE MaHD=(Select MaHD From deleted))
				 Where MaHD=(Select MaHD From deleted)

	END;
--Trigger Cap nhat tong tien trong Phieu Nhap: TongTien=SoLuong* GiaNhap -GiamGia
GO
--CREATE TRIGGER TRG_TongTienNhap ON CHI_TIET_PHIEU_NHAP
--FOR INSERT, UPDATE
--AS
--BEGIN
--	UPDATE PHIEU_NHAP 
--	SET TongTien =(Select SUM(SoLuong* GiaNhap) *(1-GiamGia/100.0)
--	               From CHI_TIET_PHIEU_NHAP
--				   WHERE MaPN=(Select MaPN From inserted))
--	WHERE MaPN=(Select MaPN From inserted)
--	UPDATE PHIEU_NHAP
--	SET TongTien =(Select SUM(SoLuong* GiaNhap)*(1-GiamGia/100.0)
--	               From CHI_TIET_PHIEU_NHAP
--				   WHERE MaPN=(Select MaPN From deleted))
--	WHERE MaPN=(Select MaPN From deleted)
--END;
--=======================================================================--
--Kiem tra tuoi cua NHANVIEN  moi vao cua hang phai lon hon >=18
--GO
--CREATE TRIGGER KIEMTRA_TUOI ON NHAN_VIEN
--FOR INSERT 
--AS
--	BEGIN
--		DECLARE @TUOI INT
--		SET @TUOI=(SELECT YEAR(GETDATE())-YEAR(NgaySinh) AS 'TUOI' FROM INSERTED )
--		IF(@TUOI<18)
--		BEGIN
--			PRINT 'Tuoi cua nhan vien phai lon hon hoac bang 18'
--		END
--		ELSE
--		BEGIN
--			PRINT 'Thanh cong!'
--		END
--	END;
--============================================================--
--Cap nhat lai so luong ton cua san pham trong kho hang khi co đơn đặt hàng
GO
CREATE TRIGGER CAPNHAT_SOLUONGTON ON CHI_TIET_HOA_DON
FOR INSERT 
AS
	BEGIN
		UPDATE SAN_PHAM
		SET SoLuong=SAN_PHAM.SoLuong-(SELECT SoLuong FROM INSERTED WHERE MaSP=SAN_PHAM.MaSP)
		FROM SAN_PHAM
		JOIN inserted ON SAN_PHAM.MaSP=inserted.MaSP
	END;
--=========
--======================= NHAP LIEU ==================--

INSERT INTO TIN(MaTin,TieuDe,Hinh,Ngay,TomTat) VALUES (1, N'Trang điểm đẹp đêm noel lung linh cho các nàng tự tin dạo phố', N'Trang Điểm Noel.JPG', CAST(0x5F400B00 AS Date), N'Noel đã gần tới rồi. Bạn đã có ý tưởng gì để trang điểm đêm noel chưa? Chắc hẳn các bạn gái ai cũng muốn mình thật xinh đẹp và ấn tượng trong đêm Giáng sinh ngọt ngào đúng không nào? Hãy khám phá ngay bài viết dưới để tạo riêng cho mình một phong cách trang điểm đi chơi Giáng sinh thật lung linh và có thêm thật nhiều bức hình "sống ảo" cực đẹp và ưng ý bạn nhé!Để có diện mạo thật tươi tắn, rạng rỡ, chúng ta không cứ chỉ được đánh son đỏ, son hồng mà có thể chọn những màu son nhạt hơn, như cam chẳng hạn.

Trọng tâm của kiểu makeup này chính là lớp nền trong veo, căng mướt tự nhiên như đẹp sẵn kết hợp với môi-mắt-má ton-sur-ton gam cam đất xinh đẹp, ấn tượng mà tươi trẻ.

Để tạo được lớp nền căng bóng trong veo, bạn nên chọn kem nền lỏng có nhũ ngọc trai. Để lớp nền được bền màu và kiềm dầu tốt hơn, bí quyết là bạn hãy phủ một lớp phấn thật nhẹ lên vùng T-zone và hai bên cánh mũi.Với đôi mắt, chúng ta chỉ cần sử dụng đúng một gam màu nâu cam để tạo chiều sâu và kẻ thêm eyeliner màu nâu để tạo điểm nhấn cho mắt thôi, quá đơn giản phải không nào?

Phấn má màu cam không chỉ tạo nên tổng thể hài hòa, thống nhất cho khuôn mặt mà còn là bí kíp "đinh" giúp da mặt không bị nhợt nhạt khi tô son màu cam đất.

Những kiểu trang điểm trên tuy đơn giản mà nổi bật, phù hợp với không khí Noel, chắc chắn sẽ giúp cho các nàng trở nên xinh đẹp hơn tự tin dạo phố và "sống ảo" thôi nè. Chúc bạn chuẩn bị tốt cho một đêm Giáng sinh an lành nhé.')
INSERT INTO TIN(MaTin,TieuDe,Hinh,Ngay,TomTat) VALUES (2,N'Những bí quyết và quy trình chăm sóc da mặt cho nam', N'TIN2.JPG', CAST(0x5F400B00 AS Date), N'Da của nam và nữ không già đi một cách giống nhau. Da nam giới được bảo vệ bởi sự điều tiết chất làm se da, collagen và lớp biểu bì dày. Vì thế nếp nhăn thường xuất hiện trễ hơn, đôi khi đến tận 50 tuổi, dù vậy chúng lại thường sâu hơn nhiều so với phụ nữ.

Những nguyên nhân khiến da xuất hiện nếp nhăn và bị lão hoá (bên cạnh những nhân tố đã nêu ra ở bài viết trước) nằm ở cách biểu đạt cảm xúc, giấc ngủ và thiếu hụt sự chăm sóc da.

Bên cạnh kem chống lão hoá, chăm sóc da bình thường cũng có thể giúp đẩy lùi những dấu hiệu của tuổi tác. Hãy tìm kiếm những loại sữa rửa mặt, nước hoa hồng và kem dưỡng ẩm đáng tin cậy và phù hợp với loại da.

Nếu bạn có da dầu, hãy chọn những sản phẩm không có chứa dầu vì chúng có thể thúc đẩy quá trình sản sinh và khiến da mặt bóng nhờn hơn. Rửa sạch, thoa nước hoa hồng và dưỡng ẩm da mỗi ngày. Đừng bao giờ đi ngủ mà bỏ qua những bước quan trọng này nhé!')
INSERT INTO TIN(MaTin,TieuDe,Hinh,Ngay,TomTat) VALUES (3,N'101 Tips làm đẹp dành cho nam giới (Phần 1)', N'TIN3.JPG', CAST(0x5F400B00 AS Date), N'1. Đối với một số người đàn ông, bộ râu chính là nét quyến rũ độc đáo của họ nhưng với số khác thì nó lại trông như một thảm hoạ. Nếu râu mọc lộn xộn hay không đều màu thì tốt nhất bạn nên cạo đi thật sạch sẽ.

2. Đừng ngại sử dụng kem che khuyết điểm để che đi những điểm không hoàn hảo trên gương mặt, việc này không giống như thoa son, kẻ mắt hay đánh má hồng. Chỉ đơn giản là có mụn thì ai mà chẳng muốn giấu đi.

3. Bắt đầu sử dụng kem dưỡng ẩm mỗi ngày để duy trì làn da khoẻ mạnh. Cả đàn ông lẫn phụ nữ đều sẽ có nếp nhăn nên không lí do gì để không chăm sóc da đang dần lão hoá.

4. Rửa mặt bằng sữa rửa mặt thay vì xà phòng dùng cho thân thể sẽ giúp bạn có làn da khoẻ và ít mụn hơn. 

5. Bọng mắt chính là dấu hiệu của việc nghỉ ngơi không đầy đủ, hãy ngủ một giấc 8 tiếng mỗi ngày để thức dậy thật tươi mới và sảng khoái nhé!

6. Nếu bạn vẫn gặp phải những bọng mắt gây khó chịu đó, hãy thử thoa một ít Preparation H, công dụng vô cùng thần kì!

7. Khi định đi ra ngoài nắng, bạn hãy nhớ đeo kính mát. Nó sẽ giúp bạn không phải nheo mắt và giảm khả năng xuất hiện nếp nhăn.

8. Nếu da mặt trơn nhẵn (không có râu) thì bạn có thể đánh một chút kem nền không chứa dầu hoặc phấn phủ không màu để da mặt không bị đổ dầu nhé!')
INSERT INTO TIN(MaTin,TieuDe,Hinh,Ngay,TomTat) VALUES (4,N'5 bước trang điểm mắt một mí cực kỳ đơn giản không phải ai cũng biết?', N'TIN4.JPG', CAST(0x5F400B00 AS Date), N'Sở hữu đôi mắt mí lẩn hay mắt một mí khiến nhiều chị em tự ti, nhưng nét đẹp ấy mới khó lẫn lộn giữa rừng những cô nàng từng phẫu thuật nhấn mí. Tại sao không học cách trang điểm mắt một mí cho thật nổi bật và lộng lẫy như các sao Hàn nhỉ. Bởi chỉ cần vài thao tác đơn giản cùng với sự kết hợp khéo léo một số mỹ phẩm trang điểm mắt như mi giả, phấn mắt, bút kẻ mắt là chúng ta đã trang điểm được một đôi mắt to tròn, long lanh và đầy sức cuốn hút.')
INSERT INTO TIN(MaTin,TieuDe,Hinh,Ngay,TomTat) VALUES (5,N'Các bước trang điểm tự nhiên và đơn giản cần những gì?', N'TIN5.JPG', CAST(0x5F400B00 AS Date), N'Các bước trang điểm tự nhiên và đơn giản cần những gì? Vì trang điểm đẹp là nhu cầu cần thiết của chị em mỗi khi đi chơi, dạo phố hay trang điểm tự nhiên và đơn giản là xu hướng chung của rất nhiều chị em khi đi đám cưới, dự tiệc. Chỉ cần vài bước nhỏ bạn sẽ có gương mặt tươi sáng, tự tin và thu hút ánh nhìn từ đối phương. Nghe tưởng đơn giản nhưng nếu với những cô nàng lần đầu làm đẹp thì chắc hẳn sẽ không hề dễ. Ngay bây giờ hãy cùng chúng tôi xem ngay các bước trang điểm đơn giản nhưng đẹp nhẹ nhàng và tự nhiên nhé!')
INSERT INTO TIN(MaTin,TieuDe,Hinh,Ngay,TomTat) VALUES (6,N'Tư vấn các bước trang điểm công sở đẹp tự nhiên và nhẹ nhàng', N'TIN6.JPG', CAST(0x5F400B00 AS Date), N'Trang điểm công sở nhiệm vụ quan trọng. Ngay từ hôm nay, hãy bắt đầu tạo cho mình thói quen trang điểm hằng ngày để lúc nào cũng xinh tươi, tràn đầy sức sống như cô nàng BOSHOP nhé. Hãy bỏ thói quen suy nghĩ trang điểm khi đi làm không cần thiết, mất nhiều thời gian hay không tốt cho da,... Nếu nó giúp bạn sự tự tin, đẹp nhẹ nhàng và thu hút ánh nhìn của đối tác, đồng nghiệp thì bạn có thích? Tư vấn các bước trang điểm công sở đơn giản, đẹp tự nhiên bạn nên tham khảo.')
INSERT INTO TIN(MaTin,TieuDe,Hinh,Ngay,TomTat) VALUES (7,N'6 bí quyết chăm sóc da ngăn ngừa tác hại khi nước bị nhiễm styrene', N'TIN7.JPG', CAST(0x5F400B00 AS Date), N'Theo Cơ Quan Bảo Vệ Môi Trường Mỹ, Styrene nằm trong danh mục những Chất gây ô nhiễm không khí độc hại. Khi ngấm vào nước nó sẽ nhanh chóng bay hơi hoặc phân hủy do hoạt động của vi khuẩn. Styrene có thể gây ra nhiều vấn đề về sức khỏe, thậm chí có thể phá hủy gan, các mô thần kinh, dẫn tới ung thư và nhiều bệnh lý nghiêm trọng về da. Nhưng hiện tại "Chất Độc" đang tồn đọng trong nguồn nước sinh hoạt tại Việt Nam và đã ở ngưỡng dư thừa từ 1,3-3,65 lần, liệu sức khỏe và làn da của chúng ta có chịu nổi sức ép kinh hoàng đó không? Cùng Boshop thực hiện ngay 6 bí quyết chăm sóc da an toàn ngăn ngừa tác hại khi nước bị nhiễm styrene. ')
INSERT INTO TIN(MaTin,TieuDe,Hinh,Ngay,TomTat) VALUES (8,N'Nghệ và 10 công dụng làm đẹp bạn đã biết chưa?', N'TIN8.JPG', CAST(0x5F400B00 AS Date), N'Vốn được xem là một gia vị không thể thiếu tại Ấn Độ, củ nghệ còn được sử dụng như một loại “thần dược” để dưỡng da và làm đẹp với công dụng kháng khuẩn, chống viêm, loại nấm, trị mụn, sáng da và hàng tỉ thứ hiệu quả khác.
Nhưng vấn đề chính là: nghệ có nhiều công dụng thần kỳ như vậy nhưng bạn đã biết cách tận dụng nó chưa? Nếu câu trả lời của bạn là chưa hoặc không biết thì ngay hôm nay, hãy cùng Bo Shop khám phá ngay 10 công dụng làm đẹp của nghệ ngay trong bài viết này nha!')
INSERT INTO TIN(MaTin,TieuDe,Hinh,Ngay,TomTat) VALUES (9,N'Giảm cân kiểu Low Carb và thực đơn chuẩn', N'TIN9.JPG', CAST(0x5F400B00 AS Date), N'Mùa tết vừa qua, chắc hẳn không ít thì nhiều các chị em phụ nữ cũng đã lên thêm vài ký. Vậy nên hãy cùng giảm cân an toàn, lành mạnh và hiệu quả cùng chế độ ăn kiêng low carb đang làm mưa làm gió trong thời gian vừa qua. Đây là một là một chế độ ăn uống hạn chế carbohydrate, đó là chất được tìm thấy trong thực phẩm có đường, mì ống và bánh mì,… chế độ ăn kiêng low carb này đòi hỏi một lượng cao chất đạm, chất béo và rau quả lành mạnh.

Chế độ ăn kiêng low carb này có rất nhiều kiểu khác nhau, và các nghiên cứu cho thấy rằng nó có thể giúp giảm cân và cải thiện sức khỏe. Bên dưới chính là một kế hoạch bữa ăn chi tiết cho chế độ ăn uống low carb. Những gì nên ăn, những gì nên tránh và một menu low carb mẫu cho một tuần.')
INSERT INTO TIN(MaTin,TieuDe,Hinh,Ngay,TomTat) VALUES (10,N'5 tinh chất dưỡng ẩm cho da hiệu quả nhất từ nguyên liệu tự nhiên', N'TIN10.JPG', CAST(0x5F400B00 AS Date), N'Chăm sóc da có nhiều cách nhưng bổ sung dưỡng chất và áp dụng các phương pháp dùng tinh chất dưỡng ẩm cho da thường xuyên từ nguyên liệu tự nhiên là điều cần thiết.
Vừa an toàn, lại không lo ngại về các thành phần hóa học, phẩm màu hay chất tạo hương tổng hợp như dùng các loại mỹ phẩm, thực phẩm chức năng… ')
INSERT INTO TIN(MaTin,TieuDe,Hinh,Ngay,TomTat) VALUES (11,N'Top 7 loại thức ăn nuôi cơ dành cho nam giới', N'TIN11.JPG', CAST(0x5F400B00 AS Date), N'Tăng cơ bắp, xây dựng hay làm sắc nét cơ là những gì mà cánh mày râu thường chú tâm để ý, tuy nhiên không phải chàng trai nào cũng thực sự biết được cách tăng cơ bắp cho body của mình.
Sự phát triển của cơ bắp cần có một công thức bao gồm uống nhiều nước và ăn nhiều thức ăn giàu năng lượng bên cạnh việc chăm chỉ rèn luyện. Với công thức đúng đắn này, bạn sẽ rút ngắn quãng đường chạm đến một cơ thể tuyệt vời.')
INSERT INTO TIN(MaTin,TieuDe,Hinh,Ngay,TomTat) VALUES (12,N'101 Tips làm đẹp dành cho nam giới (Phần 2)', N'TIN12.JPG', CAST(0x5F400B00 AS Date), N'“Làm đẹp dành cho nam giới” với 101 tip đã quay trở lại với phần 2 để “mách” cho các bạn thêm nhiều bí quyết khác để chăm sóc môi, răng và tóc.Làm đẹp cho nam giới không quá khó, và nó hoàn toàn đơn giản nếu như bạn biết được những điều sau đây và bắt đầu chăm sóc từng phần như răng, tóc ....')


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

SET DATEFORMAT DMY
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
('PTN01','SP001',1,250000),
('PTN02','SP002',1,80000)


INSERT INTO CHUC_VU(MaCV,TenCV,Luong) VALUES
('CV001',N'Quản lý trưởng',10000000),
('CV002',N'Nhân viên thu ngân',6000000),
('CV003',N'Thủ kho',6000000),
('CV004',N'Nhân viên tư vấn',6000000),
('CV005',N'Quản lý chi nhánh',8000000),
('CV006',N'Nhân viên bán hàng',6000000),
('CV007',N'Nhân viên giao hàng',6000000)

INSERT INTO LOAI_KHACH_HANG(MaLoaiKH,TenLoaiKH,GioiHanDuoi,GioiHanTren,GiamGia) VALUES
('LKH01',N'Đồng',0,4999999,0),
('LKH02',N'Bạc',5000000,9999999,5),
('LKH03',N'Vàng',10000000,19999999,10),
('LKH04',N'Bạch Kim',20000000,49999999,15),
('LKH05',N'Kim Cương',50000000,999999999,20)


SET DATEFORMAT DMY
INSERT INTO KHACH_HANG(MaKH,TenKH,MaLoaiKH,NgaySinh,NgayDangKy,CMND,Email,SDT,DiaChi,TongTienMua,TaiKhoan,Pass) VALUES
('KH001',N'Nguyễn Xuân Nhật','LKH04','26-10-2000','01-01-2020',215766247,'xuannhat111222@gmail.com',01548648562,N'72/34 Dương Đức Hiền,Quận Tân Phú',1000000,'TK001','1'),
('KH002',N'Nguyễn Phương Uyên','LKH05','12-01-1999','01-01-2020',215445335,'phuonguyen111222@gmail.com',01236865475,N'Số 11,Quận Bình Tân',2000000,'TK002','1'),
('KH003',N'Nguyễn Phương Trúc','LKH05','17-02-2000','01-01-2020',215032335,'phuongtruc111222@gmail.com',02585348523,N'Số 11,Quận 7',2500000,'TK003','1'),
('KH004',N'Nguyễn Nhã Uyên','LKH01','15-03-1998','01-01-2020',215729335,'nhauyen111222@gmail.com',02586577773,N'Số 311,Quận Bình Tân',2600000,'TK004','1'),
('KH005',N'Nguyễn Kiều Phi','LKH02','14-04-1997','01-01-2020',215545335,'kieuphi111222@gmail.com',02586563443,N'Số 141,Quận 2',2100000,'TK005','1'),
('KH006',N'Nguyễn Mỹ Nương','LKH03','17-05-1994','01-01-2020',214255335,'mynuong111222@gmail.com',02586543453,N'Số 411,Quận 5',3000000,'TK006','1'),
('KH007',N'Nguyễn Tâm Như','LKH04','27-06-1994','01-01-2020',215765335,'tamnhu121222@gmail.com',02586545555,N'Số 111,Quận Bình Tân',4000000,'TK007','1'),
('KH008',N'Nguyễn Tú Anh','LKH05','24-07-1996','01-01-2020',215425735,'tuanh113222@gmail.com',02586549977,N'Số 1311,Quận 4',7000000,'TK008','1'),
('KH009',N'Nguyễn Tuyết Anh','LKH01','22-08-1996','01-01-2020',227545335,'tuyetanh241222@gmail.com',02586546754,N'Số 131,Quận Bình Tân',3500000,'TK009','1'),
('KH010',N'Nguyễn Hồng Phương','LKH02','17-09-1995','01-01-2020',247445335,'hongphuong11222@gmail.com',02586746523,N'Số 11,Quận 7',6000000,'TK010','1'),
('KH011',N'Nguyễn Thúy An','LKH03','5-10-1997','01-01-2020',215473635,'thuyan111222@gmail.com',02586541243,N'Số 1211,Quận Thủ Đức',2500000,'TK011','1'),
('KH012',N'Nguyễn Phỉ Thúy','LKH04','4-11-1994','01-01-2020',215275335,'phithuy111222@gmail.com',02586547546,N'Số 131,Quận 1',2900000,'TK012','1'),
('KH013',N'Nguyễn Khánh Vi','LKH05','17-12-1996','01-01-2020',215567335,'khanhvi111222@gmail.com',02586542574,N'Số 121,Quận 8',2400000,'TK013','1'),
('KH014',N'Nguyễn Kiều Hạnh','LKH01','17-01-1993','01-01-2020',214785335,'kieuhanh111222@gmail.com',0258655674,N'Số 211,Quận Bình Tân',3600000,'TK014','1'),
('KH015',N'Nguyễn Kiều Trang','LKH02','13-01-1999','01-01-2020',228545335,'kieutrang111222@gmail.com',02586545763,N'Số 161,Quận Bình Chánh',1000000,'TK015','1'),
('KH016',N'Nguyễn Yến Nhi','LKH03','18-01-1995','01-01-2020',215457835,'yennhi111222@gmail.com',02586456797,N'Số 311,Quận Bình Tân',5000000,'TK016','1'),
('KH017',N'Nguyễn Huyền Trân','LKH04','15-01-1996','01-01-2020',248545335,'huyentran111222@gmail.com',0258642344,N'Số 211,Quận 3',4000000,'TK017','1'),
('KH018',N'Nguyễn Châu Liên','LKH05','19-04-1998','01-01-2020',213955335,'chaulien111222@gmail.com',02586436754,N'Số 91,Quận 10',4500000,'TK018','1'),
('KH019',N'Nguyễn Yến Linh','LKH01','20-07-1999','01-01-2020',215285335,'yenlinh111222@gmail.com',02584328523,N'Số 18,Quận 12',2100000,'TK019','1'),
('KH020',N'Nguyễn Khánh Như','LKH02','29-09-1998','01-01-2020',211705335,'khanhnhu111222@gmail.com',02586542332,N'Số 11,Quận 11',2200000,'TK020','1')

SET DATEFORMAT DMY
INSERT INTO NHAN_VIEN(MaNV,TenNV,MaCV,NgaySinh,CMND,Email,SDT,Luong) VALUES
('NV001',N'Nguyễn Thị Nhã Hân','CV001','14-12-1998',215787329,'Hanhan332@gmail.com',01656378461,10000000),
('NV002',N'Nguyễn Thị Bảo Anh','CV006','15-10-1996',234324324,'Baoanh331@gmail.com',01653598443,6000000),
('NV003',N'Nguyễn Thị Bảo Trân','CV002','16-10-1994',215485344,'Baoanh332@gmail.com',01653223424,6000000),
('NV004',N'Nguyễn Thị Bảo Trân','CV003','12-8-1995',215485435,'Baoanh333@gmail.com',01653534567,6000000),
('NV005',N'Nguyễn Thị Bảo Ánh','CV004','18-10-1997',215445424,'Baoanh334@gmail.com',01654398421,6000000),
('NV006',N'Nguyễn Thị Bảo Phượng','CV005','19-10-1997',215488786,'Baoanh335@gmail.com',01653598342,8000000),
('NV007',N'Nguyễn Thị Bảo Ngọc','CV006','20-10-1998',215432444,'Baoanh336@gmail.com',01653564322,6000000),
('NV008',N'Nguyễn Thị Bảo Thanh','CV006','21-10-1993',215485746,'Baoanh337@gmail.com',01653324344,6000000),
('NV009',N'Nguyễn Thị Bảo Diệp','CV006','22-10-1995',215453243,'Baoanh338@gmail.com',01653534234,6000000),
('NV010',N'Nguyễn Thị Bảo Châu','CV006','23-10-1994',215488663,'Baoanh339@gmail.com',01653598764,6000000)

select * from NHAN_VIEN
SET DATEFORMAT DMY
INSERT INTO HOA_DON(MaKH, MaNV, ThoiGian, GiamGia) VALUES('KH001','NV002','12-02-2020 12:00:00',15);
INSERT INTO HOA_DON(MaKH, MaNV, ThoiGian, GiamGia) VALUES('KH002','NV003','12-02-2020 11:00:00',20);
INSERT INTO HOA_DON(MaKH, MaNV, ThoiGian, GiamGia) VALUES('KH003','NV003','12-02-2020 13:00:00',30);
INSERT INTO HOA_DON(MaKH, MaNV, ThoiGian, GiamGia) VALUES('KH004','NV003','12-03-2020 12:00:00',50);
INSERT INTO HOA_DON(MaKH, MaNV, ThoiGian, GiamGia) VALUES('KH005','NV003','15-04-2020 12:00:00',30);
INSERT INTO HOA_DON(MaKH, MaNV, ThoiGian, GiamGia) VALUES('KH006','NV003','18-02-2020 12:00:00',30);
INSERT INTO HOA_DON(MaKH, MaNV, ThoiGian, GiamGia) VALUES('KH007','NV003','14-02-2020 12:00:00',30);
INSERT INTO HOA_DON(MaKH, MaNV, ThoiGian, GiamGia) VALUES('KH008','NV003','18-02-2020 12:00:00',20);
INSERT INTO HOA_DON(MaKH, MaNV, ThoiGian, GiamGia) VALUES('KH009','NV003','17-02-2020 12:00:00',100);
INSERT INTO HOA_DON(MaKH, MaNV, ThoiGian, GiamGia) VALUES('KH010','NV003','11-02-2020 12:00:00',100);
INSERT INTO HOA_DON(MaKH, MaNV, ThoiGian, GiamGia) VALUES('KH011','NV003','25-02-2020 12:00:00',50);
INSERT INTO HOA_DON(MaKH, MaNV, ThoiGian, GiamGia) VALUES('KH012','NV003','22-02-2020 12:00:00',50);
INSERT INTO HOA_DON(MaKH, MaNV, ThoiGian, GiamGia) VALUES('KH013','NV003','21-02-2020 12:00:00',50);
INSERT INTO HOA_DON(MaKH, MaNV, ThoiGian, GiamGia) VALUES('KH014','NV002','28-02-2020 12:00:00',50);
INSERT INTO HOA_DON(MaKH, MaNV, ThoiGian, GiamGia) VALUES('KH015','NV002','25-02-2020 12:00:00',50);
INSERT INTO HOA_DON(MaKH, MaNV, ThoiGian, GiamGia) VALUES('KH016','NV002','11-02-2020 12:00:00',70);
INSERT INTO HOA_DON(MaKH, MaNV, ThoiGian, GiamGia) VALUES('KH018','NV002','12-04-2020 12:00:00',20);
INSERT INTO HOA_DON(MaKH, MaNV, ThoiGian, GiamGia) VALUES('KH019','NV002','12-07-2020 12:00:00',20);
INSERT INTO HOA_DON(MaKH, MaNV, ThoiGian, GiamGia) VALUES('KH020','NV002','11-06-2020 12:00:00',20);

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
('NND01',N'Quản Lý'),
('NND02',N'Nhân viên bán hàng'),
('NND03',N'Nhân viên kho')

INSERT INTO NGUOI_DUNG_NHOM_NGUOI_DUNG(TaiKhoan,MaNhom) VALUES
('TKNV001','NND01'),
('TKNV002','NND02'),
('TKNV003','NND02'),
('TKNV004','NND02'),
('TKNV005','NND03'),
('TKNV006','NND03')

INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND01','MH001',1)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND01','MH002',1)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND01','MH003',1)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND01','MH004',1)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND01','MH005',1)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND01','MH006',1)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND01','MH007',1)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND01','MH008',1)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND01','MH009',1)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND01','MH010',1)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND01','MH011',1)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND01','MH012',1)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND01','MH013',1)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND01','MH014',1)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND01','MH015',1)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND01','MH016',1)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND01','MH017',1)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND01','MH018',1)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND01','MH019',1)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND01','MH020',1)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND01','MH021',1)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND01','MH022',1)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND01','MH023',1)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND01','MH024',1)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND01','MH025',1)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND01','MH026',1)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND01','MH027',1)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND01','MH028',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND02','MH001',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND02','MH003',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND02','MH004',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND02','MH005',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND02','MH006',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND02','MH007',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND02','MH008',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND02','MH009',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND02','MH010',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND02','MH011',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND02','MH012',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND02','MH013',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND02','MH014',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND02','MH015',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND02','MH016',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND02','MH017',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND02','MH018',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND02','MH019',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND02','MH020',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND02','MH021',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND02','MH022',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND02','MH023',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND02','MH024',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND02','MH025',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND02','MH026',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND02','MH027',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND02','MH028',1)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND03','MH001',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND03','MH002',1)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND03','MH003',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND03','MH004',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND03','MH005',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND03','MH006',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NN003','MH007',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND03','MH008',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND03','MH009',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND03','MH010',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND03','MH011',1)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND03','MH012',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND03','MH013',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND03','MH014',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND03','MH015',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND03','MH016',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND03','MH017',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND03','MH018',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND03','MH019',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND03','MH020',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND03','MH021',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND03','MH022',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND03','MH023',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND03','MH024',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND03','MH025',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND03','MH026',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND03','MH027',0)
INSERT INTO PHAN_QUYEN(MaNhom,MaMH,CoQuyen) VALUES('NND03','MH028',0)

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
('NCC01',N'Boshop','6456656543154',N'111B Nguyễn Lâm, Phường 3, Q.Bình Thạnh. TP.HCM',N'boshop92@gmail.com',19007101 ,0),
('NCC02',N'Wholemartcosmetic','6456656544321',N'335/1 Điện Biên Phủ, P.4, Q.3,TP.HCM',N'wholemart.cosmetic111@gmail.com', 0871099333 ,0),
('NCC03',N'Bigmamacosmetics','6452365927430',N'208 Nguyễn Hữu Cảnh, Quận Bình Thạnh, TP.HCM',N'bigmama@bigmamacosmetics.vn', 02866608100 ,0),
('NCC04',N'Abu','6456656578347',N'Shophouse,Hàm Nghi, Nam Từ Liêm, Hà Nội',N'myphamhanquochcm5@gmail.com',01687641999 ,0),
('NCC05',N'Myphamstar','6456651243457',N'Số 39/29 Đường Khương Hạ, Phường Khương Đình,Hà Nội',N'myphamstar@gmail.com',0981659986 ,0)

SET DATEFORMAT DMY;
INSERT INTO PHIEU_NHAP(MaPN,MaNV,MaNCC,ThoiGian,GiamGia) VALUES('PN001','NV006','NCC001','2020-01-01',0);
INSERT INTO PHIEU_NHAP(MaPN,MaNV,MaNCC,ThoiGian,GiamGia) VALUES('PN002','NV006','NCC002','2020-02-01',0);
INSERT INTO PHIEU_NHAP(MaPN,MaNV,MaNCC,ThoiGian,GiamGia) VALUES('PN003','NV001','NCC003','2020-01-01',0);

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
('PN001','NCC01','NV001'),
('PN002','NCC02','NV001'),
('PN003','NCC03','NV001')

INSERT INTO CHI_TIET_PHIEU_TRA_HANG_BAN(MaPTB,MaSP,SoLuong) VALUES
('PTB01','SP001',10),
('PTB02','SP003',10),
('PTB03','SP004',10)

SET DATEFORMAT DMY
INSERT INTO PHIEU_TRA_HANG_BAN(MaPTB,MaHD,MaKH,MaNV,ChiPhi,TongTien,ThoiGian) VALUES
('PTB01',1,'KH001','NV001',200000,1000000,'2015-01-05 02:53:35.000'),
('PTB02',2,'KH002','NV001',200000,1000000,'2015-01-05 02:53:35.000'),
('PTB03',3,'KH003','NV001',200000,1000000,'2015-01-05 02:53:35.000'),
('PTB04',4,'KH004','NV001',200000,1000000,'2015-01-05 02:53:35.000'),
('PTB05',5,'KH005','NV001',200000,1000000,'2015-01-05 02:53:35.000')

INSERT INTO HOAT_DONG(MaHoatDong,MaNV,HoatDong,ThoiGian,GiaTri) VALUES
(1,'NV001',N'Nhập đơn hàng','2015-01-01 02:39:43.590',80000000),
(2,'NV001',N'Thiết lập giá sản phẩm SP001','2015-01-01 02:39:43.590',80000000),
(3,'NV001',N'Thiết lập giá sản phẩm SP002','2015-01-01 02:39:43.600',20000000),
(4,'NV001',N'Thiết lập giá sản phẩm SP003','2015-01-01 02:39:43.620',20000000),
(5,'NV001',N'Thiết lập giá sản phẩm SP004','2015-01-01 02:39:43.800',40000000)

select * from DANG_NHAP where TaiKhoan='TKNV001' and MatKhau='1'