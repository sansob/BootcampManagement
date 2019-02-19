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

