USE [master]
GO
/****** Object:  Database [libraryDB]    Script Date: 04/05/2026 01:00:16 ******/
CREATE DATABASE [libraryDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'libraryDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\library DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'libraryDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\library DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [libraryDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [libraryDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [libraryDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [libraryDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [libraryDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [libraryDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [libraryDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [libraryDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [libraryDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [libraryDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [libraryDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [libraryDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [libraryDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [libraryDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [libraryDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [libraryDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [libraryDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [libraryDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [libraryDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [libraryDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [libraryDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [libraryDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [libraryDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [libraryDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [libraryDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [libraryDB] SET  MULTI_USER 
GO
ALTER DATABASE [libraryDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [libraryDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [libraryDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [libraryDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [libraryDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [libraryDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [libraryDB] SET QUERY_STORE = OFF
GO
USE [libraryDB]
GO
/****** Object:  Table [dbo].[Access]    Script Date: 04/05/2026 01:00:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Access](
	[ID] [int] NOT NULL,
	[StudentID] [int] NOT NULL,
	[BookCode] [int] NOT NULL,
 CONSTRAINT [PK_Access] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[books]    Script Date: 04/05/2026 01:00:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[books](
	[BookCode] [int] NOT NULL,
	[Titel] [nvarchar](100) NOT NULL,
	[Author] [nvarchar](100) NOT NULL,
	[StudentID] [int] NOT NULL,
 CONSTRAINT [PK_books] PRIMARY KEY CLUSTERED 
(
	[BookCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Librarian]    Script Date: 04/05/2026 01:00:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Librarian](
	[AdminID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Librarian] PRIMARY KEY CLUSTERED 
(
	[AdminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 04/05/2026 01:00:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Department] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Access] ([ID], [StudentID], [BookCode]) VALUES (5, 1081, 4887)
INSERT [dbo].[Access] ([ID], [StudentID], [BookCode]) VALUES (6, 1002, 9261)
INSERT [dbo].[Access] ([ID], [StudentID], [BookCode]) VALUES (7, 1003, 1054)
INSERT [dbo].[Access] ([ID], [StudentID], [BookCode]) VALUES (8, 1004, 7789)
INSERT [dbo].[Access] ([ID], [StudentID], [BookCode]) VALUES (9, 1005, 3620)
INSERT [dbo].[Access] ([ID], [StudentID], [BookCode]) VALUES (10, 1006, 8945)
INSERT [dbo].[Access] ([ID], [StudentID], [BookCode]) VALUES (11, 1007, 2176)
INSERT [dbo].[Access] ([ID], [StudentID], [BookCode]) VALUES (12, 1008, 6503)
INSERT [dbo].[Access] ([ID], [StudentID], [BookCode]) VALUES (13, 1009, 4318)
INSERT [dbo].[Access] ([ID], [StudentID], [BookCode]) VALUES (14, 3002, 9902)
INSERT [dbo].[Access] ([ID], [StudentID], [BookCode]) VALUES (15, 1020, 1467)
INSERT [dbo].[Access] ([ID], [StudentID], [BookCode]) VALUES (16, 1015, 5839)
INSERT [dbo].[Access] ([ID], [StudentID], [BookCode]) VALUES (17, 1016, 7024)
INSERT [dbo].[Access] ([ID], [StudentID], [BookCode]) VALUES (18, 1018, 2681)
INSERT [dbo].[Access] ([ID], [StudentID], [BookCode]) VALUES (19, 1410, 8196)
INSERT [dbo].[Access] ([ID], [StudentID], [BookCode]) VALUES (20, 1411, 3742)
INSERT [dbo].[Access] ([ID], [StudentID], [BookCode]) VALUES (21, 2111, 9057)
INSERT [dbo].[Access] ([ID], [StudentID], [BookCode]) VALUES (22, 1219, 1128)
INSERT [dbo].[Access] ([ID], [StudentID], [BookCode]) VALUES (23, 4592, 6574)
INSERT [dbo].[Access] ([ID], [StudentID], [BookCode]) VALUES (24, 6448, 4390)
INSERT [dbo].[Access] ([ID], [StudentID], [BookCode]) VALUES (25, 9843, 7865)
GO
INSERT [dbo].[books] ([BookCode], [Titel], [Author], [StudentID]) VALUES (1054, N' Computer Networking: A Top-Down Approach ', N'James F. Kurose, Keith W. Ross', 1003)
INSERT [dbo].[books] ([BookCode], [Titel], [Author], [StudentID]) VALUES (1128, N'The C Programming Language', N'Brian W. Kernighan, Dennis M. Ritchie', 1219)
INSERT [dbo].[books] ([BookCode], [Titel], [Author], [StudentID]) VALUES (1467, N'Modern Database Management', N'Jeffrey A. Hoffer, V. Ramesh, Heikki Topi', 1020)
INSERT [dbo].[books] ([BookCode], [Titel], [Author], [StudentID]) VALUES (2176, N'Computer Organization and Design', N'David A. Patterson, John L. Hennessy', 1007)
INSERT [dbo].[books] ([BookCode], [Titel], [Author], [StudentID]) VALUES (2681, N'The Mythical Man-Month', N'Frederick P. Brooks Jr', 1018)
INSERT [dbo].[books] ([BookCode], [Titel], [Author], [StudentID]) VALUES (3620, N'The Pragmatic Programmer', N'Andrew Hunt, David Thomas', 1005)
INSERT [dbo].[books] ([BookCode], [Titel], [Author], [StudentID]) VALUES (3742, N' Code Complete', N'Steve McConnell', 1411)
INSERT [dbo].[books] ([BookCode], [Titel], [Author], [StudentID]) VALUES (4318, N' Systems Analysis and Design', N' Alan Dennis, Barbara Haley Wixom, Roberta M. Roth', 1009)
INSERT [dbo].[books] ([BookCode], [Titel], [Author], [StudentID]) VALUES (4390, N'Engineering Software as a Service', N'Armando Fox, David Patterson', 6448)
INSERT [dbo].[books] ([BookCode], [Titel], [Author], [StudentID]) VALUES (4887, N'Introduction to Algorithms', N'Thomas H. Cormen', 1081)
INSERT [dbo].[books] ([BookCode], [Titel], [Author], [StudentID]) VALUES (5839, N'Information Systems Today', N' Joseph S. Valacich, Christoph Schneider', 1015)
INSERT [dbo].[books] ([BookCode], [Titel], [Author], [StudentID]) VALUES (6503, N'Management Information Systems', N' Kenneth C. Laudon, Jane P. Laudon', 1008)
INSERT [dbo].[books] ([BookCode], [Titel], [Author], [StudentID]) VALUES (6574, N'Structure and Interpretation of Computer Programs ', N' Harold Abelson, Gerald Jay Sussman', 4592)
INSERT [dbo].[books] ([BookCode], [Titel], [Author], [StudentID]) VALUES (7024, N' Software Engineering ', N'Ian Sommerville', 1016)
INSERT [dbo].[books] ([BookCode], [Titel], [Author], [StudentID]) VALUES (7789, N'Clean Code ', N' Robert C. Martin', 1004)
INSERT [dbo].[books] ([BookCode], [Titel], [Author], [StudentID]) VALUES (7865, N'Machine Learning ', N'Tom M. Mitchell', 9843)
INSERT [dbo].[books] ([BookCode], [Titel], [Author], [StudentID]) VALUES (8196, N'Design Patterns', N' Erich Gamma, Richard Helm, Ralph Johnson, John Vlissides', 1410)
INSERT [dbo].[books] ([BookCode], [Titel], [Author], [StudentID]) VALUES (8945, N'Operating System Concepts ', N'Abraham Silberschatz, Peter B. Galvin, Greg Gagne
', 1006)
INSERT [dbo].[books] ([BookCode], [Titel], [Author], [StudentID]) VALUES (9057, N'Digital Design and Computer Architecture ', N' Sarah Harris, David Harris', 2111)
INSERT [dbo].[books] ([BookCode], [Titel], [Author], [StudentID]) VALUES (9261, N'Artificial Intelligence A Modern Approach', N'Stuart Russell, Peter Norvig', 1002)
INSERT [dbo].[books] ([BookCode], [Titel], [Author], [StudentID]) VALUES (9902, N'Database System Concepts ', N'Abraham Silberschatz, Henry F. Korth, S. Sudarshan', 3002)
GO
SET IDENTITY_INSERT [dbo].[Librarian] ON 

INSERT [dbo].[Librarian] ([AdminID], [Name]) VALUES (7, N'AHMED')
SET IDENTITY_INSERT [dbo].[Librarian] OFF
GO
INSERT [dbo].[Student] ([ID], [Name], [Department]) VALUES (1002, N'Nour', N'IT')
INSERT [dbo].[Student] ([ID], [Name], [Department]) VALUES (1003, N'Mariam', N'IT')
INSERT [dbo].[Student] ([ID], [Name], [Department]) VALUES (1004, N'Hany', N'CS')
INSERT [dbo].[Student] ([ID], [Name], [Department]) VALUES (1005, N'Mostafa', N'ENG')
INSERT [dbo].[Student] ([ID], [Name], [Department]) VALUES (1006, N'Farah', N'ENG')
INSERT [dbo].[Student] ([ID], [Name], [Department]) VALUES (1007, N'Shahd', N'BA')
INSERT [dbo].[Student] ([ID], [Name], [Department]) VALUES (1008, N'Hassan', N'ENG')
INSERT [dbo].[Student] ([ID], [Name], [Department]) VALUES (1009, N'Manal', N'CS')
INSERT [dbo].[Student] ([ID], [Name], [Department]) VALUES (1015, N'Sherif', N'IT')
INSERT [dbo].[Student] ([ID], [Name], [Department]) VALUES (1016, N'Shady', N'IT')
INSERT [dbo].[Student] ([ID], [Name], [Department]) VALUES (1018, N'Shams', N'IT')
INSERT [dbo].[Student] ([ID], [Name], [Department]) VALUES (1020, N'Wael', N'IT')
INSERT [dbo].[Student] ([ID], [Name], [Department]) VALUES (1081, N'Omar', N'CS')
INSERT [dbo].[Student] ([ID], [Name], [Department]) VALUES (1219, N'Esraa', N'BA')
INSERT [dbo].[Student] ([ID], [Name], [Department]) VALUES (1410, N'Hady', N'ENG')
INSERT [dbo].[Student] ([ID], [Name], [Department]) VALUES (1411, N'Hany', N'ENG')
INSERT [dbo].[Student] ([ID], [Name], [Department]) VALUES (2111, N'Khaled', N'BA')
INSERT [dbo].[Student] ([ID], [Name], [Department]) VALUES (3002, N'Karim', N'BA')
INSERT [dbo].[Student] ([ID], [Name], [Department]) VALUES (4592, N'Mona', N'IT')
INSERT [dbo].[Student] ([ID], [Name], [Department]) VALUES (6448, N'Eman', N'CS')
INSERT [dbo].[Student] ([ID], [Name], [Department]) VALUES (9843, N'Fatma', N'ENG')
GO
USE [master]
GO
ALTER DATABASE [libraryDB] SET  READ_WRITE 
GO