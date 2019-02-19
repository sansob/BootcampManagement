USE [BootcampManagement]
GO

/****** Object: Table [dbo].[Department] Script Date: 19/02/2019 10:23:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Department] (
    [Id]         INT                IDENTITY (1, 1) NOT NULL,
    [Name]       VARCHAR (50)       NOT NULL,
    [CreateDate] DATETIMEOFFSET (7) NOT NULL,
    [UpdateDate] DATETIMEOFFSET (7) NOT NULL,
    [DeleteDate] DATETIMEOFFSET (7) NOT NULL,
    [IsDelete]   BIT                NOT NULL
);


