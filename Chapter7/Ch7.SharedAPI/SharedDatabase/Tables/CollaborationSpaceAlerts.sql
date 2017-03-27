CREATE TABLE [dbo].[CollaborationSpaceAlerts]
(
	[CollaborationSpaceAlertId] INT NOT NULL PRIMARY KEY,
	CollaborationSpaceId INT NOT NULL, 
    [ArtistId] INT NOT NULL, 
    [CreateDate] DATETIME NOT NULL DEFAULT getdate(), 
    CONSTRAINT [FK_CollaborationSpaceAlerts_CollaborationSpace] FOREIGN KEY ([CollaborationSpaceId]) REFERENCES [CollaborationSpace]([CollaborationSpaceId]), 
    CONSTRAINT [FK_CollaborationSpaceAlerts_Artist] FOREIGN KEY ([ArtistId]) REFERENCES [Artist]([ArtistId])
)
