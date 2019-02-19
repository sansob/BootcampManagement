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

