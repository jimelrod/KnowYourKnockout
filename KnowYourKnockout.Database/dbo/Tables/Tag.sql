CREATE TABLE [dbo].[Tag]
(
	[Id] INT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(50) NOT NULL,

	CONSTRAINT [PK_Category] PRIMARY KEY ([Id])
)
