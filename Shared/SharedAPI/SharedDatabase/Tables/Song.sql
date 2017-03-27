CREATE TABLE [dbo].[Song]
(
	[SongId] INT NOT NULL PRIMARY KEY IDENTITY, 
	[MediaId] INT NOT NULL,
    [SongTitle] VARCHAR(50) NOT NULL, 
    [ReleaseYear] INT NULL, 
    [ArtworkURL] VARCHAR(255) NULL, 
    [Lyrics] VARCHAR(1024) NULL, 
    [SongDescription] VARCHAR(1024) NULL, 
	[ActionParameter] VARCHAR(50) NULL, 
    [Action] VARCHAR(50) NULL, 
    [Controller] VARCHAR(50) NULL, 
    [GenreId] INT NULL DEFAULT 21, 
    [CreateDate] DATETIME NOT NULL DEFAULT getDate(), 
    [ShowInLibrary] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [FK_Song_Media] FOREIGN KEY ([MediaId]) REFERENCES [Media]([MediaId])
)
