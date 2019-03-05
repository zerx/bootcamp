/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
INSERT [dbo].[Category] ([CategoryId], [Name], [CreationDate], [LastModified])
VALUES (N'4dcd6146-7e7f-42a2-9f3e-0a8b6684c4af', N'Epic', N'2019-03-04 00:00:00.0000000',N'2019-03-04 00:00:00.0000000' )
GO

INSERT [dbo].[Category] ([CategoryId], [Name], [CreationDate], [LastModified])
VALUES (N'74587792-9a75-46a5-b880-3641a3d0ee02', N'Bug', N'2019-03-04 00:00:00.0000000', N'2019-03-04 00:00:00.0000000')
GO

INSERT [dbo].[Category] ([CategoryId], [Name], [CreationDate], [LastModified])
VALUES (N'f6c391a1-4146-406b-9df4-eba09504dc06', N'Task', N'2019-03-04 00:00:00.0000000', N'2019-03-04 00:00:00.0000000')
GO