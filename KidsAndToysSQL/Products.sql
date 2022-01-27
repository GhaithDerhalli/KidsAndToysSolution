﻿CREATE TABLE [dbo].[Products]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,1),
	[UserId] nvarchar (450) NOT NULL References Users(Id),
	[ProductName] varchar (30) NOT NULL,
	[AgeId] INT NOT NULL REFERENCES Ages(Id),
	[CategoryId] int  NOT NULL,
	[ConditionId]  int NOT NULL,
	[ConditionDescription] varchar(MAX) NULL,
	[Price] money NOT NULL,
	[Description] varchar NULL,
	[CityId] int NOT NULL
)
