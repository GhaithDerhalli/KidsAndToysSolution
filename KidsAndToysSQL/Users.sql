CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY Identity,
	[UserName] varchar(30) NOT NULL,
	[Epost] varchar(MAX) NOT NULL,
	[PhoneNumber] int NOT NULL,
	[ZipCode] int NOT NULL,
	[Address] varchar(30) NOT NULL,
	[City] varchar(30) NOT NULL
)
