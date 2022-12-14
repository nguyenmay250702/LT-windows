USE [master]
GO
/****** Object:  Database [QL_Sach]    Script Date: 06/01/2022 22:56:23 ******/
CREATE DATABASE [QL_Sach] ON  PRIMARY 
( NAME = N'QL_Sach', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\QL_Sach.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QL_Sach_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\QL_Sach_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QL_Sach] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QL_Sach].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QL_Sach] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [QL_Sach] SET ANSI_NULLS OFF
GO
ALTER DATABASE [QL_Sach] SET ANSI_PADDING OFF
GO
ALTER DATABASE [QL_Sach] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [QL_Sach] SET ARITHABORT OFF
GO
ALTER DATABASE [QL_Sach] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [QL_Sach] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [QL_Sach] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [QL_Sach] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [QL_Sach] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [QL_Sach] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [QL_Sach] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [QL_Sach] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [QL_Sach] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [QL_Sach] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [QL_Sach] SET  DISABLE_BROKER
GO
ALTER DATABASE [QL_Sach] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [QL_Sach] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [QL_Sach] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [QL_Sach] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [QL_Sach] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [QL_Sach] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [QL_Sach] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [QL_Sach] SET  READ_WRITE
GO
ALTER DATABASE [QL_Sach] SET RECOVERY SIMPLE
GO
ALTER DATABASE [QL_Sach] SET  MULTI_USER
GO
ALTER DATABASE [QL_Sach] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [QL_Sach] SET DB_CHAINING OFF
GO
USE [QL_Sach]
GO
/****** Object:  Table [dbo].[NXB]    Script Date: 06/01/2022 22:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NXB](
	[MaNXB] [char](10) NULL,
	[TenNXB] [nvarchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
