CREATE TABLE [dbo].[QuestionTag]
(
	[QuestionId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [TagId] UNIQUEIDENTIFIER NOT NULL

	CONSTRAINT [FK_QuestionTag_Question] FOREIGN KEY ([QuestionId]) REFERENCES [Question]([Id]),
	CONSTRAINT [FK_QuestionTag_Tag] FOREIGN KEY ([TagId]) REFERENCES [Tag]([Id])
)
