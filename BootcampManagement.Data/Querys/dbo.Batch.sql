USE [BootcampManagement]
GO

/****** Object: Table [dbo].[Batch] Script Date: 19/02/2019 10:22:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Batch] (
    [Id]         INT                IDENTITY (1, 1) NOT NULL,
    [StartDate]  DATETIMEOFFSET (7) NOT NULL,
    [EndDate]    DATETIMEOFFSET (7) NOT NULL,
    [CreateDate] DATETIMEOFFSET (7) NOT NULL,
    [UpdateDate] DATETIMEOFFSET (7) NOT NULL,
    [DeleteDate] DATETIMEOFFSET (7) NOT NULL,
    [IsDelete]   BIT                NOT NULL
);


