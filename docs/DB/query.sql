USE [master]
GO
/****** Object:  Database [DBSample]    Script Date: 28/10/2016 17:27:49 ******/
CREATE DATABASE [DBSample]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBSample', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS2012\MSSQL\DATA\DBSample.mdf' , SIZE = 1392640KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DBSample_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS2012\MSSQL\DATA\DBSample_log.ldf' , SIZE = 92864KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DBSample] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBSample].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBSample] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBSample] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBSample] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBSample] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBSample] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBSample] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBSample] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [DBSample] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBSample] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBSample] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBSample] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBSample] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBSample] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBSample] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBSample] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBSample] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DBSample] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBSample] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBSample] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBSample] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBSample] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBSample] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBSample] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBSample] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DBSample] SET  MULTI_USER 
GO
ALTER DATABASE [DBSample] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBSample] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBSample] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBSample] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [DBSample]
GO
/****** Object:  StoredProcedure [dbo].[GetPictureByID]    Script Date: 28/10/2016 17:27:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetPictureByID] 
	@id  as int
as
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	SELECT Picture from tblSample
	where ID = @id
END

GO
/****** Object:  StoredProcedure [dbo].[sp_InsertTempData]    Script Date: 28/10/2016 17:27:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertTempData] 
AS
BEGIN
	SET NOCOUNT ON;
	delete  from tblSample
	where 1>0
	declare @i integer;
	set @i=0;
	while @i <100
	begin
		set @i = @i+1;
		insert into tblSample(ID,Name,Age,Picture)
		select  @i,'A','10',(SELECT * FROM OPENROWSET(BULK N'C:\Users\JunF\Desktop\ss\1.jpg', SINGLE_BLOB)AS PictureImage)
		
	end

END
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectAll]    Script Date: 28/10/2016 17:27:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_SelectAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT ID,Name,Age FROM tblSample
END

GO
/****** Object:  StoredProcedure [dbo].[sp_SelectMProductAll]    Script Date: 28/10/2016 17:27:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_SelectMProductAll] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	select * from tblProduct
	right join tblProductDetail on tblProductDetail.DetailProductID = tblProduct.ProductID
END

GO
/****** Object:  Table [dbo].[tblProduct]    Script Date: 28/10/2016 17:27:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblProduct](
	[ProductID] [varchar](50) NOT NULL,
	[CategoryID] [varchar](50) NULL,
	[ProductName] [nvarchar](200) NULL,
	[ProductName2] [nvarchar](200) NULL,
	[Description] [nvarchar](300) NULL,
	[DetailDescription] [nvarchar](500) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedUser] [varchar](50) NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [varchar](50) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_tblProduct] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblProductDetail]    Script Date: 28/10/2016 17:27:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblProductDetail](
	[DetailProductID] [varchar](50) NOT NULL,
	[ArrivalDate] [datetime] NOT NULL,
	[Quantity] [int] NULL,
	[Price] [float] NULL,
	[SellingPrice] [float] NULL,
	[ArrivalUser] [varchar](50) NULL,
 CONSTRAINT [PK_tblProductDetail] PRIMARY KEY CLUSTERED 
(
	[DetailProductID] ASC,
	[ArrivalDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblSample]    Script Date: 28/10/2016 17:27:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblSample](
	[ID] [int] NOT NULL,
	[Name] [varchar](50) NULL,
	[Age] [varchar](50) NULL,
	[Picture] [varbinary](max) NULL,
 CONSTRAINT [PK_tblSample] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [DBSample] SET  READ_WRITE 
GO
