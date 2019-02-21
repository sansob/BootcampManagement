USE [BootcampManagement]
GO

/****** Object: Table [dbo].[Batch] Script Date: 19/02/2019 10:22:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[province]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Province] (
			[Id]         INT                IDENTITY (1, 1) NOT NULL,
			[Name]       VARCHAR (100)      NOT NULL,
			[CreateDate] DATETIMEOFFSET (7) NOT NULL,
			[UpdateDate] DATETIMEOFFSET (7) NOT NULL,
			[DeleteDate] DATETIMEOFFSET (7) NOT NULL,
			[IsDelete]   BIT                DEFAULT ((0)) NOT NULL,
			PRIMARY KEY CLUSTERED ([Id] ASC)
	);
	END

IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[regency]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Regency] (
			[Id]          INT                IDENTITY (1, 1) NOT NULL,
			[Name]        VARCHAR (100)      NOT NULL,
			[CreateDate]  DATETIMEOFFSET (7) NOT NULL,
			[UpdateDate]  DATETIMEOFFSET (7) NOT NULL,
			[DeleteDate]  DATETIMEOFFSET (7) NOT NULL,
			[IsDelete]    BIT                DEFAULT ((0)) NOT NULL,
			[Province_Id] INT                NOT NULL,
			PRIMARY KEY CLUSTERED ([Id] ASC),
			CONSTRAINT [FK_Regency_Province] FOREIGN KEY ([Province_Id]) REFERENCES [dbo].[Province] ([Id])
		);
	END

IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[district]') and OBJECTPROPERTY(id, N'IsTable') = 1)	
	BEGIN
		CREATE TABLE [dbo].[District] (
		[Id]         INT                IDENTITY (1, 1) NOT NULL,
		[Name]       VARCHAR (100)      NOT NULL,
		[CreateDate] DATETIMEOFFSET (7) NOT NULL,
		[UpdateDate] DATETIMEOFFSET (7) NOT NULL,
		[DeleteDate] DATETIMEOFFSET (7) NOT NULL,
		[IsDelete]   BIT                DEFAULT ((0)) NOT NULL,
		[Regency_Id] INT                NOT NULL,
		PRIMARY KEY CLUSTERED ([Id] ASC),
		CONSTRAINT [FK_District_Regency] FOREIGN KEY ([Regency_Id]) REFERENCES [dbo].[Regency] ([Id])
	);
	END

IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[village]') and OBJECTPROPERTY(id, N'IsTable') = 1)	
	BEGIN
		CREATE TABLE [dbo].[Village] (
	    [Id]         INT                IDENTITY (1, 1) NOT NULL,
		[Name]        VARCHAR (100)      NOT NULL,
		[CreateDate]  DATETIMEOFFSET (7) NOT NULL,
		[UpdateDate]  DATETIMEOFFSET (7) NOT NULL,
	    [DeleteDate]  DATETIMEOFFSET (7) NOT NULL,
		[IsDelete]    BIT                DEFAULT ((0)) NOT NULL,
		[District_Id] INT                NOT NULL,
		PRIMARY KEY CLUSTERED ([Id] ASC),
		CONSTRAINT [FK_Village_District] FOREIGN KEY ([District_Id]) REFERENCES [dbo].[District] ([Id])
	);
	END

IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[category]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Category] (
		[Id]         INT                IDENTITY (1, 1) NOT NULL,
		[Name]       VARCHAR (100)      NOT NULL,
		[CreateDate] DATETIMEOFFSET (7) NOT NULL,
		[UpdateDate] DATETIMEOFFSET (7) NOT NULL,
		[DeleteDate] DATETIMEOFFSET (7) NOT NULL,
		[IsDelete]   BIT                NOT NULL, 
		CONSTRAINT [PK_Category] PRIMARY KEY ([Id])
	);
	END

IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[class]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Class] (
		[Id]         INT                IDENTITY (1, 1) NOT NULL,
		[Name]       VARCHAR (50)       NOT NULL,
		[CreateDate] DATETIMEOFFSET (7) NOT NULL,
		[UpdateDate] DATETIMEOFFSET (7) NOT NULL,
		[DeleteDate] DATETIMEOFFSET (7) NOT NULL,
		[IsDelete]   BIT                NOT NULL
		)
	END

IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[lesson]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Lesson] (
			[Id]         INT                IDENTITY (1, 1) NOT NULL,
			[Name]       NVARCHAR (MAX)     NULL,
			[CreateDate] DATETIMEOFFSET (7) NOT NULL,
			[UpdateDate] DATETIMEOFFSET (7) NOT NULL,
			[DeleteDate] DATETIMEOFFSET (7) NOT NULL,
			[IsDelete]   BIT                DEFAULT ((0)) NOT NULL,
			CONSTRAINT [PK_dbo.Lessons] PRIMARY KEY CLUSTERED ([Id] ASC)
	);
	END

IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[religion]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Religion] (
			[Id]         INT                IDENTITY (1, 1) NOT NULL,
			[Name]       VARCHAR (50)       NOT NULL,
			[CreateDate] DATETIMEOFFSET (7) NOT NULL,
			[UpdateDate] DATETIMEOFFSET (7) NOT NULL,
			[DeleteDate] DATETIMEOFFSET (7) NOT NULL,
			[IsDelete]   BIT                DEFAULT ((0)) NOT NULL,
			PRIMARY KEY CLUSTERED ([Id] ASC)
		);
	END