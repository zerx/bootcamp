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

INSERT [dbo].[Todo] ([Id], [Name], [Description], [Priority], [Responsible], [Deadline], [Status], [ModTime], [CategoryId], [ParentId], [Deleted])
VALUES (N'2d8adee6-5bcf-46c2-a5f1-3f17501c133f', N'Test01', N'test01', N'1', N'Vektor', N'2019-03-04 00:00:00.0000000', N'Open', N'2019-03-04 00:00:00.0000000', N'4dcd6146-7e7f-42a2-9f3e-0a8b6684c4af', N'00000000-0000-0000-0000-000000000000', 0)
GO

INSERT [dbo].[Todo] ([Id], [Name], [Description], [Priority], [Responsible], [Deadline], [Status], [ModTime], [CategoryId], [ParentId], [Deleted])
VALUES (N'cbf1008e-18da-4a1d-95f2-216c21ac667b', N'Test02', N'test02', N'1', N'Gábor', N'2019-03-04 00:00:00.0000000', N'Open', N'2019-03-04 00:00:00.0000000', N'4dcd6146-7e7f-42a2-9f3e-0a8b6684c4af', N'00000000-0000-0000-0000-000000000000', 0)
GO

INSERT [dbo].[Todo] ([Id], [Name], [Description], [Priority], [Responsible], [Deadline], [Status], [ModTime], [CategoryId], [ParentId], [Deleted])
VALUES (N'e8d6ba69-5e8a-44ac-ab6d-b37a91e6a47a', N'Test03', N'test03', N'1', N'Gábor', N'2019-03-04 00:00:00.0000000', N'Open', N'2019-03-04 00:00:00.0000000', N'74587792-9a75-46a5-b880-3641a3d0ee02', N'cbf1008e-18da-4a1d-95f2-216c21ac667b', 0)
GO

INSERT [dbo].[Todo] ([Id], [Name], [Description], [Priority], [Responsible], [Deadline], [Status], [ModTime], [CategoryId], [ParentId], [Deleted])
VALUES (N'812c24a5-3aa6-482c-9008-4710ff610450', N'Test04', N'test04', N'1', N'Vektor', N'2019-03-04 00:00:00.0000000', N'Open', N'2019-03-04 00:00:00.0000000', N'f6c391a1-4146-406b-9df4-eba09504dc06', N'e8d6ba69-5e8a-44ac-ab6d-b37a91e6a47a', 0)
GO

INSERT [dbo].[Todo] ([Id], [Name], [Description], [Priority], [Responsible], [Deadline], [Status], [ModTime], [CategoryId], [ParentId], [Deleted])
VALUES (N'59845445-fb61-4ad5-a1bb-18768df56f15', N'Test05', N'test05', N'1', N'Zoltán', N'2019-03-04 00:00:00.0000000', N'Open', N'2019-03-04 00:00:00.0000000', N'f6c391a1-4146-406b-9df4-eba09504dc06', N'e8d6ba69-5e8a-44ac-ab6d-b37a91e6a47a', 0)
GO