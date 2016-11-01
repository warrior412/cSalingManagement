USE [master]
GO
/****** Object:  Database [cSalingManagement]    Script Date: 01/11/2016 17:24:19 ******/
CREATE DATABASE [cSalingManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'cSalingManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS2012\MSSQL\DATA\cSalingManagement.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'cSalingManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS2012\MSSQL\DATA\cSalingManagement_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [cSalingManagement] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [cSalingManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [cSalingManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [cSalingManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [cSalingManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [cSalingManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [cSalingManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [cSalingManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [cSalingManagement] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [cSalingManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [cSalingManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [cSalingManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [cSalingManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [cSalingManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [cSalingManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [cSalingManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [cSalingManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [cSalingManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [cSalingManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [cSalingManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [cSalingManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [cSalingManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [cSalingManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [cSalingManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [cSalingManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [cSalingManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [cSalingManagement] SET  MULTI_USER 
GO
ALTER DATABASE [cSalingManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [cSalingManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [cSalingManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [cSalingManagement] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [cSalingManagement]
GO
/****** Object:  Table [dbo].[M_Account]    Script Date: 01/11/2016 17:24:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[M_Account](
	[Username] [varchar](10) NOT NULL,
	[Password] [char](128) NULL,
	[EmployeeID] [varchar](10) NULL,
	[RoleID] [varchar](10) NULL,
	[AccountStatus] [int] NULL,
 CONSTRAINT [PK_M_Account] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[M_Category]    Script Date: 01/11/2016 17:24:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[M_Category](
	[CategoryID] [varchar](10) NOT NULL,
	[CategoryName] [varchar](50) NULL,
	[Cate_Description] [varbinary](100) NULL,
	[Cate_Image] [varbinary](max) NULL,
	[Cate_Status] [int] NULL,
 CONSTRAINT [PK_M_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[M_Department]    Script Date: 01/11/2016 17:24:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[M_Department](
	[DepartmentID] [varchar](10) NOT NULL,
	[DepartmentName] [varchar](50) NULL,
 CONSTRAINT [PK_M_Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[M_Employee]    Script Date: 01/11/2016 17:24:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[M_Employee](
	[EmployeeID] [varchar](10) NOT NULL,
	[DepartmentID] [varchar](10) NULL,
	[EmployeeName] [varchar](50) NULL,
	[Employee_IDCard] [varchar](20) NULL,
	[Emp_Address] [varchar](100) NULL,
	[Emp_DateOfBirth] [date] NULL,
	[Emp_Phone] [varchar](15) NULL,
	[Emp_SubPhone] [varchar](15) NULL,
	[Salary] [float] NULL,
	[Employee_Status] [int] NULL,
 CONSTRAINT [PK_M_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[M_ProductInfo]    Script Date: 01/11/2016 17:24:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[M_ProductInfo](
	[ProductID] [varchar](10) NOT NULL,
	[ProductName] [varchar](50) NULL,
	[Category] [varchar](10) NULL,
	[Supplier] [varchar](10) NULL,
	[Pro_InStock] [int] NULL,
	[Pro_Price] [float] NULL,
	[Pro_Desciptions] [varchar](200) NULL,
	[Pro_Preservation] [varchar](200) NULL,
	[Pro_HowToUse] [varchar](200) NULL,
	[Pro_Status] [int] NULL,
 CONSTRAINT [PK_M_ProductInfo_1] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[M_Role]    Script Date: 01/11/2016 17:24:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[M_Role](
	[RoleID] [varchar](10) NOT NULL,
	[RoleName] [varchar](50) NULL,
 CONSTRAINT [PK_M_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[M_Supplier]    Script Date: 01/11/2016 17:24:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[M_Supplier](
	[SupplierID] [varchar](10) NOT NULL,
	[SupplierName] [varchar](50) NULL,
	[Supp_Address] [varchar](200) NULL,
	[Supp_Phone] [varchar](20) NULL,
	[Supp_Sub_Phone] [varchar](20) NULL,
	[Supp_Email] [varchar](20) NULL,
	[Supp_Website] [varchar](50) NULL,
	[Supp_Image] [varbinary](max) NULL,
	[Supplier_Status] [int] NULL,
 CONSTRAINT [PK_M_Supplier] PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_Import]    Script Date: 01/11/2016 17:24:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_Import](
	[ProductID] [varchar](10) NOT NULL,
	[ImportDate] [datetime] NOT NULL,
	[Supplier] [varchar](10) NULL,
	[Quantity] [int] NULL,
	[Import_InStock] [int] NULL,
	[Import_OnOrder] [int] NULL,
	[UnitPrice] [float] NULL,
	[ExpirionDate] [date] NULL,
	[Import_User] [varchar](10) NULL,
	[Import_Status] [int] NULL,
 CONSTRAINT [PK_T_Import] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC,
	[ImportDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [cSalingManagement] SET  READ_WRITE 
GO
