USE [master]
GO
/****** Object:  Database [prjprn]    Script Date: 11/6/2024 10:29:57 PM ******/
CREATE DATABASE [prjprn]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'prjprn', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\prjprn.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'prjprn_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\prjprn_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [prjprn] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [prjprn].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [prjprn] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [prjprn] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [prjprn] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [prjprn] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [prjprn] SET ARITHABORT OFF 
GO
ALTER DATABASE [prjprn] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [prjprn] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [prjprn] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [prjprn] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [prjprn] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [prjprn] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [prjprn] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [prjprn] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [prjprn] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [prjprn] SET  ENABLE_BROKER 
GO
ALTER DATABASE [prjprn] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [prjprn] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [prjprn] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [prjprn] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [prjprn] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [prjprn] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [prjprn] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [prjprn] SET RECOVERY FULL 
GO
ALTER DATABASE [prjprn] SET  MULTI_USER 
GO
ALTER DATABASE [prjprn] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [prjprn] SET DB_CHAINING OFF 
GO
ALTER DATABASE [prjprn] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [prjprn] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [prjprn] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [prjprn] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'prjprn', N'ON'
GO
ALTER DATABASE [prjprn] SET QUERY_STORE = ON
GO
ALTER DATABASE [prjprn] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [prjprn]
GO
/****** Object:  Table [dbo].[answer]    Script Date: 11/6/2024 10:29:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[answer](
	[idcauhoi] [int] IDENTITY(1,1) NOT NULL,
	[causo] [int] NULL,
	[dapan] [varchar](10) NULL,
	[idmade] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idcauhoi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[class]    Script Date: 11/6/2024 10:29:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[class](
	[classid] [int] IDENTITY(1,1) NOT NULL,
	[classname] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[classid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[subjecttable]    Script Date: 11/6/2024 10:29:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[subjecttable](
	[subjectid] [int] IDENTITY(1,1) NOT NULL,
	[subjectname] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[subjectid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[teacher]    Script Date: 11/6/2024 10:29:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[teacher](
	[teacherid] [int] IDENTITY(1,1) NOT NULL,
	[teachername] [nvarchar](255) NULL,
	[email] [nvarchar](255) NULL,
	[password] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[teacherid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[teacher_subject]    Script Date: 11/6/2024 10:29:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[teacher_subject](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[teacherid] [int] NULL,
	[subjectid] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[titlecode]    Script Date: 11/6/2024 10:29:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[titlecode](
	[titlecodeid] [int] IDENTITY(1,1) NOT NULL,
	[titlecodenumber] [int] NULL,
	[classid] [int] NULL,
	[teacher_subject_id] [int] NULL,
	[totalmark] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[titlecodeid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[answer] ON 

INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (1, 1, N'C', 1)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (2, 2, N'C', 1)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (3, 3, N'B', 1)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (4, 4, N'D', 1)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (5, 5, N'B', 1)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (6, 6, N'A', 1)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (7, 7, N'D', 1)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (8, 8, N'B', 1)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (9, 9, N'B', 1)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (10, 10, N'C', 1)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (11, 11, N'A', 1)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (12, 12, N'B', 1)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (13, 13, N'C', 1)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (14, 14, N'A', 1)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (15, 15, N'B', 1)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (16, 16, N'A', 1)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (17, 17, N'D', 1)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (18, 18, N'B', 1)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (19, 19, N'A', 1)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (20, 20, N'D', 1)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (21, 21, N'C', 1)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (22, 22, N'C', 1)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (23, 23, N'D', 1)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (24, 24, N'A', 1)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (25, 25, N'C', 1)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (26, 26, N'A', 1)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (27, 27, N'C', 1)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (28, 28, N'D', 1)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (29, 29, N'B', 1)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (30, 30, N'B', 1)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (31, 31, N'D', 1)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (32, 32, N'D', 1)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (33, 33, N'B', 1)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (34, 34, N'C', 1)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (35, 35, N'A', 1)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (36, 1, N'D', 2)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (37, 2, N'D', 2)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (38, 3, N'C', 2)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (39, 4, N'B', 2)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (40, 5, N'B', 2)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (41, 6, N'C', 2)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (42, 7, N'B', 2)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (43, 8, N'A', 2)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (44, 9, N'A', 2)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (45, 10, N'D', 2)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (46, 11, N'C', 2)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (47, 12, N'B', 2)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (48, 13, N'DSSD', 2)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (49, 14, N'DDDD', 2)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (50, 15, N'SSSD', 2)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (51, 16, N'SSDS', 2)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (52, 17, N'-24', 2)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (53, 18, N'38', 2)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (54, 19, N'50', 2)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (55, 20, N'1.3', 2)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (56, 21, N'7', 2)
INSERT [dbo].[answer] ([idcauhoi], [causo], [dapan], [idmade]) VALUES (57, 22, N'10', 2)
SET IDENTITY_INSERT [dbo].[answer] OFF
GO
SET IDENTITY_INSERT [dbo].[class] ON 

INSERT [dbo].[class] ([classid], [classname]) VALUES (1, N'10')
INSERT [dbo].[class] ([classid], [classname]) VALUES (2, N'10A')
INSERT [dbo].[class] ([classid], [classname]) VALUES (3, N'10B')
INSERT [dbo].[class] ([classid], [classname]) VALUES (4, N'10C')
INSERT [dbo].[class] ([classid], [classname]) VALUES (5, N'10D')
INSERT [dbo].[class] ([classid], [classname]) VALUES (6, N'10E')
INSERT [dbo].[class] ([classid], [classname]) VALUES (7, N'11')
INSERT [dbo].[class] ([classid], [classname]) VALUES (8, N'11A')
INSERT [dbo].[class] ([classid], [classname]) VALUES (9, N'11B')
INSERT [dbo].[class] ([classid], [classname]) VALUES (10, N'11C')
INSERT [dbo].[class] ([classid], [classname]) VALUES (11, N'12')
INSERT [dbo].[class] ([classid], [classname]) VALUES (12, N'12A')
INSERT [dbo].[class] ([classid], [classname]) VALUES (13, N'12B')
SET IDENTITY_INSERT [dbo].[class] OFF
GO
SET IDENTITY_INSERT [dbo].[subjecttable] ON 

INSERT [dbo].[subjecttable] ([subjectid], [subjectname]) VALUES (1, N'Toán học')
SET IDENTITY_INSERT [dbo].[subjecttable] OFF
GO
SET IDENTITY_INSERT [dbo].[teacher] ON 

INSERT [dbo].[teacher] ([teacherid], [teachername], [email], [password]) VALUES (1, N'Nguyễn Thị Thủy Vang', N'vangvanglong79@gmail.com', N'e10adc3949ba59abbe56e057f20f883e')
SET IDENTITY_INSERT [dbo].[teacher] OFF
GO
SET IDENTITY_INSERT [dbo].[teacher_subject] ON 

INSERT [dbo].[teacher_subject] ([id], [teacherid], [subjectid]) VALUES (1, 1, 1)
SET IDENTITY_INSERT [dbo].[teacher_subject] OFF
GO
SET IDENTITY_INSERT [dbo].[titlecode] ON 

INSERT [dbo].[titlecode] ([titlecodeid], [titlecodenumber], [classid], [teacher_subject_id], [totalmark]) VALUES (1, 1, 7, 1, 7)
INSERT [dbo].[titlecode] ([titlecodeid], [titlecodenumber], [classid], [teacher_subject_id], [totalmark]) VALUES (2, 102, 11, 1, 10)
SET IDENTITY_INSERT [dbo].[titlecode] OFF
GO
/****** Object:  Index [UC_CaudoMade]    Script Date: 11/6/2024 10:29:58 PM ******/
ALTER TABLE [dbo].[answer] ADD  CONSTRAINT [UC_CaudoMade] UNIQUE NONCLUSTERED 
(
	[causo] ASC,
	[idmade] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__class__279D4814D517BB27]    Script Date: 11/6/2024 10:29:58 PM ******/
