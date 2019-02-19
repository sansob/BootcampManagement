CREATE TABLE [dbo].[Lessons] (
    [Id]         INT                IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (MAX)     NULL,
    [CreateDate] DATETIMEOFFSET (7) NOT NULL,
    [UpdateDate] DATETIMEOFFSET (7) NOT NULL,
    [DeleteDate] DATETIMEOFFSET (7) NOT NULL,
    [IsDelete]   BIT                DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_dbo.Lessons] PRIMARY KEY CLUSTERED ([Id] ASC)
);

