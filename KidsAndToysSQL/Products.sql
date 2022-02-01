CREATE TABLE [dbo].[Products]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,1),
	[UserId] nvarchar (450) NOT NULL References Users(Id),
	[ProductName] varchar (30) NOT NULL,
	[AgeId] INT NOT NULL REFERENCES Ages(Id),
	[GenderId] INT NOt NULL References Gender(Id),
	[MainCategoryId] int NOT NULL References MainCategories(Id),
	[CategoryId] int  NOT NULL REFERENCES Categories(Id),
	[ConditionId]  int NOT NULL REFERENCES Conditions(Id),
	[ConditionDescription] varchar(MAX) NULL,
	[Price] money NOT NULL,
	[Description] varchar (Max) NULL,
	[CityId] int NOT NULL REFERENCES Cities(Id),
	[AdsPic1] varchar(max) Not null,
	[AdsPic2] varchar(max) null,
	[AdsPic3] varchar(max) null,
	[AdsPic4] varchar(max) null
)
