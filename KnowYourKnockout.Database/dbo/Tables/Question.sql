CREATE TABLE [dbo].[Question]
(
	[Id] INT IDENTITY(1,1) NOT NULL,
    [AskerId] INT NOT NULL,
    [ResponderId] INT NOT NULL,
    [QuestionText] NVARCHAR(MAX) NOT NULL, 
	[AnswerText] NVARCHAR(MAX), 
    [IsQuestionPublic] BIT NOT NULL DEFAULT 0,
	[IsAnswerPublished] BIT NOT NULL DEFAULT 0,
	[AskedOn] DATETIME NOT NULL DEFAULT GETDATE(),
	[AnsweredOn] DATETIME NULL DEFAULT GETDATE(),

	CONSTRAINT [PK_Question] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Question_User_Asker] FOREIGN KEY ([AskerId]) REFERENCES [User]([Id]),
	CONSTRAINT [FK_Question_User_Responder] FOREIGN KEY ([ResponderId]) REFERENCES [User]([Id])
)
