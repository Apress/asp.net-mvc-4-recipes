CREATE TABLE [dbo].[CollaborationSpaceGenre]
(
	[CollaborationSpaceGenreId] INT IDENTITY NOT NULL PRIMARY KEY, 
    [CollaborationSpaceId] INT NOT NULL, 
    [GenreLookUpId] INT NOT NULL, 
    CONSTRAINT [FK_CollaborationSpaceGenre_CollaborationSpace] FOREIGN KEY ([CollaborationSpaceId]) REFERENCES [CollaborationSpace]([CollaborationSpaceId]), 
    CONSTRAINT [FK_CollaborationSpaceGenre_GenreLookUp] FOREIGN KEY (GenreLookUpId) REFERENCES [GenreLookUp]([GenreLookUpId])
)
