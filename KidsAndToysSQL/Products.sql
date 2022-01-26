CREATE TABLE [dbo].[Orders]
(
	[Id] INT NOT NULL PRIMARY KEY Identity,
	[UserId] INT NOT NULL,
	[ProductName] varchar (30) NOT NULL,
	[Age] INT NOT NULL,
	[Category] varchar(30)  NOT NULL,
	[Condition]  varchar (30) NOT NULL,
	[ConditionDescription] varchar(MAX) NULL,
	[Price] money NOT NULL,
	[Description] varchar NULL,
	[City] varchar NOT NULL
)
