CREATE TABLE [dbo].[CollaborationSpaceComment]
(
	[CollaborationSpaceCommentId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CollaborationSpaceId] INT NOT NULL, 
	[ArtistId] INT NOT NULL,
    [CollabortationSpaceFileId] INT NULL, 
    [CommentTitle] VARCHAR(50) NULL, 
    [CommentBody] VARCHAR(5000) NULL, 
    [ThreadId] INT NOT NULL DEFAULT 0, 
    [ParentId] INT NOT NULL DEFAULT 0, 
    [NestLevel] INT NOT NULL DEFAULT 0, 
    [Path] VARCHAR(800) NOT NULL DEFAULT '/', 
    [CreateDate] DATETIME NOT NULL DEFAULT getdate(), 
    CONSTRAINT [FK_CollaborationSpaceComment_CollaborationSpace] FOREIGN KEY ([CollaborationSpaceId]) REFERENCES [CollaborationSpace]([CollaborationSpaceId]), 
    CONSTRAINT [FK_CollaborationSpaceComment_Artist] FOREIGN KEY ([ArtistId]) REFERENCES [Artist]([ArtistId]), 
    CONSTRAINT [FK_CollaborationSpaceComment_ToTable] FOREIGN KEY ([CollabortationSpaceFileId]) REFERENCES [CollaborationSpaceFile]([CollaborationSpaceFileId])
)
