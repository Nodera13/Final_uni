USE [master]
GO
/****** Object:  Database [Final]    Script Date: 06/02/2020 09:49:14 ******/
CREATE DATABASE [Final]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Final', FILENAME = N'C:\SQL2019\MSSQL15.MSSQLSERVER\MSSQL\DATA\Final.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Final_log', FILENAME = N'C:\SQL2019\MSSQL15.MSSQLSERVER\MSSQL\DATA\Final_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Final] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Final].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Final] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Final] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Final] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Final] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Final] SET ARITHABORT OFF 
GO
ALTER DATABASE [Final] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Final] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Final] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Final] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Final] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Final] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Final] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Final] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Final] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Final] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Final] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Final] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Final] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Final] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Final] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Final] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Final] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Final] SET RECOVERY FULL 
GO
ALTER DATABASE [Final] SET  MULTI_USER 
GO
ALTER DATABASE [Final] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Final] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Final] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Final] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Final] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Final', N'ON'
GO
ALTER DATABASE [Final] SET QUERY_STORE = OFF
GO
USE [Final]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 06/02/2020 09:49:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Price] [int] NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 06/02/2020 09:49:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Type] [nvarchar](255) NOT NULL,
	[Cost] [int] NOT NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 06/02/2020 09:49:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[Privilage] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [Final] SET  READ_WRITE 
GO