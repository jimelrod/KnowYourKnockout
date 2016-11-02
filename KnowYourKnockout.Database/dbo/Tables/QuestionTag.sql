CREATE TABLE [dbo].[QuestionTag]
(
	[Id] INT IDENTITY(1,1) NOT NULL,
    [QuestionId] INT NOT NULL, 
    [TagId] INT NOT NULL

	CONSTRAINT [PK_QuestionTag] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_QuestionTag_Question] FOREIGN KEY ([QuestionId]) REFERENCES [Question]([Id]),
	CONSTRAINT [FK_QuestionTag_Tag] FOREIGN KEY ([TagId]) REFERENCES [Tag]([Id])
)
