USE [FactElectronica]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 11/05/2019 0:06:30 ******/
DROP TABLE [dbo].[Users]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 11/05/2019 0:06:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Identification] [varchar](10) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Phone] [int] NOT NULL,
	[Province] [varchar](20) NOT NULL,
	[Canton] [varchar](50) NOT NULL,
	[District] [varchar](50) NOT NULL,
	[Direction] [varchar](200) NOT NULL,
	[State] [char](1) NOT NULL
) ON [PRIMARY]
GO