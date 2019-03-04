﻿CREATE TABLE [dbo].[Todo]
(
	[Id] UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL PRIMARY KEY, 
	[Name] VARCHAR(30) NULL, 
	[Description] NVARCHAR(300) NULL, 
	[Priority] INT NULL, 
	[Responsible] NVARCHAR(30) NULL, 
	[Deadline] DATETIME2 NULL, 
	[Status] NVARCHAR(30) NULL,
	[ModTime] DATETIME2 NULL,
	[CategoryId] UNIQUEIDENTIFIER NULL, 
	[ParentId] UNIQUEIDENTIFIER NULL
)
