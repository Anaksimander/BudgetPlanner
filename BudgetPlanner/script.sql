USE [master]
GO
/****** Object:  Database [OperationBd]    Script Date: 02.06.2022 0:31:56 ******/
CREATE DATABASE [OperationBd]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'operationBd', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\operationBd.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'operationBd_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\operationBd_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [OperationBd] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OperationBd].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OperationBd] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OperationBd] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OperationBd] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OperationBd] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OperationBd] SET ARITHABORT OFF 
GO
ALTER DATABASE [OperationBd] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OperationBd] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OperationBd] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OperationBd] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OperationBd] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OperationBd] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OperationBd] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OperationBd] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OperationBd] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OperationBd] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OperationBd] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OperationBd] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OperationBd] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OperationBd] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OperationBd] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OperationBd] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OperationBd] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OperationBd] SET RECOVERY FULL 
GO
ALTER DATABASE [OperationBd] SET  MULTI_USER 
GO
ALTER DATABASE [OperationBd] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OperationBd] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OperationBd] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OperationBd] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OperationBd] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OperationBd] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'OperationBd', N'ON'
GO
ALTER DATABASE [OperationBd] SET QUERY_STORE = OFF
GO
USE [OperationBd]
GO
/****** Object:  User [sasha]    Script Date: 02.06.2022 0:31:56 ******/
CREATE USER [sasha] FOR LOGIN [sasha] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [aleksandr]    Script Date: 02.06.2022 0:31:56 ******/
CREATE USER [aleksandr] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[aleksandr]
GO
ALTER ROLE [db_owner] ADD MEMBER [sasha]
GO
ALTER ROLE [db_owner] ADD MEMBER [aleksandr]
GO
/****** Object:  Schema [aleksandr]    Script Date: 02.06.2022 0:31:56 ******/
CREATE SCHEMA [aleksandr]
GO
/****** Object:  Table [dbo].[Operations]    Script Date: 02.06.2022 0:31:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operations](
	[operationId] [int] IDENTITY(1,1) NOT NULL,
	[operationType] [nchar](10) NOT NULL,
	[operationSum] [decimal](18, 2) NOT NULL,
	[category] [nchar](50) NOT NULL,
	[comment] [nchar](100) NULL,
 CONSTRAINT [PK_Operations] PRIMARY KEY CLUSTERED 
(
	[operationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Operations] ON 

INSERT [dbo].[Operations] ([operationId], [operationType], [operationSum], [category], [comment]) VALUES (1, N'доход     ', CAST(50000.00 AS Decimal(18, 2)), N'зарплата                                          ', N'                                                                                                    ')
INSERT [dbo].[Operations] ([operationId], [operationType], [operationSum], [category], [comment]) VALUES (2, N'расход    ', CAST(300.00 AS Decimal(18, 2)), N'поездки                                           ', N'                                                                                                    ')
INSERT [dbo].[Operations] ([operationId], [operationType], [operationSum], [category], [comment]) VALUES (3, N'расход    ', CAST(30.20 AS Decimal(18, 2)), N'чай                                               ', N'                                                                                                    ')
SET IDENTITY_INSERT [dbo].[Operations] OFF
GO
USE [master]
GO
ALTER DATABASE [OperationBd] SET  READ_WRITE 
GO
