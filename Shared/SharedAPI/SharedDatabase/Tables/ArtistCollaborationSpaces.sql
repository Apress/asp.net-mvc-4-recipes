CREATE TABLE [dbo].[ArtistCollaborationSpaces]
(
	[ArtistCollaborationSpaceId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ArtistId] INT NOT NULL, 
    [CollaborationSpaceId] INT NOT NULL, 
    [IsCreator] BIT NOT NULL DEFAULT 0, 
    [FirstContributionDate] DATETIME NOT NULL DEFAULT getdate(), 
    [LastContributionDate] DATETIME NOT NULL DEFAULT getdate(), 
    [Note] VARCHAR(255) NULL, 
    CONSTRAINT [FK_ArtistCollaborationSpaces_ToTable] FOREIGN KEY ([ArtistId]) REFERENCES [Artist]([ArtistId]), 
    CONSTRAINT [FK_ArtistCollaborationSpaces_ToTable_1] FOREIGN KEY ([CollaborationSpaceId]) REFERENCES [CollaborationSpace]([CollaborationSpaceId])
)