ALTER TABLE [dbo].[class] ADD UNIQUE NONCLUSTERED 
(
	[classname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__subjectt__E8560E883C182970]    Script Date: 11/6/2024 10:29:58 PM ******/
ALTER TABLE [dbo].[subjecttable] ADD UNIQUE NONCLUSTERED 
(
	[subjectname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__teacher___0224509B1A9EF335]    Script Date: 11/6/2024 10:29:58 PM ******/
ALTER TABLE [dbo].[teacher_subject] ADD UNIQUE NONCLUSTERED 
(
	[teacherid] ASC,
	[subjectid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UC_TitleCode]    Script Date: 11/6/2024 10:29:58 PM ******/
ALTER TABLE [dbo].[titlecode] ADD  CONSTRAINT [UC_TitleCode] UNIQUE NONCLUSTERED 
(
	[classid] ASC,
	[teacher_subject_id] ASC,
	[titlecodenumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[answer]  WITH CHECK ADD FOREIGN KEY([idmade])
REFERENCES [dbo].[titlecode] ([titlecodeid])
GO
ALTER TABLE [dbo].[teacher_subject]  WITH CHECK ADD FOREIGN KEY([subjectid])
REFERENCES [dbo].[subjecttable] ([subjectid])
GO
ALTER TABLE [dbo].[teacher_subject]  WITH CHECK ADD FOREIGN KEY([teacherid])
REFERENCES [dbo].[teacher] ([teacherid])
GO
ALTER TABLE [dbo].[titlecode]  WITH CHECK ADD FOREIGN KEY([classid])
REFERENCES [dbo].[class] ([classid])
GO
ALTER TABLE [dbo].[titlecode]  WITH CHECK ADD FOREIGN KEY([teacher_subject_id])
REFERENCES [dbo].[teacher_subject] ([id])
GO
USE [master]
GO
ALTER DATABASE [prjprn] SET  READ_WRITE 
GO
