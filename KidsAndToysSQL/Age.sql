CREATE TABLE [dbo].[Age]
(
	[Id] INT NOT NULL PRIMARY KEY References Products(Id),
	[Age] nvarchar (450) Not null unique 
)
