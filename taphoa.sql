USE [qlBanHang]
GO
/****** Object:  Table [dbo].[ChiTiet_HDBan]    Script Date: 11/30/2020 10:21:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTiet_HDBan](
	[MaHD] [nchar](10) NOT NULL,
	[MaSP] [nchar](10) NULL,
	[SoLuong] [int] NULL,
	[GiaBan] [int] NULL,
	[GiamGia] [int] NULL,
	[ThanhTien] [bigint] NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_ChiTiet_HDBan] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTiet_HDNhap]    Script Date: 11/30/2020 10:21:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTiet_HDNhap](
	[MaHDB] [nchar](10) NOT NULL,
	[MaSP] [nchar](10) NULL,
	[GiaNhap] [int] NULL,
	[SoLuongNhap] [int] NULL,
	[NgayHetHan] [date] NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_ChiTiet_HDNhap] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DonVi]    Script Date: 11/30/2020 10:21:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonVi](
	[MaDV] [nchar](10) NOT NULL,
	[TenDV] [nvarchar](50) NULL,
 CONSTRAINT [PK_DonVi] PRIMARY KEY CLUSTERED 
(
	[MaDV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HDBan]    Script Date: 11/30/2020 10:21:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HDBan](
	[MaHD] [nchar](10) NOT NULL,
	[date] [date] NULL,
	[MaNV] [nchar](10) NULL,
	[TenKhachHang] [nvarchar](50) NULL,
 CONSTRAINT [PK_HDBan] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HDNhap]    Script Date: 11/30/2020 10:21:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HDNhap](
	[MaHDB] [nchar](10) NOT NULL,
	[MaNV] [nchar](10) NULL,
	[NgayNhap] [date] NULL,
 CONSTRAINT [PK_HDNhap] PRIMARY KEY CLUSTERED 
(
	[MaHDB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NCC]    Script Date: 11/30/2020 10:21:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NCC](
	[MaNCC] [nchar](10) NOT NULL,
	[TenNCC] [nvarchar](50) NULL,
	[SoDienThoai] [nvarchar](12) NULL,
	[DiaChi] [nvarchar](50) NULL,
 CONSTRAINT [PK_NCC] PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 11/30/2020 10:21:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [nchar](10) NOT NULL,
	[TenNhanVien] [nchar](20) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[SoDienThoai] [nvarchar](50) NULL,
	[MaQuyen] [nchar](10) NOT NULL,
	[username] [nchar](20) NULL,
	[password] [nchar](20) NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhapKho]    Script Date: 11/30/2020 10:21:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhapKho](
	[MaSP] [nchar](10) NOT NULL,
	[TenSP] [nvarchar](50) NULL,
	[MaDV] [nchar](10) NULL,
	[GiaBan] [bigint] NULL,
	[MaNCC] [nchar](10) NULL,
 CONSTRAINT [PK_NhapKho] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Quyen]    Script Date: 11/30/2020 10:21:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quyen](
	[MaQuyen] [nchar](10) NOT NULL,
	[TenQuyen] [nvarchar](50) NULL,
 CONSTRAINT [PK_Quyen] PRIMARY KEY CLUSTERED 
(
	[MaQuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[XuatKho]    Script Date: 11/30/2020 10:21:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XuatKho](
	[MaQuay] [nchar](10) NOT NULL,
	[TenQuay] [nchar](10) NULL,
	[MaSP] [nchar](10) NULL,
	[SoLuongXuat] [int] NULL,
 CONSTRAINT [PK_XuatKho] PRIMARY KEY CLUSTERED 
(
	[MaQuay] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[ChiTiet_HDBan] ON 

INSERT [dbo].[ChiTiet_HDBan] ([MaHD], [MaSP], [SoLuong], [GiaBan], [GiamGia], [ThanhTien], [ID]) VALUES (N'HDB-01    ', N'SP01      ', 2, 195000, NULL, 390000, 8)
INSERT [dbo].[ChiTiet_HDBan] ([MaHD], [MaSP], [SoLuong], [GiaBan], [GiamGia], [ThanhTien], [ID]) VALUES (N'HDB-01    ', N'SP05      ', 2, 5000, NULL, 10000, 10)
INSERT [dbo].[ChiTiet_HDBan] ([MaHD], [MaSP], [SoLuong], [GiaBan], [GiamGia], [ThanhTien], [ID]) VALUES (N'HDB-02    ', N'SP09      ', 3, 10000, NULL, 30000, 11)
INSERT [dbo].[ChiTiet_HDBan] ([MaHD], [MaSP], [SoLuong], [GiaBan], [GiamGia], [ThanhTien], [ID]) VALUES (N'HDB-02    ', N'SP08      ', 2, 5000, NULL, 10000, 12)
INSERT [dbo].[ChiTiet_HDBan] ([MaHD], [MaSP], [SoLuong], [GiaBan], [GiamGia], [ThanhTien], [ID]) VALUES (N'HDB-03    ', N'SP01      ', 2, 195000, NULL, 390000, 13)
INSERT [dbo].[ChiTiet_HDBan] ([MaHD], [MaSP], [SoLuong], [GiaBan], [GiamGia], [ThanhTien], [ID]) VALUES (N'HDB-03    ', N'SP09      ', 3, 10000, NULL, 30000, 14)
INSERT [dbo].[ChiTiet_HDBan] ([MaHD], [MaSP], [SoLuong], [GiaBan], [GiamGia], [ThanhTien], [ID]) VALUES (N'HDB-04    ', N'SP05      ', 10, 5000, NULL, 50000, 15)
INSERT [dbo].[ChiTiet_HDBan] ([MaHD], [MaSP], [SoLuong], [GiaBan], [GiamGia], [ThanhTien], [ID]) VALUES (N'HDB-04    ', N'SP02      ', 8, 10000, NULL, 80000, 16)
INSERT [dbo].[ChiTiet_HDBan] ([MaHD], [MaSP], [SoLuong], [GiaBan], [GiamGia], [ThanhTien], [ID]) VALUES (N'HDB-05    ', N'SP01      ', 4, 195000, NULL, 780000, 17)
INSERT [dbo].[ChiTiet_HDBan] ([MaHD], [MaSP], [SoLuong], [GiaBan], [GiamGia], [ThanhTien], [ID]) VALUES (N'HDB-05    ', N'SP01      ', 5, 195000, NULL, 975000, 18)
SET IDENTITY_INSERT [dbo].[ChiTiet_HDBan] OFF
SET IDENTITY_INSERT [dbo].[ChiTiet_HDNhap] ON 

INSERT [dbo].[ChiTiet_HDNhap] ([MaHDB], [MaSP], [GiaNhap], [SoLuongNhap], [NgayHetHan], [ID]) VALUES (N'HDN01     ', N'SP01      ', 2500, 100, CAST(N'2022-03-18' AS Date), 10)
INSERT [dbo].[ChiTiet_HDNhap] ([MaHDB], [MaSP], [GiaNhap], [SoLuongNhap], [NgayHetHan], [ID]) VALUES (N'HDN01     ', N'SP02      ', 3600, 200, CAST(N'2022-06-10' AS Date), 11)
INSERT [dbo].[ChiTiet_HDNhap] ([MaHDB], [MaSP], [GiaNhap], [SoLuongNhap], [NgayHetHan], [ID]) VALUES (N'HDN01     ', N'SP08      ', 1500, 150, CAST(N'2022-07-01' AS Date), 12)
INSERT [dbo].[ChiTiet_HDNhap] ([MaHDB], [MaSP], [GiaNhap], [SoLuongNhap], [NgayHetHan], [ID]) VALUES (N'HDN02     ', N'SP05      ', 2000, 500, CAST(N'2021-11-27' AS Date), 13)
INSERT [dbo].[ChiTiet_HDNhap] ([MaHDB], [MaSP], [GiaNhap], [SoLuongNhap], [NgayHetHan], [ID]) VALUES (N'HDN02     ', N'SP09      ', 5000, 215, CAST(N'2021-02-25' AS Date), 14)
INSERT [dbo].[ChiTiet_HDNhap] ([MaHDB], [MaSP], [GiaNhap], [SoLuongNhap], [NgayHetHan], [ID]) VALUES (N'HDN03     ', N'SP01      ', 140000, 370, CAST(N'2021-12-23' AS Date), 15)
INSERT [dbo].[ChiTiet_HDNhap] ([MaHDB], [MaSP], [GiaNhap], [SoLuongNhap], [NgayHetHan], [ID]) VALUES (N'HDN03     ', N'SP07      ', 2000, 400, CAST(N'2021-12-02' AS Date), 16)
INSERT [dbo].[ChiTiet_HDNhap] ([MaHDB], [MaSP], [GiaNhap], [SoLuongNhap], [NgayHetHan], [ID]) VALUES (N'HDN04     ', N'SP06      ', 4000, 157, CAST(N'2021-12-30' AS Date), 17)
INSERT [dbo].[ChiTiet_HDNhap] ([MaHDB], [MaSP], [GiaNhap], [SoLuongNhap], [NgayHetHan], [ID]) VALUES (N'HDN04     ', N'SP04      ', 3000, 261, CAST(N'2021-11-25' AS Date), 18)
INSERT [dbo].[ChiTiet_HDNhap] ([MaHDB], [MaSP], [GiaNhap], [SoLuongNhap], [NgayHetHan], [ID]) VALUES (N'HDN05     ', N'SP07      ', 2000, 50, CAST(N'2020-12-25' AS Date), 19)
SET IDENTITY_INSERT [dbo].[ChiTiet_HDNhap] OFF
INSERT [dbo].[DonVi] ([MaDV], [TenDV]) VALUES (N'DV01      ', N'Thùng')
INSERT [dbo].[DonVi] ([MaDV], [TenDV]) VALUES (N'DV02      ', N'Bịch')
INSERT [dbo].[DonVi] ([MaDV], [TenDV]) VALUES (N'DV03      ', N'Gói')
INSERT [dbo].[DonVi] ([MaDV], [TenDV]) VALUES (N'DV04      ', N'Túi')
INSERT [dbo].[DonVi] ([MaDV], [TenDV]) VALUES (N'DV06      ', N'Hộp')
INSERT [dbo].[DonVi] ([MaDV], [TenDV]) VALUES (N'DV07      ', N'Chai')
INSERT [dbo].[HDBan] ([MaHD], [date], [MaNV], [TenKhachHang]) VALUES (N'HDB-01    ', CAST(N'2020-11-27' AS Date), N'NV01      ', N'Nguyễn Doãn Phú')
INSERT [dbo].[HDBan] ([MaHD], [date], [MaNV], [TenKhachHang]) VALUES (N'HDB-02    ', CAST(N'2020-11-27' AS Date), N'NV01      ', N'Hoàng Bích Ngọc')
INSERT [dbo].[HDBan] ([MaHD], [date], [MaNV], [TenKhachHang]) VALUES (N'HDB-03    ', CAST(N'2020-11-27' AS Date), N'NV01      ', N'')
INSERT [dbo].[HDBan] ([MaHD], [date], [MaNV], [TenKhachHang]) VALUES (N'HDB-04    ', CAST(N'2020-11-27' AS Date), N'NV01      ', N'')
INSERT [dbo].[HDBan] ([MaHD], [date], [MaNV], [TenKhachHang]) VALUES (N'HDB-05    ', CAST(N'2020-11-27' AS Date), N'NV01      ', N'Đào Như Quỳnh')
INSERT [dbo].[HDNhap] ([MaHDB], [MaNV], [NgayNhap]) VALUES (N'HDN01     ', N'NV01      ', CAST(N'2020-11-27' AS Date))
INSERT [dbo].[HDNhap] ([MaHDB], [MaNV], [NgayNhap]) VALUES (N'HDN02     ', N'NV01      ', CAST(N'2020-11-27' AS Date))
INSERT [dbo].[HDNhap] ([MaHDB], [MaNV], [NgayNhap]) VALUES (N'HDN03     ', N'NV01      ', CAST(N'2020-11-27' AS Date))
INSERT [dbo].[HDNhap] ([MaHDB], [MaNV], [NgayNhap]) VALUES (N'HDN04     ', N'NV01      ', CAST(N'2020-11-27' AS Date))
INSERT [dbo].[HDNhap] ([MaHDB], [MaNV], [NgayNhap]) VALUES (N'HDN05     ', N'NV01      ', CAST(N'2020-11-27' AS Date))
INSERT [dbo].[NCC] ([MaNCC], [TenNCC], [SoDienThoai], [DiaChi]) VALUES (N'NCC01     ', N'Công ty cổ phần Coca', N'Hà Nội', N'068927428')
INSERT [dbo].[NCC] ([MaNCC], [TenNCC], [SoDienThoai], [DiaChi]) VALUES (N'NCC02     ', N'Công ty cổ phần PepsiCo', N'Hà Nội', N'0928174281')
INSERT [dbo].[NCC] ([MaNCC], [TenNCC], [SoDienThoai], [DiaChi]) VALUES (N'NCC03     ', N'Tập đoàn TH Group', N'Hà Nội', N'0928174216')
INSERT [dbo].[NCC] ([MaNCC], [TenNCC], [SoDienThoai], [DiaChi]) VALUES (N'NCC04     ', N'Công ty cổ phần Ace Cook', N'Hà Nội', N'0928119525')
INSERT [dbo].[NCC] ([MaNCC], [TenNCC], [SoDienThoai], [DiaChi]) VALUES (N'NCC05     ', N'Công ty Liwayway ', N'Hà Nội', N'0928124124')
INSERT [dbo].[NhanVien] ([MaNV], [TenNhanVien], [DiaChi], [SoDienThoai], [MaQuyen], [username], [password]) VALUES (N'NV01      ', N'Lưu Quang Nam       ', N'Bắc Ninh', N'037874432', N'2         ', N'namluu              ', N'namluu              ')
INSERT [dbo].[NhanVien] ([MaNV], [TenNhanVien], [DiaChi], [SoDienThoai], [MaQuyen], [username], [password]) VALUES (N'NV02      ', N'Nguyễn Doãn Phú     ', N'Hà Nội', N'012942824', N'1         ', N'nguyenphu           ', N'nguyenphu           ')
INSERT [dbo].[NhapKho] ([MaSP], [TenSP], [MaDV], [GiaBan], [MaNCC]) VALUES (N'SP01      ', N'Nước giải khát Coca Cola', N'DV01      ', 195000, N'NCC01     ')
INSERT [dbo].[NhapKho] ([MaSP], [TenSP], [MaDV], [GiaBan], [MaNCC]) VALUES (N'SP02      ', N'Sữa TH True Milk', N'DV04      ', 10000, N'NCC03     ')
INSERT [dbo].[NhapKho] ([MaSP], [TenSP], [MaDV], [GiaBan], [MaNCC]) VALUES (N'SP03      ', N'Thùng mì Hảo Hảo', N'DV01      ', 96000, N'NCC04     ')
INSERT [dbo].[NhapKho] ([MaSP], [TenSP], [MaDV], [GiaBan], [MaNCC]) VALUES (N'SP04      ', N'Bịch Bim Bim', N'DV02      ', 45000, N'NCC04     ')
INSERT [dbo].[NhapKho] ([MaSP], [TenSP], [MaDV], [GiaBan], [MaNCC]) VALUES (N'SP05      ', N'Gói Bim Bim', N'DV03      ', 5000, N'NCC04     ')
INSERT [dbo].[NhapKho] ([MaSP], [TenSP], [MaDV], [GiaBan], [MaNCC]) VALUES (N'SP06      ', N'Nước giải khát Sting', N'DV07      ', 8000, N'NCC02     ')
INSERT [dbo].[NhapKho] ([MaSP], [TenSP], [MaDV], [GiaBan], [MaNCC]) VALUES (N'SP07      ', N'Nước khoáng', N'DV04      ', 5000, N'NCC01     ')
INSERT [dbo].[NhapKho] ([MaSP], [TenSP], [MaDV], [GiaBan], [MaNCC]) VALUES (N'SP08      ', N'Kẹo ngậm Osihi vị đào', N'DV03      ', 5000, N'NCC01     ')
INSERT [dbo].[NhapKho] ([MaSP], [TenSP], [MaDV], [GiaBan], [MaNCC]) VALUES (N'SP09      ', N'Trà thảo mộc Dr Thanh', N'DV07      ', 10000, N'NCC02     ')
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen]) VALUES (N'1         ', N'Nhân viên')
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen]) VALUES (N'2         ', N'Quản trị viên')
INSERT [dbo].[XuatKho] ([MaQuay], [TenQuay], [MaSP], [SoLuongXuat]) VALUES (N'Z01       ', N'Đồ uống   ', N'SP01      ', 5)
INSERT [dbo].[XuatKho] ([MaQuay], [TenQuay], [MaSP], [SoLuongXuat]) VALUES (N'Z02       ', N'Đồ uống 2 ', N'SP01      ', 5)
INSERT [dbo].[XuatKho] ([MaQuay], [TenQuay], [MaSP], [SoLuongXuat]) VALUES (N'Z03       ', N'Đồ uống 3 ', N'SP02      ', 10)
INSERT [dbo].[XuatKho] ([MaQuay], [TenQuay], [MaSP], [SoLuongXuat]) VALUES (N'Z04       ', N'Đồ Ăn Vặt ', N'SP05      ', 10)
INSERT [dbo].[XuatKho] ([MaQuay], [TenQuay], [MaSP], [SoLuongXuat]) VALUES (N'Z05       ', N'Đồ uống 4 ', N'SP06      ', 10)
INSERT [dbo].[XuatKho] ([MaQuay], [TenQuay], [MaSP], [SoLuongXuat]) VALUES (N'Z06       ', N'Bánh kẹo  ', N'SP08      ', 20)
INSERT [dbo].[XuatKho] ([MaQuay], [TenQuay], [MaSP], [SoLuongXuat]) VALUES (N'Z07       ', N'Đồ uống 5 ', N'SP09      ', 20)
INSERT [dbo].[XuatKho] ([MaQuay], [TenQuay], [MaSP], [SoLuongXuat]) VALUES (N'Z08       ', N'Đồ uống 6 ', N'SP07      ', 20)
ALTER TABLE [dbo].[ChiTiet_HDBan]  WITH CHECK ADD  CONSTRAINT [FK_ChiTiet_HDBan_HDBan] FOREIGN KEY([MaHD])
REFERENCES [dbo].[HDBan] ([MaHD])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTiet_HDBan] CHECK CONSTRAINT [FK_ChiTiet_HDBan_HDBan]
GO
ALTER TABLE [dbo].[ChiTiet_HDBan]  WITH CHECK ADD  CONSTRAINT [FK_ChiTiet_HDBan_NhapKho] FOREIGN KEY([MaSP])
REFERENCES [dbo].[NhapKho] ([MaSP])
GO
ALTER TABLE [dbo].[ChiTiet_HDBan] CHECK CONSTRAINT [FK_ChiTiet_HDBan_NhapKho]
GO
ALTER TABLE [dbo].[ChiTiet_HDNhap]  WITH CHECK ADD  CONSTRAINT [FK_ChiTiet_HDNhap_HDNhap] FOREIGN KEY([MaHDB])
REFERENCES [dbo].[HDNhap] ([MaHDB])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTiet_HDNhap] CHECK CONSTRAINT [FK_ChiTiet_HDNhap_HDNhap]
GO
ALTER TABLE [dbo].[ChiTiet_HDNhap]  WITH CHECK ADD  CONSTRAINT [FK_ChiTiet_HDNhap_NhapKho] FOREIGN KEY([MaSP])
REFERENCES [dbo].[NhapKho] ([MaSP])
GO
ALTER TABLE [dbo].[ChiTiet_HDNhap] CHECK CONSTRAINT [FK_ChiTiet_HDNhap_NhapKho]
GO
ALTER TABLE [dbo].[HDBan]  WITH CHECK ADD  CONSTRAINT [FK_HDBan_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[HDBan] CHECK CONSTRAINT [FK_HDBan_NhanVien]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_Quyen] FOREIGN KEY([MaQuyen])
REFERENCES [dbo].[Quyen] ([MaQuyen])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_Quyen]
GO
ALTER TABLE [dbo].[NhapKho]  WITH CHECK ADD  CONSTRAINT [FK_NhapKho_DonVi] FOREIGN KEY([MaDV])
REFERENCES [dbo].[DonVi] ([MaDV])
GO
ALTER TABLE [dbo].[NhapKho] CHECK CONSTRAINT [FK_NhapKho_DonVi]
GO
ALTER TABLE [dbo].[NhapKho]  WITH CHECK ADD  CONSTRAINT [FK_NhapKho_NCC] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NCC] ([MaNCC])
GO
ALTER TABLE [dbo].[NhapKho] CHECK CONSTRAINT [FK_NhapKho_NCC]
GO
ALTER TABLE [dbo].[XuatKho]  WITH CHECK ADD  CONSTRAINT [FK_XuatKho_NhapKho] FOREIGN KEY([MaSP])
REFERENCES [dbo].[NhapKho] ([MaSP])
GO
ALTER TABLE [dbo].[XuatKho] CHECK CONSTRAINT [FK_XuatKho_NhapKho]
GO
