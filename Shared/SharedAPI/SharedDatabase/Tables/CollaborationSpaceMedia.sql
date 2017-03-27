CREATE TABLE [dbo].[CollaborationSpaceMedia]
(
	[CollaborationSpaceMediaId] INT NOT NULL IDENTITY PRIMARY KEY, 
    [CollaborationSpaceId] INT NOT NULL, 
    [MediaId] INT NOT NULL, 
    [ModifiedDate] DATETIME NOT NULL DEFAULT getdate(), 
    [Archive] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_CollaborationSpaceMedia_CollaborationSpace] FOREIGN KEY ([CollaborationSpaceId]) REFERENCES [CollaborationSpace]([CollaborationSpaceId]), 
    CONSTRAINT [FK_CollaborationSpaceMedia_ToTable_1] FOREIGN KEY ([MediaId]) REFERENCES [Media]([MediaId])
)
