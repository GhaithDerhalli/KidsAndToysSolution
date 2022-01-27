CREATE TABLE [dbo].[Age]
(
	[Id] INT NOT NULL PRIMARY KEY References Products(Id),
	
	[0-3 Mån] nvarchar Not null,
	[3-6 Mån] nvarchar Not null,
	[6-9 Mån] nvarchar Not null,
	[9-12 Mån] nvarchar Not null
)
