USE [BootcampManagement]
GO

/****** Object: Table [dbo].[Batch] Script Date: 19/02/2019 10:22:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
/**/


/* 1. Province */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[province]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Province] (
			[Id]         INT                IDENTITY (1, 1) NOT NULL,
			[Name]       VARCHAR (100)      NOT NULL,
			[CreateDate] DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate] DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate] DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]   BIT                DEFAULT ((0)) NOT NULL,
			CONSTRAINT [PK_Province] PRIMARY KEY ([Id])
                );
	END
/* 2. Regency */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[regency]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Regency] (
			[Id]          INT                IDENTITY (1, 1) NOT NULL,
			[Name]        VARCHAR (100)      NOT NULL,
			[CreateDate] DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate] DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate] DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]   BIT                DEFAULT ((0)) NOT NULL,
			[Province_Id] INT                NOT NULL,
			CONSTRAINT [PK_Regency] PRIMARY KEY ([Id]),
			CONSTRAINT [FK_Regency_Province] FOREIGN KEY ([Province_Id]) REFERENCES [dbo].[Province] ([Id])
		);
	END
/* 3. District */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[district]') and OBJECTPROPERTY(id, N'IsTable') = 1)	
	BEGIN
		CREATE TABLE [dbo].[District] (
                	[Id]            INT                IDENTITY (1, 1) NOT NULL,
                	[Name]          VARCHAR (100)      NOT NULL,
                	[CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL,
                        [Regency_Id]    INT                NOT NULL,
                        CONSTRAINT [PK_District] PRIMARY KEY ([Id]),
                        CONSTRAINT [FK_District_Regency] FOREIGN KEY ([Regency_Id]) REFERENCES [dbo].[Regency] ([Id])
                );
	END
/* 4. Village */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[village]') and OBJECTPROPERTY(id, N'IsTable') = 1)	
	BEGIN
		CREATE TABLE [dbo].[Village] (
                        [Id]            INT                IDENTITY (1, 1) NOT NULL,
                        [Name]          VARCHAR (100)      NOT NULL,
                        [CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL,
                        [District_Id]   INT                NOT NULL,
        		CONSTRAINT [PK_Village] PRIMARY KEY ([Id]),
                	CONSTRAINT [FK_Village_District] FOREIGN KEY ([District_Id]) REFERENCES [dbo].[District] ([Id])
                );
	END
/* 5. Company */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[company]') and OBJECTPROPERTY(id, N'IsTable') = 1)	
	BEGIN
		CREATE TABLE [dbo].[Company] (
                        [Id]            INT                IDENTITY (1, 1) NOT NULL,
                        [Name]          VARCHAR (100)      NOT NULL,
                        [Address]       VARCHAR (255)      NOT NULL,
                        [CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL,
                        [Village_Id]    INT                NOT NULL,
                        CONSTRAINT [PK_Company] PRIMARY KEY ([Id]),
                        CONSTRAINT [FK_Company_Village] FOREIGN KEY ([Village_Id]) REFERENCES [dbo].[Village] ([Id])
                );
	END
/* 6. Religion */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[religion]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Religion] (
			[Id]            INT                IDENTITY (1, 1) NOT NULL,
			[Name]          VARCHAR (50)       NOT NULL,
			[CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL,
                        CONSTRAINT [PK_Religion] PRIMARY KEY ([Id])
		);
	END
/* 7. Employee */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[employee]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Employee] (
			[Id]             Varchar (8)        NOT NULL,
			[FirstName]      VARCHAR (100)      NOT NULL,
			[LastName]       VARCHAR (100)      NOT NULL,
			[DateOfBirth]    DATE               NULL,
			[PlaceOfBirth]   INT                NULL,
			[Gender]         BIT                NULL,
			[Address]        VARCHAR (100)      NULL,
			[Phone]          VARCHAR (20)       NULL UNIQUE,
			[Email]          VARCHAR (50)       NOT NULL UNIQUE,
			[Username]       VARCHAR (25)       NOT NULL UNIQUE,
			[Password]       VARCHAR (50)       NOT NULL,
			[IsSite]         BIT                DEFAULT ((0)) NOT NULL,
			[SecretQuestion] VARCHAR (100)      NULL,
			[SecretAnswer]   VARCHAR (100)      NULL,
			[CreateDate]     DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]     DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]     DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]       BIT                DEFAULT ((0)) NOT NULL,
			[HiringLocation] INT                ,
			[Religion_Id]    INT                ,
			[Village_Id]     INT                ,
			CONSTRAINT [PK_Employee] PRIMARY KEY ([Id]),
			CONSTRAINT [FK_Employee_Religion] FOREIGN KEY ([Religion_Id]) REFERENCES [dbo].[Religion] ([Id]),
			CONSTRAINT [FK_Employee_Village] FOREIGN KEY ([Village_Id]) REFERENCES [dbo].[Village] ([Id]),
			CONSTRAINT [FK_Employee_Hiring_Location] FOREIGN KEY ([PlaceOfBirth]) REFERENCES [dbo].[Regency] ([Id]),
			CONSTRAINT [FK_Employee_PlaceOfBirth] FOREIGN KEY ([HiringLocation]) REFERENCES [dbo].[Regency] ([Id])
		);
	END
