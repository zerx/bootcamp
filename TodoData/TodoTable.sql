﻿CREATE TABLE [dbo].[TodoTable]
(
	[Id] UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL PRIMARY KEY, 
	[Name] VARCHAR(30) NOT NULL, 
	[Description] NVARCHAR(300) NULL, 
	[Priority] INT NOT NULL, 
	[Responsible] NVARCHAR(30) NULL, 
	[Deadline] DATETIME2 NULL, 
	[Status] NVARCHAR(30) NULL, 
	[Category] INT NULL, 
	[ParentId] INT NULL
)
