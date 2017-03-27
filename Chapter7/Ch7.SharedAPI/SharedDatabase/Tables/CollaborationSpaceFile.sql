CREATE TABLE [dbo].[CollaborationSpaceFile]
(
	[CollaborationSpaceFileId] INT NOT NULL PRIMARY KEY IDENTITY,
	[CollaborationSpaceId] INT NOT NULL, 
    [MediaId] INT NOT NULL, 
    [Description] VARCHAR(1024) NULL, 
    [LikeCount] INT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_CollaborationSpaceFile_CollaborationSpace] FOREIGN KEY ([CollaborationSpaceId]) REFERENCES [CollaborationSpace]([CollaborationSpaceId]), 
    CONSTRAINT [FK_CollaborationSpaceFile_Media] FOREIGN KEY ([MediaId]) REFERENCES [Media]([MediaId])
)