/* 8. Placement */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[placement]') and OBJECTPROPERTY(id, N'IsTable') = 1)	
	BEGIN
		CREATE TABLE [dbo].[Placement] (
                        [Id]            INT                IDENTITY (1, 1) NOT NULL,
                        [Description]   VARCHAR (100)      NOT NULL,
                        [Department]    VARCHAR (100)      NOT NULL,
                        [StartDate]     DATE               NOT NULL,
                        [FinishDate]    DATE               NOT NULL,
                        [CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL,
                        [Employee_Id]   Varchar (8)        NOT NULL,
                        [Company_Id]    INT                NOT NULL,
                        CONSTRAINT [PK_Placement] PRIMARY KEY ([Id]),
                        CONSTRAINT [FK_Placement_Company] FOREIGN KEY ([Company_Id]) REFERENCES [dbo].[Company] ([Id]),
                        CONSTRAINT [FK_Placement_Employee] FOREIGN KEY ([Employee_Id]) REFERENCES [dbo].[Employee] ([Id])
                );
	END
/* 9. Category */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[category]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Category] (
                        [Id]            INT                IDENTITY (1, 1) NOT NULL,
                	[Name]          VARCHAR (100)      NOT NULL,
                	[CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL,
                	CONSTRAINT [PK_Category] PRIMARY KEY ([Id])
                );
	END
/* 10. Skill */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[skill]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Skill] (
                        [Id]            INT                IDENTITY (1, 1) NOT NULL,
                	[Name]          VARCHAR (100)      NOT NULL,
                	[CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL,
                        [Category_Id]   INT                NOT NULL,
                        CONSTRAINT [PK_Skill] PRIMARY KEY ([Id]),
                        CONSTRAINT [FK_Skill_Category] FOREIGN KEY ([Category_Id]) REFERENCES [dbo].[Category] ([Id])
                );
	END
/* 11. Employee_Skill */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[employee_skill]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Employee_Skill] (
                        [Id]            INT                IDENTITY (1, 1) NOT NULL,
                	[CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL, 
                        [Employee_Id]   Varchar (8)        NOT NULL,
                        [Skill_Id]      INT                NOT NULL,
                        CONSTRAINT [PK_Employee_Skill] PRIMARY KEY ([Id]),
                        CONSTRAINT [FK_Employee_Skill_Employee] FOREIGN KEY ([Employee_Id]) REFERENCES [dbo].[Employee] ([Id]),
                        CONSTRAINT [FK_Employee_Skill_Skill] FOREIGN KEY ([Skill_Id]) REFERENCES [dbo].[Skill] ([Id])
                );
	END
/* 12. Language */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[language]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Language] (
                        [Id]            VARCHAR (2)        NOT NULL,
                	[Name]          VARCHAR (100)      NOT NULL,
                	[CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL, 
                	CONSTRAINT [PK_Language] PRIMARY KEY ([Id])
                );
	END
/* 13. Employee_Language */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[employee_language]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Employee_Language] (
                        [Id]            INT                IDENTITY (1, 1) NOT NULL,
                	[Name]          VARCHAR (100)      NOT NULL,
                	[CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL,  
                        [Employee_Id]   VARCHAR (8)        NOT NULL,
                        [Language_Id]   VARCHAR (2)        NOT NULL,
                        CONSTRAINT [PK_Employee_Language] PRIMARY KEY ([Id]),
                        CONSTRAINT [FK_Employee_Language_Employee] FOREIGN KEY ([Employee_Id]) REFERENCES [dbo].[Employee] ([Id]),
                        CONSTRAINT [FK_Employee_Language_Language] FOREIGN KEY ([Language_Id]) REFERENCES [dbo].[Language] ([Id])
                );
	END
/* 14. Work Experience */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[work_experience]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Work_Experience] (
                        [Id]            INT                IDENTITY (1, 1) NOT NULL,
                	[Name]          VARCHAR (100)      NOT NULL,
                	[Description]   VARCHAR (255)      NOT NULL,
                	[StartDate]     DATETIMEOFFSET (7) NOT NULL,
                	[EndDate]       DATETIMEOFFSET (7) NOT NULL,
                	[CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL, 
                        [Employee_Id]   VARCHAR (8)        NOT NULL,
                        CONSTRAINT [PK_Work_Experience] PRIMARY KEY ([Id]),
                        CONSTRAINT [FK_Work_Experience_Employee] FOREIGN KEY ([Employee_Id]) REFERENCES [dbo].[Employee] ([Id])
                );
	END
/* 15. Role */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[role]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Role] (
                        [Id]            INT                IDENTITY (1, 1) NOT NULL,
                	[Name]          VARCHAR (100)      NOT NULL,
                	[CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL,  
                	CONSTRAINT [PK_Role] PRIMARY KEY ([Id])
                );
	END
/* 16. Employee_Role */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[employee_role]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Employee_Role] (
                        [Id]            INT                IDENTITY (1, 1) NOT NULL,
                	[StartDate]     DATE               NOT NULL,
                	[EndDate]       DATE               NOT NULL,
                	[CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL,  
                        [Employee_Id]   Varchar (8)        NOT NULL,
                        [Role_Id]       INT                NOT NULL,
                        CONSTRAINT [PK_Employee_Role] PRIMARY KEY ([Id]),
                        CONSTRAINT [FK_Employee_Role_Employee] FOREIGN KEY ([Employee_Id]) REFERENCES [dbo].[Employee] ([Id]),
                        CONSTRAINT [FK_Employee_Role_Role] FOREIGN KEY ([Role_Id]) REFERENCES [dbo].[Role] ([Id])
                );
	END
/* 17. Certification */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[certification]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Certification] (
                        [Id]            INT                IDENTITY (1, 1) NOT NULL,
                	[Name]          VARCHAR (100)      NOT NULL,
                	[CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL,  
                	CONSTRAINT [PK_Certification] PRIMARY KEY ([Id])
                );
	END
/* 18. Employee_Certification */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[employee_certification]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Employee_Certification] (
                        [Id]            INT                IDENTITY (1, 1) NOT NULL,
                	[CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL,  
                        [Employee_Id]   VARCHAR (8)        NOT NULL,
                        [Certification_Id]   INT           NOT NULL,
                        CONSTRAINT [PK_Employee_Certification] PRIMARY KEY ([Id]),
                        CONSTRAINT [FK_Employee_Certification_Employee] FOREIGN KEY ([Employee_Id]) REFERENCES [dbo].[Employee] ([Id]),
                        CONSTRAINT [FK_Employee_Certification_Certification] FOREIGN KEY ([Certification_Id]) REFERENCES [dbo].[Certification] ([Id])
                );
	END
/* 19. Achievement */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[achievement]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Achievement] (
                        [Id]            INT                IDENTITY (1, 1) NOT NULL,
                	[Description]   VARCHAR (100)      NOT NULL,
                	[CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL,  
                        [Employee_Id]   Varchar (8)        NOT NULL,
                        CONSTRAINT [PK_Achievement] PRIMARY KEY ([Id]),
                        CONSTRAINT [FK_Achievement_Employee] FOREIGN KEY ([Employee_Id]) REFERENCES [dbo].[Employee] ([Id])
                );
	END
/* 20. Organization */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[organization]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Organization] (
                        [Id]            INT                IDENTITY (1, 1) NOT NULL,
                	[Description]   VARCHAR (100)      NOT NULL,
                	[CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL,  
                        [Employee_Id]   Varchar (8)        NOT NULL,
                        CONSTRAINT [PK_Organization] PRIMARY KEY ([Id]),
                        CONSTRAINT [FK_Organization_Employee] FOREIGN KEY ([Employee_Id]) REFERENCES [dbo].[Employee] ([Id])
                );
	END
/* 21. University */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[university]') and OBJECTPROPERTY(id, N'IsTable') = 1)	
	BEGIN
		CREATE TABLE [dbo].[University] (
                        [Id]            VARCHAR (25)       NOT NULL,
                        [Name]          VARCHAR (100)      NOT NULL,
                        [Address]       VARCHAR (255),
                        [CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL, 
                        [Village_Id]    INT                DEFAULT (NULL),
                        CONSTRAINT [PK_University] PRIMARY KEY ([Id]),
                        CONSTRAINT [FK_University_Village] FOREIGN KEY ([Village_Id]) REFERENCES [dbo].[Village] ([Id])
                );
	END
/* 22. Major */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[major]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Major] (
                        [Id]            VARCHAR (3)        NOT NULL,
                	[Name]          VARCHAR (100)      NOT NULL,
                	[CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL,  
                	CONSTRAINT [PK_Major] PRIMARY KEY ([Id])
                );
	END
/* 23. Degree */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[degree]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Degree] (
                        [Id]            VARCHAR (2)        NOT NULL,
                	[Name]          VARCHAR (100)      NOT NULL,
                	[CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL,  
                	CONSTRAINT [PK_Degree] PRIMARY KEY ([Id])
                );
	END
/* 24. Education */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[education]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Education] (
                        [Id]            VARCHAR(50)        NOT NULL,
                	[CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL,  
                        [Degree_Id]     VARCHAR (2)        NOT NULL,
                        [Major_Id]      VARCHAR (3)        NOT NULL,
                        [University_Id] VARCHAR (25)       NOT NULL,
                        CONSTRAINT [PK_Education] PRIMARY KEY ([Id]),
                        CONSTRAINT [FK_Education_Degree] FOREIGN KEY ([Degree_Id]) REFERENCES [dbo].[Degree] ([Id]),
                        CONSTRAINT [FK_Education_Major] FOREIGN KEY ([Major_Id]) REFERENCES [dbo].[Major] ([Id]),
                        CONSTRAINT [FK_Education_University] FOREIGN KEY ([University_Id]) REFERENCES [dbo].[University] ([Id])
                );
	END
/* 25. Education_History */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[education_history]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Education_History] (
                        [Id]            INT                IDENTITY (1, 1) NOT NULL,
                	[CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL,  
                        [Education_Id]  VARCHAR (50)       NOT NULL,
                        [Employee_Id]   Varchar (8)        NOT NULL,
                        CONSTRAINT [PK_Education_History] PRIMARY KEY ([Id]),
                        CONSTRAINT [FK_Education_History_Education] FOREIGN KEY ([Education_Id]) REFERENCES [dbo].[Education] ([Id]),
                        CONSTRAINT [FK_Education_History_Employee] FOREIGN KEY ([Employee_Id]) REFERENCES [dbo].[Employee] ([Id]),
                );
	END
/* 26. ID_Card */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[id_card]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Id_Card] (
                        [Id]            INT                IDENTITY (1, 1) NOT NULL,
                	[ReceiveDate]   DATE               NOT NULL,
                	[CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL,  
                        [Employee_Id]   Varchar (8)        NOT NULL,
                        CONSTRAINT [PK_Id_Card] PRIMARY KEY ([Id]),
                        CONSTRAINT [FK_Id_Card_Employee] FOREIGN KEY ([Employee_Id]) REFERENCES [dbo].[Employee] ([Id])
                );
	END
/* 27. Access_Card */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[access_card]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Access_Card] (
                        [Id]            VARCHAR (11)       NOT NULL,
                	[AccessNumber]  VARCHAR (100)      NOT NULL,
                	[CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL,  
                	CONSTRAINT [PK_Access_Card] PRIMARY KEY ([Id])
                );
	END
/* 28. Employee_Access */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[employee_access]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Employee_Access] (
                        [Id]            INT                IDENTITY (1, 1) NOT NULL,
                	[ReceiveDate]   DATE               NOT NULL,
                	[ReturnDate]    DATE               NOT NULL,
                	[CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL,  
                        [Employee_Id]   Varchar (8)        NOT NULL,
                        [Access_Id]     VARCHAR (11)       NOT NULL,
                        CONSTRAINT [PK_Employee_Access] PRIMARY KEY ([Id]),
                        CONSTRAINT [FK_Employee_Access_Employee] FOREIGN KEY ([Employee_Id]) REFERENCES [dbo].[Employee] ([Id]),
                        CONSTRAINT [FK_Employee_Access_Access] FOREIGN KEY ([Access_Id]) REFERENCES [dbo].[Access_Card] ([Id])
                );
	END
/* 29. Locker */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[locker]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Locker] (
                        [Id]            VARCHAR (2)        NOT NULL,
                	[LockerNumber]  VARCHAR (100)      NOT NULL,
                	[CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL,  
                	CONSTRAINT [PK_Locker] PRIMARY KEY ([Id])
                );
	END
/* 30. Employee_Locker */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[employee_locker]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Employee_Locker] (
                        [Id]            INT                IDENTITY (1, 1) NOT NULL,
                	[ReceiveDate]   DATE               NOT NULL,
                	[ReturnDate]    DATE               NOT NULL,
                	[CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL,  
                        [Employee_Id]   Varchar (8)        NOT NULL,
                        [Locker_Id]     VARCHAR (2)        NOT NULL,
                        CONSTRAINT [PK_Employee_Locker] PRIMARY KEY ([Id]),
                        CONSTRAINT [FK_Employee_Locker_Employee] FOREIGN KEY ([Employee_Id]) REFERENCES [dbo].[Employee] ([Id]),
                        CONSTRAINT [FK_Employee_Locker_Locker] FOREIGN KEY ([Locker_Id]) REFERENCES [dbo].[Locker] ([Id])
                );
	END
/* 31. Class */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[class]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Class] (
                        [Id]            Varchar (5)        NOT NULL,
                        [Name]          VARCHAR (50)       NOT NULL,
                        [CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL, 
                        CONSTRAINT [PK_Class] PRIMARY KEY ([Id])
		)
	END
/* 32. Batch */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[batch]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Batch] (
                        [Id]            VARCHAR (2)        NOT NULL,
                        [StartDate]     DATE               NOT NULL,
                        [EndDate]       DATE               NOT NULL,
                        [CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL, 
                        CONSTRAINT [PK_Batch] PRIMARY KEY ([Id])
		);
	END
/* 33. Room */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[room]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Room] (
                        [Id]            VARCHAR (5)        NOT NULL,
                        [Name]          VARCHAR (50)       NOT NULL,
                        [CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL, 
                        CONSTRAINT [PK_Room] PRIMARY KEY ([Id])
		)
	END
/* 34. Batch_Class */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[batch_class]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Batch_Class] (
                        [Id]            VARCHAR (10)       NOT NULL,
                	[CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL,  
                        [Trainer_Id]    VARCHAR (8)        NOT NULL,
                        [Batch_Id]      VARCHAR (2)        NOT NULL,
                        [Class_Id]      VARCHAR (5)        NOT NULL,
                        [Room_Id]       VARCHAR (5)        NOT NULL,
                        CONSTRAINT [PK_Batch_Class] PRIMARY KEY ([Id]),
                        CONSTRAINT [FK_Batch_Class_Employee] FOREIGN KEY ([Trainer_Id]) REFERENCES [dbo].[Employee] ([Id]),
                        CONSTRAINT [FK_Batch_Class_Batch] FOREIGN KEY ([Batch_Id]) REFERENCES [dbo].[Batch] ([Id]),
                        CONSTRAINT [FK_Batch_Class_Class] FOREIGN KEY ([Class_Id]) REFERENCES [dbo].[Class] ([Id]),
                        CONSTRAINT [FK_Batch_Class_Room] FOREIGN KEY ([Room_Id]) REFERENCES [dbo].[Room] ([Id])
                );
	END
/* 35. Error_Bank */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[Error_Bank]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Error_Bank] (
                        [Id]            INT                IDENTITY (1, 1) NOT NULL,
                	[SubmitDate]    DATE               NOT NULL,
                	[Description]   VARCHAR(255)       NOT NULL,
                	[Solution]      VARCHAR(255)       NOT NULL,
                	[CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL,  
                        [Employee_Id]   Varchar (8)        NOT NULL,
                        [Class_Id]      VARCHAR (5)        NOT NULL,
                        CONSTRAINT [PK_Error_Bank] PRIMARY KEY ([Id]),
                        CONSTRAINT [FK_Error_Bank_Employee] FOREIGN KEY ([Employee_Id]) REFERENCES [dbo].[Employee] ([Id]),
                        CONSTRAINT [FK_Error_Bank_Class] FOREIGN KEY ([Class_Id]) REFERENCES [dbo].[Class] ([Id]),
                );
	END
/* 36. Member */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[member]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Member] (
                        [Id]            Varchar(8)         NOT NULL,
                	[CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL,  
                        [Trainer_Id]    Varchar (8)        NOT NULL,
                        [Batch_Class_Id]   VARCHAR (10)     NOT NULL,
                        CONSTRAINT [PK_Member] PRIMARY KEY ([Id]),
                        CONSTRAINT [FK_Member_Trainer] FOREIGN KEY ([Trainer_Id]) REFERENCES [dbo].[Employee] ([Id]),
                        CONSTRAINT [FK_Member_Employee] FOREIGN KEY ([Id]) REFERENCES [dbo].[Employee] ([Id]),
                        CONSTRAINT [FK_Member_Batch_Class] FOREIGN KEY ([Batch_Class_Id]) REFERENCES [dbo].[Batch_Class] ([Id])
                );
	END
/* 37. Aspect */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[aspect]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Aspect] (
                        [Id]            INT                IDENTITY (1, 1) NOT NULL,
                	[Name]          VARCHAR (100)      NOT NULL,
                	[CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL,  
                	CONSTRAINT [PK_Aspect] PRIMARY KEY ([Id])
                );
	END
/* 38. Topic */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[topic]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Topic] (
                        [Id]            INT                IDENTITY (1, 1) NOT NULL,
                	[Name]          VARCHAR (100)      NOT NULL,
                	[CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL,  
                	CONSTRAINT [PK_Topic] PRIMARY KEY ([Id])
                );
	END
/* 39. Lesson */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[lesson]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Lesson] (
                        [Id]            INT                IDENTITY (1, 1) NOT NULL,
                        [Name]          VARCHAR (MAX)      NULL,
                        [CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL, 
                        [Class_Id]      VARCHAR (5)        NOT NULL,
                        CONSTRAINT [PK_Lesson] PRIMARY KEY ([Id]),
                        CONSTRAINT [FK_Lesson_Class] FOREIGN KEY ([Class_Id]) REFERENCES [dbo].[Class] ([Id]),
                );
	END
/* 40. Evaluation */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[evaluation]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Evaluation] (
                        [Id]            INT                IDENTITY (1, 1) NOT NULL,
                	[CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL, 
                        [Member_Id]     VARCHAR (8)        NOT NULL,
                        [Lesson_Id]     INT                NOT NULL,
                        [Topic_Id]      INT,
                        CONSTRAINT [PK_Evaluation] PRIMARY KEY ([Id]),
                        CONSTRAINT [FK_Evaluation_Member] FOREIGN KEY ([Member_Id]) REFERENCES [dbo].[Employee] ([Id]),
                        CONSTRAINT [FK_Evaluation_Lesson] FOREIGN KEY ([Lesson_Id]) REFERENCES [dbo].[Lesson] ([Id]),
                        CONSTRAINT [FK_Evaluation_Topic] FOREIGN KEY ([Topic_Id]) REFERENCES [dbo].[Topic] ([Id])
                );
	END
/* 41. Score */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[score]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Score] (
                        [Id]            INT                IDENTITY (1, 1) NOT NULL,
                	[CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL, 
                        [Evaluation_Id] INT             NOT NULL,
                        [Aspect_Id]     INT               NOT NULL,
                        CONSTRAINT [PK_Score] PRIMARY KEY ([Id]),
                        CONSTRAINT [FK_Score_Evaluation] FOREIGN KEY ([Evaluation_Id]) REFERENCES [dbo].[Evaluation] ([Id]),
                        CONSTRAINT [FK_Score_Aspect] FOREIGN KEY ([Aspect_Id]) REFERENCES [dbo].[Aspect] ([Id])
                );
	END
/* 42. Parameter */
IF NOT EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[parameter]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[Parameter] (
                        [Id]            INT                IDENTITY (1, 1) NOT NULL,
                	[Value]         VARCHAR (100)      NOT NULL,
                	[Note]          VARCHAR (100)      NOT NULL,
                	[CreateDate]    DATETIMEOFFSET (7) DEFAULT ((SYSDATETIMEOFFSET())) NOT NULL,
                        [UpdateDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [DeleteDate]    DATETIMEOFFSET (7) DEFAULT (NULL),
                        [IsDelete]      BIT                DEFAULT ((0)) NOT NULL,  
                	CONSTRAINT [PK_Parameter] PRIMARY KEY ([Id])
                );
	END

/* Dummy Time */
INSERT INTO Degree(Id,Name)
VALUES
('S1','Sarjana'),
('S2','Magister'),
('S3','Doktor')
/* Major */
INSERT INTO Major(Id,Name)
VALUES
('TI','Teknik Informatika'),
('SI','Sistem Informasi')
/* University */
INSERT INTO University(Id,Name)
VALUES
('UKSW','Universitas Kristen Satya Wacana'),
('UKDW','Universitas Kristen Duta Wacana'),
('Gundar','Universitas Guna Darma')
/* Education */
INSERT INTO Education(Id,Degree_Id,Major_Id,University_Id)
VALUES
('S1_TI_UKSW','S1','TI','UKSW'),
('S1_TI_UKDW','S1','TI','UKDW'),
('S1_TI_Gundar','S1','TI','Gundar')
/* Language */
INSERT INTO Language(Id,Name)
VALUES
('ID','Indonesia'),
('EN','Inggris')

/* Employee */
INSERT INTO Employee(Id,FirstName,LastName,Phone,DateOfBirth,Email,Username,Password)
VALUES
('14422','Devid','Bardin','0857','19960205','dav3rliando@gmail.com','daverliando','blahblahblah'),
('14xxx','Naufal','Wibowo','0856','19960205','naufal.aji@mii.co.id','naufalaji','blahblahblah'),
('14yyy','Joko','Santosa','0877','19960205','joko.santosa@mii.co.id','jokosantosa','blahblahblah')

-- /* Room */
INSERT INTO Room(Id,Name)
VALUES
('Jo','Johannesburg'),
('Am','Amsterdam'),
('Os','Osaka'),
('Mi','Miami')
/* Class */
INSERT INTO Class(Id,Name)
VALUES
('Java','Java'),
('Net','.Net')
/* Batch */
INSERT INTO Batch(Id,StartDate,EndDate)
VALUES
('21','20181101','20181231'),
('22','20190101','20190228'),
('23','20190201','20190331')
/* Batch Class */
INSERT INTO Batch_Class(Id,Trainer_Id,Batch_Id,Class_Id,Room_Id)
VALUES
('22Java','14xxx','22','Java','Os'),
('22Net','14yyy','22','Net','Am'),
('23Java','14422','23','Java','Mi')