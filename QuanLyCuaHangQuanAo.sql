USE [master]
GO
/****** Object:  Database [QuanLyShopQuanAo]    Script Date: 5/22/2024 7:33:07 AM ******/
CREATE DATABASE [QuanLyShopQuanAo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLCHQAd', FILENAME = N'D:\HKII_2024_03\LTQL\Đồ án QLBH\QLCHQAdata.mdf' , SIZE = 10240KB , MAXSIZE = 102400KB , FILEGROWTH = 5120KB )
 LOG ON 
( NAME = N'QLCHQAlg', FILENAME = N'D:\HKII_2024_03\LTQL\Đồ án QLBH\QLCHQAlog.ldf' , SIZE = 10240KB , MAXSIZE = 102400KB , FILEGROWTH = 5120KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QuanLyShopQuanAo] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyShopQuanAo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyShopQuanAo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyShopQuanAo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyShopQuanAo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyShopQuanAo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyShopQuanAo] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyShopQuanAo] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QuanLyShopQuanAo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyShopQuanAo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyShopQuanAo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyShopQuanAo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyShopQuanAo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyShopQuanAo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyShopQuanAo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyShopQuanAo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyShopQuanAo] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanLyShopQuanAo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyShopQuanAo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyShopQuanAo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyShopQuanAo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyShopQuanAo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyShopQuanAo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyShopQuanAo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyShopQuanAo] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLyShopQuanAo] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyShopQuanAo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyShopQuanAo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyShopQuanAo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyShopQuanAo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLyShopQuanAo] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuanLyShopQuanAo] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [QuanLyShopQuanAo] SET QUERY_STORE = OFF
GO
USE [QuanLyShopQuanAo]
GO
/****** Object:  Table [dbo].[chatlieu]    Script Date: 5/22/2024 7:33:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chatlieu](
	[machatlieu] [int] IDENTITY(1,1) NOT NULL,
	[tenchatlieu] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[machatlieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[chucvu]    Script Date: 5/22/2024 7:33:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chucvu](
	[macv] [int] NOT NULL,
	[tencv] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[macv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cthd]    Script Date: 5/22/2024 7:33:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cthd](
	[mahd] [varchar](10) NOT NULL,
	[masp] [varchar](5) NOT NULL,
	[soluong] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[mahd] ASC,
	[masp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hoadon]    Script Date: 5/22/2024 7:33:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hoadon](
	[mahd] [varchar](10) NOT NULL,
	[manv] [varchar](10) NULL,
	[makh] [varchar](4) NULL,
	[ngaylap] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[mahd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[khachhang]    Script Date: 5/22/2024 7:33:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[khachhang](
	[makh] [varchar](4) NOT NULL,
	[hoten] [nvarchar](50) NULL,
	[phai] [nvarchar](3) NULL,
	[ngaysinh] [date] NULL,
	[sodt] [varchar](11) NULL,
	[diachi] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[makh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[khohang]    Script Date: 5/22/2024 7:33:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[khohang](
	[masp] [varchar](5) NULL,
	[sl] [int] NULL,
	[giaban] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[loaisp]    Script Date: 5/22/2024 7:33:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[loaisp](
	[maloai] [int] IDENTITY(1,1) NOT NULL,
	[tenloai] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[maloai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nhacungcap]    Script Date: 5/22/2024 7:33:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nhacungcap](
	[mancc] [int] IDENTITY(1,1) NOT NULL,
	[tenncc] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[mancc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nhanvien]    Script Date: 5/22/2024 7:33:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nhanvien](
	[manv] [varchar](10) NOT NULL,
	[tentk] [nvarchar](20) NOT NULL,
	[matkhau] [varchar](60) NOT NULL,
	[hoten] [nvarchar](50) NULL,
	[phai] [nvarchar](3) NULL,
	[ngaysinh] [date] NOT NULL,
	[cccd] [varchar](12) NULL,
	[sodt] [varchar](11) NULL,
	[macv] [int] NOT NULL,
	[anh] [image] NULL,
PRIMARY KEY CLUSTERED 
(
	[manv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[phieunhap]    Script Date: 5/22/2024 7:33:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[phieunhap](
	[sophieu] [int] IDENTITY(0,1) NOT NULL,
	[masp] [varchar](5) NOT NULL,
	[manv] [varchar](10) NOT NULL,
	[mancc] [int] NOT NULL,
	[soluong] [int] NULL,
	[ngaynhap] [datetime] NULL,
	[gianhap] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[sophieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[phieuxuat]    Script Date: 5/22/2024 7:33:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[phieuxuat](
	[sophieu] [int] IDENTITY(0,1) NOT NULL,
	[masp] [varchar](5) NOT NULL,
	[manv] [varchar](10) NOT NULL,
	[makh] [varchar](4) NOT NULL,
	[soluong] [int] NULL,
	[ngayxuat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[sophieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sanpham]    Script Date: 5/22/2024 7:33:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sanpham](
	[masp] [varchar](5) NOT NULL,
	[tensp] [nvarchar](50) NULL,
	[mau] [nvarchar](30) NULL,
	[size] [nvarchar](20) NULL,
	[anh] [varchar](max) NULL,
	[maloai] [int] NOT NULL,
	[mancc] [int] NOT NULL,
	[machatlieu] [int] NOT NULL,
	[note] [nvarchar](60) NULL,
PRIMARY KEY CLUSTERED 
(
	[masp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[khachhang] ADD  DEFAULT (getdate()) FOR [ngaysinh]
GO
ALTER TABLE [dbo].[khohang] ADD  CONSTRAINT [DF__khohang__sl__32767D0B]  DEFAULT ((0)) FOR [sl]
GO
ALTER TABLE [dbo].[nhanvien] ADD  DEFAULT (getdate()) FOR [ngaysinh]
GO
ALTER TABLE [dbo].[phieunhap] ADD  DEFAULT ((0)) FOR [soluong]
GO
ALTER TABLE [dbo].[phieuxuat] ADD  DEFAULT ((0)) FOR [soluong]
GO
ALTER TABLE [dbo].[cthd]  WITH CHECK ADD  CONSTRAINT [fk_mahd_cthd] FOREIGN KEY([mahd])
REFERENCES [dbo].[hoadon] ([mahd])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[cthd] CHECK CONSTRAINT [fk_mahd_cthd]
GO
ALTER TABLE [dbo].[cthd]  WITH CHECK ADD  CONSTRAINT [fk_masp_cthd] FOREIGN KEY([masp])
REFERENCES [dbo].[sanpham] ([masp])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[cthd] CHECK CONSTRAINT [fk_masp_cthd]
GO
ALTER TABLE [dbo].[hoadon]  WITH CHECK ADD  CONSTRAINT [fk_makh_hd] FOREIGN KEY([makh])
REFERENCES [dbo].[khachhang] ([makh])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[hoadon] CHECK CONSTRAINT [fk_makh_hd]
GO
ALTER TABLE [dbo].[hoadon]  WITH CHECK ADD  CONSTRAINT [fk_manv_hd] FOREIGN KEY([manv])
REFERENCES [dbo].[nhanvien] ([manv])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[hoadon] CHECK CONSTRAINT [fk_manv_hd]
GO
ALTER TABLE [dbo].[khohang]  WITH CHECK ADD  CONSTRAINT [fk_masp_khohang] FOREIGN KEY([masp])
REFERENCES [dbo].[sanpham] ([masp])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[khohang] CHECK CONSTRAINT [fk_masp_khohang]
GO
ALTER TABLE [dbo].[nhanvien]  WITH CHECK ADD  CONSTRAINT [fk_macv_nhanvien] FOREIGN KEY([macv])
REFERENCES [dbo].[chucvu] ([macv])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[nhanvien] CHECK CONSTRAINT [fk_macv_nhanvien]
GO
ALTER TABLE [dbo].[phieunhap]  WITH CHECK ADD  CONSTRAINT [fk_mancc_phieunhap] FOREIGN KEY([mancc])
REFERENCES [dbo].[nhacungcap] ([mancc])
GO
ALTER TABLE [dbo].[phieunhap] CHECK CONSTRAINT [fk_mancc_phieunhap]
GO
ALTER TABLE [dbo].[phieunhap]  WITH CHECK ADD  CONSTRAINT [fk_manv_phieunhap] FOREIGN KEY([manv])
REFERENCES [dbo].[nhanvien] ([manv])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[phieunhap] CHECK CONSTRAINT [fk_manv_phieunhap]
GO
ALTER TABLE [dbo].[phieunhap]  WITH CHECK ADD  CONSTRAINT [fk_masp_phieunhap] FOREIGN KEY([masp])
REFERENCES [dbo].[sanpham] ([masp])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[phieunhap] CHECK CONSTRAINT [fk_masp_phieunhap]
GO
ALTER TABLE [dbo].[phieuxuat]  WITH CHECK ADD  CONSTRAINT [fk_makh_phieuxuat] FOREIGN KEY([makh])
REFERENCES [dbo].[khachhang] ([makh])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[phieuxuat] CHECK CONSTRAINT [fk_makh_phieuxuat]
GO
ALTER TABLE [dbo].[phieuxuat]  WITH CHECK ADD  CONSTRAINT [fk_manv_phieuxuat] FOREIGN KEY([manv])
REFERENCES [dbo].[nhanvien] ([manv])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[phieuxuat] CHECK CONSTRAINT [fk_manv_phieuxuat]
GO
ALTER TABLE [dbo].[phieuxuat]  WITH CHECK ADD  CONSTRAINT [fk_masp_phieuxuat] FOREIGN KEY([masp])
REFERENCES [dbo].[sanpham] ([masp])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[phieuxuat] CHECK CONSTRAINT [fk_masp_phieuxuat]
GO
ALTER TABLE [dbo].[sanpham]  WITH CHECK ADD  CONSTRAINT [fk_machatlieu_sanpham] FOREIGN KEY([machatlieu])
REFERENCES [dbo].[chatlieu] ([machatlieu])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[sanpham] CHECK CONSTRAINT [fk_machatlieu_sanpham]
GO
ALTER TABLE [dbo].[sanpham]  WITH CHECK ADD  CONSTRAINT [fk_maloai_sanpham] FOREIGN KEY([maloai])
REFERENCES [dbo].[loaisp] ([maloai])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[sanpham] CHECK CONSTRAINT [fk_maloai_sanpham]
GO
ALTER TABLE [dbo].[sanpham]  WITH CHECK ADD  CONSTRAINT [fk_mancc_sanpham] FOREIGN KEY([mancc])
REFERENCES [dbo].[nhacungcap] ([mancc])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[sanpham] CHECK CONSTRAINT [fk_mancc_sanpham]
GO
USE [master]
GO
ALTER DATABASE [QuanLyShopQuanAo] SET  READ_WRITE 
GO
