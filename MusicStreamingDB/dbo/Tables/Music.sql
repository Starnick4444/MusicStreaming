CREATE TABLE [dbo].[Music]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Title] varchar(50) NOT NULL, 
    [Path] VARCHAR(100) NOT NULL, 
    [Description] VARCHAR(255) NULL, 
    [Extension] NCHAR(10) NOT NULL
)
