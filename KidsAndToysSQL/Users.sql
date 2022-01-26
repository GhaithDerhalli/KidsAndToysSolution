CREATE TABLE [dbo].[Users]
(
    [Id] NVARCHAR (450) NOT NULL PRIMARY KEY, --References dbo.AspNetUsers(Id),
	[ZipCode] int NOT NULL,
	[Address] varchar(30) NOT NULL,
	[City] varchar(30) NOT NULL
)
