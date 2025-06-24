USE [RaceResultsDb]
GO

/****** Object:  Table [dbo].[RaceResults]    Script Date: 23/06/2025 08:37:57 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RaceResults]') AND type in (N'U'))
DROP TABLE [dbo].[RaceResults]
GO

/****** Object:  Table [dbo].[RaceResults]    Script Date: 23/06/2025 08:37:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RaceResults](
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[Race] [nvarchar](max) NOT NULL,
	[RaceDate] [datetime2] NOT NULL,
	[RaceTime] [nvarchar](10) NOT NULL,
	[Racecourse] [nvarchar](50) NOT NULL,
	[RaceDistance] [float] NOT NULL,
	[Jockey] [nvarchar](50) NOT NULL,
	[Trainer] [nvarchar](50) NOT NULL,
	[Horse] [nvarchar](50) NOT NULL,
	[FinishingPosition] [int] NOT NULL,
	[DistanceBeaten] [decimal](18, 2) NOT NULL,
	[TimeBeaten] [decimal](18, 2) NOT NULL,
	[Notes] [nvarchar](max) NULL)
GO


