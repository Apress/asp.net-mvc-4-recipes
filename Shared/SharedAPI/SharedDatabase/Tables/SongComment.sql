CREATE TABLE [dbo].[SongComment]
(
	[SongCommentId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SongId] INT NULL, 
    [Comment] VARCHAR(1000) NULL, 
    [Rating] INT NOT NULL DEFAULT 3, 
    [CreateDate] DATETIME NULL, 
    [IsApproved] BIT NOT NULL DEFAULT 0, 
    [IsAnonymous] BIT NOT NULL DEFAULT 0, 
    [Name] VARCHAR(50) NULL, 
    [EmailAddress] VARCHAR(150) NULL, 
    CONSTRAINT [FK_SongComment_Song] FOREIGN KEY ([SongId]) REFERENCES [Song]([SongId])
)
