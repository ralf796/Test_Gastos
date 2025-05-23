USE [master]
GO
/****** Object:  Database [db_a8e200_testgastos]    Script Date: 14/05/2025 16:09:35 ******/
CREATE DATABASE [db_a8e200_testgastos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_a8e200_testgastos_Data', FILENAME = N'H:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\db_a8e200_testgastos_DATA.mdf' , SIZE = 8192KB , MAXSIZE = 204800KB , FILEGROWTH = 10%)
 LOG ON 
( NAME = N'db_a8e200_testgastos_Log', FILENAME = N'H:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\db_a8e200_testgastos_Log.LDF' , SIZE = 3072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [db_a8e200_testgastos] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_a8e200_testgastos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_a8e200_testgastos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_a8e200_testgastos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_a8e200_testgastos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_a8e200_testgastos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_a8e200_testgastos] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_a8e200_testgastos] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_a8e200_testgastos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_a8e200_testgastos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_a8e200_testgastos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_a8e200_testgastos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_a8e200_testgastos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_a8e200_testgastos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_a8e200_testgastos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_a8e200_testgastos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_a8e200_testgastos] SET  ENABLE_BROKER 
GO
ALTER DATABASE [db_a8e200_testgastos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_a8e200_testgastos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_a8e200_testgastos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_a8e200_testgastos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_a8e200_testgastos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_a8e200_testgastos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_a8e200_testgastos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_a8e200_testgastos] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [db_a8e200_testgastos] SET  MULTI_USER 
GO
ALTER DATABASE [db_a8e200_testgastos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_a8e200_testgastos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_a8e200_testgastos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_a8e200_testgastos] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [db_a8e200_testgastos] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [db_a8e200_testgastos] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [db_a8e200_testgastos] SET QUERY_STORE = OFF
GO
USE [db_a8e200_testgastos]
GO
/****** Object:  UserDefinedFunction [dbo].[GetDateSys]    Script Date: 14/05/2025 16:09:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetDateSys]()
RETURNS datetime
AS
BEGIN
	declare @fecha datetime = (select DATEADD(HOUR, 2, GETDATE()))
	return @fecha;
END
GO
/****** Object:  Table [dbo].[tbl_deposito]    Script Date: 14/05/2025 16:09:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_deposito](
	[id_deposito] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime] NULL,
	[id_fondo] [int] NULL,
	[monto] [decimal](18, 2) NULL,
	[id_usuario] [int] NULL,
	[estado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_deposito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_fondo_monetario]    Script Date: 14/05/2025 16:09:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_fondo_monetario](
	[id_fondo] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[id_tipo_fondo] [int] NULL,
	[id_usuario] [int] NULL,
	[saldo] [decimal](10, 2) NULL,
	[estado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_fondo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_gasto_detalle]    Script Date: 14/05/2025 16:09:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_gasto_detalle](
	[id_gasto_detalle] [int] IDENTITY(1,1) NOT NULL,
	[id_gasto_encabezado] [int] NULL,
	[id_tipo_gasto] [int] NULL,
	[monto] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_gasto_detalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_gasto_encabezado]    Script Date: 14/05/2025 16:09:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_gasto_encabezado](
	[id_gasto_encabezado] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime] NULL,
	[observaciones] [varchar](250) NULL,
	[nombre_comercio] [varchar](100) NULL,
	[tipo_documento] [varchar](50) NULL,
	[id_usuario] [int] NULL,
	[estado] [int] NULL,
	[id_fondo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_gasto_encabezado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_presupuesto]    Script Date: 14/05/2025 16:09:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_presupuesto](
	[id_presupuesto] [int] IDENTITY(1,1) NOT NULL,
	[id_usuario] [int] NULL,
	[id_tipo_gasto] [int] NULL,
	[monto] [decimal](10, 2) NOT NULL,
	[estado] [int] NULL,
	[anio] [int] NULL,
	[mes] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_presupuesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_tipo_documento]    Script Date: 14/05/2025 16:09:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_tipo_documento](
	[id_tipo_documento] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_tipo_documento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_tipo_fondo]    Script Date: 14/05/2025 16:09:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_tipo_fondo](
	[id_tipo_fondo] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_tipo_fondo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_tipo_gasto]    Script Date: 14/05/2025 16:09:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_tipo_gasto](
	[id_tipo_gasto] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [varchar](10) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[estado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_tipo_gasto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_usuario]    Script Date: 14/05/2025 16:09:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_usuario](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[identificacion] [varchar](20) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[usuario] [varchar](20) NOT NULL,
	[password] [varchar](100) NOT NULL,
	[fecha_nacimiento] [date] NULL,
	[direccion] [varchar](100) NULL,
	[correo] [varchar](50) NOT NULL,
	[telefono] [varchar](15) NULL,
	[fecha_creacion] [datetime] NULL,
	[estado] [int] NULL,
	[path] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_deposito] ON 

INSERT [dbo].[tbl_deposito] ([id_deposito], [fecha], [id_fondo], [monto], [id_usuario], [estado]) VALUES (1, CAST(N'2025-05-14T13:43:10.420' AS DateTime), 6, CAST(232.00 AS Decimal(18, 2)), 1, 0)
INSERT [dbo].[tbl_deposito] ([id_deposito], [fecha], [id_fondo], [monto], [id_usuario], [estado]) VALUES (2, CAST(N'2025-05-14T13:43:37.230' AS DateTime), 7, CAST(233.00 AS Decimal(18, 2)), 1, 1)
INSERT [dbo].[tbl_deposito] ([id_deposito], [fecha], [id_fondo], [monto], [id_usuario], [estado]) VALUES (3, CAST(N'2025-05-14T16:43:53.553' AS DateTime), 7, CAST(400.00 AS Decimal(18, 2)), 1, 1)
SET IDENTITY_INSERT [dbo].[tbl_deposito] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_fondo_monetario] ON 

INSERT [dbo].[tbl_fondo_monetario] ([id_fondo], [descripcion], [id_tipo_fondo], [id_usuario], [saldo], [estado]) VALUES (6, N'ASD', 2, 1, CAST(222.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[tbl_fondo_monetario] ([id_fondo], [descripcion], [id_tipo_fondo], [id_usuario], [saldo], [estado]) VALUES (7, N'PRUEBA 2', 1, 1, CAST(232.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[tbl_fondo_monetario] ([id_fondo], [descripcion], [id_tipo_fondo], [id_usuario], [saldo], [estado]) VALUES (8, N'FONDO 2', 2, 1, CAST(500.00 AS Decimal(10, 2)), 1)
SET IDENTITY_INSERT [dbo].[tbl_fondo_monetario] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_gasto_detalle] ON 

INSERT [dbo].[tbl_gasto_detalle] ([id_gasto_detalle], [id_gasto_encabezado], [id_tipo_gasto], [monto]) VALUES (1, 1, 1, CAST(213.00 AS Decimal(18, 2)))
INSERT [dbo].[tbl_gasto_detalle] ([id_gasto_detalle], [id_gasto_encabezado], [id_tipo_gasto], [monto]) VALUES (2, 2, 1, CAST(213.00 AS Decimal(18, 2)))
INSERT [dbo].[tbl_gasto_detalle] ([id_gasto_detalle], [id_gasto_encabezado], [id_tipo_gasto], [monto]) VALUES (3, 3, 1, CAST(213.00 AS Decimal(18, 2)))
INSERT [dbo].[tbl_gasto_detalle] ([id_gasto_detalle], [id_gasto_encabezado], [id_tipo_gasto], [monto]) VALUES (4, 4, 2, CAST(2323.00 AS Decimal(18, 2)))
INSERT [dbo].[tbl_gasto_detalle] ([id_gasto_detalle], [id_gasto_encabezado], [id_tipo_gasto], [monto]) VALUES (5, 5, 2, CAST(2323.00 AS Decimal(18, 2)))
INSERT [dbo].[tbl_gasto_detalle] ([id_gasto_detalle], [id_gasto_encabezado], [id_tipo_gasto], [monto]) VALUES (6, 6, 2, CAST(2323.00 AS Decimal(18, 2)))
INSERT [dbo].[tbl_gasto_detalle] ([id_gasto_detalle], [id_gasto_encabezado], [id_tipo_gasto], [monto]) VALUES (7, 7, 2, CAST(2323.00 AS Decimal(18, 2)))
INSERT [dbo].[tbl_gasto_detalle] ([id_gasto_detalle], [id_gasto_encabezado], [id_tipo_gasto], [monto]) VALUES (8, 7, 2, CAST(23.00 AS Decimal(18, 2)))
INSERT [dbo].[tbl_gasto_detalle] ([id_gasto_detalle], [id_gasto_encabezado], [id_tipo_gasto], [monto]) VALUES (9, 8, 2, CAST(23.00 AS Decimal(18, 2)))
INSERT [dbo].[tbl_gasto_detalle] ([id_gasto_detalle], [id_gasto_encabezado], [id_tipo_gasto], [monto]) VALUES (10, 9, 2, CAST(232.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[tbl_gasto_detalle] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_gasto_encabezado] ON 

INSERT [dbo].[tbl_gasto_encabezado] ([id_gasto_encabezado], [fecha], [observaciones], [nombre_comercio], [tipo_documento], [id_usuario], [estado], [id_fondo]) VALUES (1, CAST(N'2025-05-14T12:32:26.027' AS DateTime), N'2231sass', N'AAAA', N'Factura', 1, 1, 2)
INSERT [dbo].[tbl_gasto_encabezado] ([id_gasto_encabezado], [fecha], [observaciones], [nombre_comercio], [tipo_documento], [id_usuario], [estado], [id_fondo]) VALUES (2, CAST(N'2025-05-14T12:32:55.850' AS DateTime), N'2231sass', N'AAAA', N'Factura', 1, 1, 2)
INSERT [dbo].[tbl_gasto_encabezado] ([id_gasto_encabezado], [fecha], [observaciones], [nombre_comercio], [tipo_documento], [id_usuario], [estado], [id_fondo]) VALUES (3, CAST(N'2025-05-14T12:33:14.683' AS DateTime), N'2231sass', N'AAAA', N'Factura', 1, 1, 2)
INSERT [dbo].[tbl_gasto_encabezado] ([id_gasto_encabezado], [fecha], [observaciones], [nombre_comercio], [tipo_documento], [id_usuario], [estado], [id_fondo]) VALUES (4, CAST(N'2025-05-14T12:41:45.890' AS DateTime), N'wwwww', N'SDSD', N'Comprobante', 1, 1, 1)
INSERT [dbo].[tbl_gasto_encabezado] ([id_gasto_encabezado], [fecha], [observaciones], [nombre_comercio], [tipo_documento], [id_usuario], [estado], [id_fondo]) VALUES (5, CAST(N'2025-05-14T12:44:16.360' AS DateTime), N'wwwww', N'SDSD', N'Comprobante', 1, 1, 1)
INSERT [dbo].[tbl_gasto_encabezado] ([id_gasto_encabezado], [fecha], [observaciones], [nombre_comercio], [tipo_documento], [id_usuario], [estado], [id_fondo]) VALUES (6, CAST(N'2025-05-14T12:44:55.117' AS DateTime), N'wwwww', N'SDSD', N'Comprobante', 1, 1, 1)
INSERT [dbo].[tbl_gasto_encabezado] ([id_gasto_encabezado], [fecha], [observaciones], [nombre_comercio], [tipo_documento], [id_usuario], [estado], [id_fondo]) VALUES (7, CAST(N'2025-05-14T12:49:08.590' AS DateTime), N'wwwww', N'SDSD', N'Comprobante', 1, 0, 6)
INSERT [dbo].[tbl_gasto_encabezado] ([id_gasto_encabezado], [fecha], [observaciones], [nombre_comercio], [tipo_documento], [id_usuario], [estado], [id_fondo]) VALUES (8, CAST(N'2025-05-14T12:55:31.200' AS DateTime), N'aaa', N'ASD', N'Factura', 1, 1, 7)
INSERT [dbo].[tbl_gasto_encabezado] ([id_gasto_encabezado], [fecha], [observaciones], [nombre_comercio], [tipo_documento], [id_usuario], [estado], [id_fondo]) VALUES (9, CAST(N'2025-05-14T16:43:16.063' AS DateTime), N'prueba', N'PRUEBA 1', N'Comprobante', 1, 1, 6)
SET IDENTITY_INSERT [dbo].[tbl_gasto_encabezado] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_presupuesto] ON 

INSERT [dbo].[tbl_presupuesto] ([id_presupuesto], [id_usuario], [id_tipo_gasto], [monto], [estado], [anio], [mes]) VALUES (1, 1, 2, CAST(223.00 AS Decimal(10, 2)), 1, 0, 3)
INSERT [dbo].[tbl_presupuesto] ([id_presupuesto], [id_usuario], [id_tipo_gasto], [monto], [estado], [anio], [mes]) VALUES (2, 1, 2, CAST(223.00 AS Decimal(10, 2)), 1, 0, 3)
INSERT [dbo].[tbl_presupuesto] ([id_presupuesto], [id_usuario], [id_tipo_gasto], [monto], [estado], [anio], [mes]) VALUES (3, 1, 2, CAST(322.00 AS Decimal(10, 2)), 1, 2015, 1)
INSERT [dbo].[tbl_presupuesto] ([id_presupuesto], [id_usuario], [id_tipo_gasto], [monto], [estado], [anio], [mes]) VALUES (4, 1, 3, CAST(50.00 AS Decimal(10, 2)), 1, 2025, 1)
SET IDENTITY_INSERT [dbo].[tbl_presupuesto] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_tipo_fondo] ON 

INSERT [dbo].[tbl_tipo_fondo] ([id_tipo_fondo], [descripcion]) VALUES (1, N'Caja Chica')
INSERT [dbo].[tbl_tipo_fondo] ([id_tipo_fondo], [descripcion]) VALUES (2, N'Banco')
SET IDENTITY_INSERT [dbo].[tbl_tipo_fondo] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_tipo_gasto] ON 

INSERT [dbo].[tbl_tipo_gasto] ([id_tipo_gasto], [codigo], [descripcion], [estado]) VALUES (1, N'CRR22', N'TEST 2', 0)
INSERT [dbo].[tbl_tipo_gasto] ([id_tipo_gasto], [codigo], [descripcion], [estado]) VALUES (2, N'EC', N'ENERGÍA ELECTRÍCA', 1)
INSERT [dbo].[tbl_tipo_gasto] ([id_tipo_gasto], [codigo], [descripcion], [estado]) VALUES (3, N'EER', N'ALIMENTOS', 1)
SET IDENTITY_INSERT [dbo].[tbl_tipo_gasto] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_usuario] ON 

INSERT [dbo].[tbl_usuario] ([id_usuario], [identificacion], [nombre], [apellido], [usuario], [password], [fecha_nacimiento], [direccion], [correo], [telefono], [fecha_creacion], [estado], [path]) VALUES (1, N'1234567890123', N'Admin', N'Admin', N'admin', N'TeyZ9iaeO8TPJ0hJhlvBSw==', CAST(N'2000-01-01' AS Date), N'Ciudad', N'alejandrolopez445@gmail.com', N'99999999', CAST(N'2025-05-13T10:56:31.107' AS DateTime), 1, N'https://png.pngtree.com/png-vector/20190710/ourmid/pngtree-user-vector-avatar-png-image_1541962.jpg')
INSERT [dbo].[tbl_usuario] ([id_usuario], [identificacion], [nombre], [apellido], [usuario], [password], [fecha_nacimiento], [direccion], [correo], [telefono], [fecha_creacion], [estado], [path]) VALUES (2, N'123123', N'TEST', N'ASDAS', N'RET', N'1234', CAST(N'2000-01-20' AS Date), N'AAAAA', N'aaaa', N'55654455', CAST(N'2025-05-13T14:08:46.230' AS DateTime), 0, N'https://png.pngtree.com/png-vector/20190710/ourmid/pngtree-user-vector-avatar-png-image_1541962.jpg')
INSERT [dbo].[tbl_usuario] ([id_usuario], [identificacion], [nombre], [apellido], [usuario], [password], [fecha_nacimiento], [direccion], [correo], [telefono], [fecha_creacion], [estado], [path]) VALUES (3, N'12345', N'TEST', N'TEST', N'TEST', N'1234', CAST(N'2000-01-01' AS Date), N'CIUDAD', N'test', N'12312312', CAST(N'2025-05-14T16:50:36.667' AS DateTime), 1, N'https://png.pngtree.com/png-vector/20190710/ourmid/pngtree-user-vector-avatar-png-image_1541962.jpg')
INSERT [dbo].[tbl_usuario] ([id_usuario], [identificacion], [nombre], [apellido], [usuario], [password], [fecha_nacimiento], [direccion], [correo], [telefono], [fecha_creacion], [estado], [path]) VALUES (4, N'1231231232131', N'TEST', N'TEST', N'TESS', N'aF5G903Tf+hsuziGhtBhzw==', CAST(N'2000-01-01' AS Date), N'ASD', N'asd', N'12312312', CAST(N'2025-05-14T17:00:39.910' AS DateTime), 1, N'https://png.pngtree.com/png-vector/20190710/ourmid/pngtree-user-vector-avatar-png-image_1541962.jpg')
SET IDENTITY_INSERT [dbo].[tbl_usuario] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__tbl_tipo__40F9A20660763A8B]    Script Date: 14/05/2025 16:09:42 ******/
ALTER TABLE [dbo].[tbl_tipo_gasto] ADD UNIQUE NONCLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__tbl_usua__2A586E0B54A2C545]    Script Date: 14/05/2025 16:09:42 ******/
ALTER TABLE [dbo].[tbl_usuario] ADD UNIQUE NONCLUSTERED 
(
	[correo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__tbl_usua__9AFF8FC69072E070]    Script Date: 14/05/2025 16:09:42 ******/
ALTER TABLE [dbo].[tbl_usuario] ADD UNIQUE NONCLUSTERED 
(
	[usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__tbl_usua__C196DEC7C077EE03]    Script Date: 14/05/2025 16:09:42 ******/
ALTER TABLE [dbo].[tbl_usuario] ADD UNIQUE NONCLUSTERED 
(
	[identificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [idx_usuario_correo]    Script Date: 14/05/2025 16:09:42 ******/
CREATE NONCLUSTERED INDEX [idx_usuario_correo] ON [dbo].[tbl_usuario]
(
	[correo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [idx_usuario_login]    Script Date: 14/05/2025 16:09:42 ******/
CREATE NONCLUSTERED INDEX [idx_usuario_login] ON [dbo].[tbl_usuario]
(
	[usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_deposito] ADD  DEFAULT (getdate()) FOR [fecha]
GO
ALTER TABLE [dbo].[tbl_deposito] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[tbl_gasto_encabezado] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[tbl_deposito]  WITH CHECK ADD FOREIGN KEY([id_fondo])
REFERENCES [dbo].[tbl_fondo_monetario] ([id_fondo])
GO
ALTER TABLE [dbo].[tbl_deposito]  WITH CHECK ADD FOREIGN KEY([id_usuario])
REFERENCES [dbo].[tbl_usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[tbl_fondo_monetario]  WITH CHECK ADD FOREIGN KEY([id_tipo_fondo])
REFERENCES [dbo].[tbl_tipo_fondo] ([id_tipo_fondo])
GO
ALTER TABLE [dbo].[tbl_fondo_monetario]  WITH CHECK ADD FOREIGN KEY([id_usuario])
REFERENCES [dbo].[tbl_usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[tbl_gasto_detalle]  WITH CHECK ADD FOREIGN KEY([id_gasto_encabezado])
REFERENCES [dbo].[tbl_gasto_encabezado] ([id_gasto_encabezado])
GO
ALTER TABLE [dbo].[tbl_gasto_detalle]  WITH CHECK ADD FOREIGN KEY([id_tipo_gasto])
REFERENCES [dbo].[tbl_tipo_gasto] ([id_tipo_gasto])
GO
ALTER TABLE [dbo].[tbl_gasto_encabezado]  WITH CHECK ADD FOREIGN KEY([id_usuario])
REFERENCES [dbo].[tbl_usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[tbl_presupuesto]  WITH CHECK ADD FOREIGN KEY([id_tipo_gasto])
REFERENCES [dbo].[tbl_tipo_gasto] ([id_tipo_gasto])
GO
ALTER TABLE [dbo].[tbl_presupuesto]  WITH CHECK ADD FOREIGN KEY([id_usuario])
REFERENCES [dbo].[tbl_usuario] ([id_usuario])
GO
/****** Object:  StoredProcedure [dbo].[sp_eliminar_deposito]    Script Date: 14/05/2025 16:09:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_eliminar_deposito]
    @id_deposito INT
AS
BEGIN
    BEGIN TRY
        update tbl_deposito set estado=0 where id_deposito= @id_deposito
    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE() AS mensaje;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_eliminar_fondo_monetario]    Script Date: 14/05/2025 16:09:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_eliminar_fondo_monetario]
    @id_fondo INT
AS
BEGIN
    update tbl_fondo_monetario set estado=0 WHERE id_fondo = @id_fondo;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_eliminar_gasto]    Script Date: 14/05/2025 16:09:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_eliminar_gasto]
    @id_gasto_encabezado INT
AS
BEGIN
    BEGIN TRY
        update tbl_gasto_encabezado
		set estado=0
        WHERE id_gasto_encabezado = @id_gasto_encabezado;
    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE() AS mensaje;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_eliminar_presupuesto]    Script Date: 14/05/2025 16:09:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_eliminar_presupuesto]
    @id_presupuesto INT
AS
BEGIN
    update tbl_presupuesto set estado=0 WHERE id_presupuesto = @id_presupuesto;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_eliminar_tipo_gasto]    Script Date: 14/05/2025 16:09:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_eliminar_tipo_gasto]
    @id_tipo_gasto INT
AS
BEGIN
    update tbl_tipo_gasto set estado=0 WHERE id_tipo_gasto = @id_tipo_gasto;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_eliminar_usuario]    Script Date: 14/05/2025 16:09:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Procedimiento para actualizar un usuario existente en la tabla tbl_usuario
CREATE PROCEDURE [dbo].[sp_eliminar_usuario]
    @id_usuario INT
AS
BEGIN
    BEGIN TRY
            UPDATE tbl_usuario
            SET estado=0
            WHERE id_usuario = @id_usuario;
    END TRY
    BEGIN CATCH
        PRINT ERROR_MESSAGE();
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_insertar_deposito]    Script Date: 14/05/2025 16:09:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_insertar_deposito]
    @id_fondo INT,
    @monto DECIMAL(18,2),
    @id_usuario INT
AS
BEGIN
    BEGIN TRY
        INSERT INTO tbl_deposito (fecha, id_fondo, monto, id_usuario, estado)
        VALUES (dbo.GetDateSys(), @id_fondo, @monto, @id_usuario, 1);

        SELECT SCOPE_IDENTITY()
    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE() AS mensaje;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_insertar_fondo_monetario]    Script Date: 14/05/2025 16:09:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_insertar_fondo_monetario]
    @descripcion VARCHAR(50),
    @id_tipo_fondo INT,
    @id_usuario INT,
    @saldo DECIMAL(10,2)
AS
BEGIN
    INSERT INTO tbl_fondo_monetario (descripcion, id_tipo_fondo, id_usuario, saldo, estado)
    VALUES (@descripcion, @id_tipo_fondo, @id_usuario, @saldo,1);
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_insertar_gasto_detalle]    Script Date: 14/05/2025 16:09:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_insertar_gasto_detalle]
    @id_gasto_encabezado INT,
    @id_tipo_gasto INT,
    @monto DECIMAL(18,2)
AS
BEGIN
    BEGIN TRY
        INSERT INTO tbl_gasto_detalle (id_gasto_encabezado, id_tipo_gasto, monto)
        VALUES (@id_gasto_encabezado, @id_tipo_gasto, @monto);
    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE() AS mensaje;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_insertar_gasto_encabezado]    Script Date: 14/05/2025 16:09:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_insertar_gasto_encabezado]
    @id_fondo int,
    @observaciones VARCHAR(250),
    @nombre_comercio VARCHAR(100),
    @tipo_documento VARCHAR(50),
    @id_usuario INT
AS
BEGIN
    BEGIN TRY
        INSERT INTO tbl_gasto_encabezado (fecha, id_fondo, observaciones, nombre_comercio, tipo_documento, id_usuario, estado)
        VALUES (dbo.getdatesys(), @id_fondo, @observaciones, @nombre_comercio, @tipo_documento, @id_usuario, 1);

        SELECT SCOPE_IDENTITY() AS id_gasto_encabezado;
    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE() AS mensaje;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_insertar_presupuesto]    Script Date: 14/05/2025 16:09:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_insertar_presupuesto]
    @id_usuario INT,
    @id_tipo_gasto INT,
    @monto DECIMAL(10,2),
    @mes INT,
    @anio INT
AS
BEGIN
    INSERT INTO tbl_presupuesto (id_usuario, id_tipo_gasto, monto, mes, anio, estado)
    VALUES (@id_usuario, @id_tipo_gasto, @monto, @mes, @anio, 1);
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_insertar_tipo_gasto]    Script Date: 14/05/2025 16:09:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_insertar_tipo_gasto]
    @codigo VARCHAR(10),
    @descripcion VARCHAR(50)
AS
BEGIN
    INSERT INTO tbl_tipo_gasto (codigo, descripcion, estado)
    VALUES (@codigo, @descripcion, 1);
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_insertar_usuario]    Script Date: 14/05/2025 16:09:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_insertar_usuario]
    @identificacion VARCHAR(20),
    @nombre VARCHAR(50),
    @apellido VARCHAR(50),
    @usuario VARCHAR(20),
    @password VARCHAR(100),
    @fecha_nacimiento DATE,
    @direccion VARCHAR(100),
    @correo VARCHAR(50),
    @telefono VARCHAR(15)
AS
BEGIN
    BEGIN TRY
        -- Verificar si el usuario ya existe por identificación, usuario o correo
        IF NOT EXISTS (SELECT 1 FROM tbl_usuario WHERE identificacion = @identificacion OR usuario = @usuario OR correo = @correo)
        BEGIN
			INSERT INTO tbl_usuario (identificacion, nombre, apellido, usuario, password, fecha_nacimiento, direccion, correo, telefono, estado, fecha_creacion, path)
			VALUES (@identificacion, @nombre, @apellido, @usuario, @password, @fecha_nacimiento, @direccion, @correo, @telefono, 1, dbo.GetDateSys(), 'https://png.pngtree.com/png-vector/20190710/ourmid/pngtree-user-vector-avatar-png-image_1541962.jpg');
        END
    END TRY
    BEGIN CATCH
        PRINT 'Error al insertar el usuario: ' + ERROR_MESSAGE();
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_listar_depositos]    Script Date: 14/05/2025 16:09:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_listar_depositos]
AS
BEGIN
    BEGIN TRY
        SELECT 
            d.id_deposito,
            d.fecha,
            f.descripcion AS fondo_monetario,
            d.monto,
            u.nombre AS usuario,
            d.estado
        FROM 
            tbl_deposito d
        INNER JOIN 
            tbl_fondo_monetario f ON d.id_fondo = f.id_fondo
        INNER JOIN 
            tbl_usuario u ON d.id_usuario = u.id_usuario
        ORDER BY 
            d.fecha DESC;

    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE() AS mensaje;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_listar_fondo_monetario]    Script Date: 14/05/2025 16:09:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_listar_fondo_monetario]
AS
BEGIN
    SELECT f.id_fondo, f.descripcion, tf.descripcion AS tipo_fondo, u.nombre AS usuario, f.saldo, f.estado, tf.id_tipo_fondo
    FROM tbl_fondo_monetario f
    JOIN tbl_tipo_fondo tf ON f.id_tipo_fondo = tf.id_tipo_fondo
    JOIN tbl_usuario u ON f.id_usuario = u.id_usuario;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_listar_gasto_detalle]    Script Date: 14/05/2025 16:09:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_listar_gasto_detalle]
    @id_gasto_encabezado INT
AS
BEGIN
    BEGIN TRY
        SELECT 
            d.id_gasto_detalle,
            d.id_gasto_encabezado,
            d.id_tipo_gasto,
			tg.codigo,
            tg.descripcion,
            d.monto
        FROM 
            tbl_gasto_detalle d
        INNER JOIN 
            tbl_tipo_gasto tg ON d.id_tipo_gasto = tg.id_tipo_gasto
        WHERE 
            d.id_gasto_encabezado = @id_gasto_encabezado
        ORDER BY 
            d.id_gasto_detalle ASC;
    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE() AS mensaje;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_listar_gasto_encabezado]    Script Date: 14/05/2025 16:09:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_listar_gasto_encabezado]
AS
BEGIN
    BEGIN TRY
        SELECT 
            e.id_gasto_encabezado,
            e.fecha,
            e.id_fondo,
            e.observaciones,
            e.nombre_comercio,
            e.tipo_documento,
            u.id_usuario,
            CONCAT(u.nombre,' ',u.apellido) AS usuario,
			f.descripcion,
            e.estado
        FROM 
            tbl_gasto_encabezado e
        INNER JOIN tbl_usuario u ON e.id_usuario = u.id_usuario
		inner join tbl_fondo_monetario f on f.id_fondo=e.id_fondo
        ORDER BY 
            e.fecha DESC;
    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE() AS mensaje;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_listar_presupuesto_por_usuario]    Script Date: 14/05/2025 16:09:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_listar_presupuesto_por_usuario]
    @id_usuario INT,
    @mes INT,
    @anio INT
AS
BEGIN
    SELECT p.id_presupuesto, p.monto, p.mes, p.anio, g.descripcion AS tipo_gasto, p.estado
    FROM tbl_presupuesto p
    JOIN tbl_tipo_gasto g ON p.id_tipo_gasto = g.id_tipo_gasto
    WHERE p.id_usuario = @id_usuario AND p.mes = @mes AND p.anio = @anio;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_listar_tipo_gasto]    Script Date: 14/05/2025 16:09:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_listar_tipo_gasto]
AS
BEGIN
    SELECT *
    FROM tbl_tipo_gasto;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_listar_usuario]    Script Date: 14/05/2025 16:09:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_listar_usuario] 
as begin
select*from tbl_usuario
end
GO
/****** Object:  StoredProcedure [dbo].[sp_listar_usuario_por_id]    Script Date: 14/05/2025 16:09:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_listar_usuario_por_id] (@id_usuario int)
as begin
select*from tbl_usuario where id_usuario=@id_usuario
end
GO
/****** Object:  StoredProcedure [dbo].[sp_login]    Script Date: 14/05/2025 16:09:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_login]
    @usuario VARCHAR(20),
    @password VARCHAR(100)
AS
BEGIN
    SELECT *
    FROM tbl_usuario
    WHERE usuario = @usuario and password = @password;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_modificar_fondo_monetario]    Script Date: 14/05/2025 16:09:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_modificar_fondo_monetario]
    @id_fondo INT,
    @descripcion VARCHAR(50),
    @id_tipo_fondo INT,
    @id_usuario INT,
    @saldo DECIMAL(10,2)
AS
BEGIN
    UPDATE tbl_fondo_monetario
    SET descripcion = @descripcion,
        id_tipo_fondo = @id_tipo_fondo,
        id_usuario = @id_usuario,
        saldo = @saldo
    WHERE id_fondo = @id_fondo;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_modificar_presupuesto]    Script Date: 14/05/2025 16:09:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_modificar_presupuesto]
    @id_presupuesto INT,
    @id_tipo_gasto INT,
    @monto DECIMAL(10,2),
    @mes INT,
    @anio INT,
    @estado INT
AS
BEGIN
    update tbl_presupuesto 
	set 
		id_tipo_gasto=@id_tipo_gasto, 
		monto=@monto, 
		mes=@mes, 
		anio=@anio
	where id_presupuesto=@id_presupuesto
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_modificar_tipo_gasto]    Script Date: 14/05/2025 16:09:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_modificar_tipo_gasto]
    @id_tipo_gasto INT,
    @codigo VARCHAR(10),
    @descripcion VARCHAR(50)
AS
BEGIN
    UPDATE tbl_tipo_gasto
    SET codigo = @codigo, descripcion = @descripcion
    WHERE id_tipo_gasto = @id_tipo_gasto;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_modificar_usuario]    Script Date: 14/05/2025 16:09:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_modificar_usuario]
    @id_usuario INT,
    @identificacion VARCHAR(20),
    @nombre VARCHAR(50),
    @apellido VARCHAR(50),
    @usuario VARCHAR(20),
    @fecha_nacimiento DATE,
    @direccion VARCHAR(100),
    @correo VARCHAR(50),
    @telefono VARCHAR(15)
AS
BEGIN
    BEGIN TRY
            UPDATE tbl_usuario
            SET identificacion = @identificacion,
                nombre = @nombre,
                apellido = @apellido,
                usuario = @usuario,
                fecha_nacimiento = @fecha_nacimiento,
                direccion = @direccion,
                correo = @correo,
                telefono = @telefono
            WHERE id_usuario = @id_usuario;
    END TRY
    BEGIN CATCH
        PRINT ERROR_MESSAGE();
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_reporte_deposito]    Script Date: 14/05/2025 16:09:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_reporte_deposito] (@fecha_inicial date, @fecha_final date)
as
begin
select a.fecha, b.descripcion, a.monto, CONCAT(c.nombre,' ', c.apellido) as usuario, a.estado
from tbl_deposito a
inner join tbl_fondo_monetario b on a.id_fondo=b.id_fondo
inner join tbl_usuario c on c.id_usuario=a.id_usuario
where FORMAT(a.fecha,'yyyy-MM-dd') between FORMAT(@fecha_inicial,'yyyy-MM-dd') and FORMAT(@fecha_final,'yyyy-MM-dd')
end
GO
/****** Object:  StoredProcedure [dbo].[sp_reporte_gasto]    Script Date: 14/05/2025 16:09:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_reporte_gasto] (@fecha_inicial date, @fecha_final date)
as
begin
select a.fecha, a.observaciones, a.nombre_comercio, a.tipo_documento, CONCAT(c.nombre,' ', c.apellido) as usuario, a.estado, b.descripcion, e.descripcion as tipo_gasto, d.monto
from tbl_gasto_encabezado a
inner join tbl_fondo_monetario b on a.id_fondo=b.id_fondo
inner join tbl_usuario c on c.id_usuario=a.id_usuario
inner join tbl_gasto_detalle d on d.id_gasto_encabezado=a.id_gasto_encabezado
inner join tbl_tipo_gasto e on e.id_tipo_gasto=d.id_tipo_gasto
where FORMAT(a.fecha,'yyyy-MM-dd') between FORMAT(@fecha_inicial,'yyyy-MM-dd') and FORMAT(@fecha_final,'yyyy-MM-dd')
end


GO
/****** Object:  StoredProcedure [dbo].[sp_reporte_grafico_presupuesto_vs_ejecucion]    Script Date: 14/05/2025 16:09:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_reporte_grafico_presupuesto_vs_ejecucion]
    @fecha_inicio DATE,
    @fecha_final DATE
AS
BEGIN
    BEGIN TRY
        SELECT 
			tg.descripcion AS tipo_gasto,
			COALESCE(SUM(p.monto), 0) AS monto_presupuestado,
			COALESCE(SUM(gd.monto), 0) AS monto_ejecutado
		FROM 
			tbl_tipo_gasto tg
		LEFT JOIN tbl_presupuesto p ON p.id_tipo_gasto = tg.id_tipo_gasto 
			AND (CONVERT(VARCHAR, p.anio) + RIGHT('0' + CONVERT(VARCHAR, p.mes), 2)) 
				BETWEEN (CONVERT(VARCHAR, YEAR(@fecha_inicio)) + RIGHT('0' + CONVERT(VARCHAR, MONTH(@fecha_inicio)), 2))
				AND (CONVERT(VARCHAR, YEAR(@fecha_final)) + RIGHT('0' + CONVERT(VARCHAR, MONTH(@fecha_final)), 2))
		LEFT JOIN tbl_gasto_detalle gd ON gd.id_tipo_gasto = tg.id_tipo_gasto
		LEFT JOIN tbl_gasto_encabezado ge ON ge.id_gasto_encabezado = gd.id_gasto_encabezado
			AND FORMAT(ge.fecha, 'yyyy-MM-dd') BETWEEN FORMAT(@fecha_inicio, 'yyyy-MM-dd') AND FORMAT(@fecha_final, 'yyyy-MM-dd')
		GROUP BY 
			tg.descripcion;
    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE() AS mensaje;
    END CATCH
END;
GO
USE [master]
GO
ALTER DATABASE [db_a8e200_testgastos] SET  READ_WRITE 
GO
