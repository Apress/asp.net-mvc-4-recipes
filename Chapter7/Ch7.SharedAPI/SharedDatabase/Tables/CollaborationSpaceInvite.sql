CREATE TABLE [dbo].[CollaborationSpaceInvite]
(
	[CollaborationSpaceInviteId] INT NOT NULL PRIMARY KEY, 
    [CollaborationSpaceId] INT NOT NULL,
	[EmailAddress] [varchar](150) NOT NULL,
	[ArtistId] INT NOT NULL,
	[BandId] [int] NULL,
	[LinkIdentifier] [uniqueidentifier] NOT NULL,
	[CreateDate] [datetime] NOT NULL, 
    CONSTRAINT [FK_CollaborationSpaceInvite_CollaborationSpace] FOREIGN KEY ([CollaborationSpaceId]) REFERENCES [CollaborationSpace]([CollaborationSpaceId]), 
    CONSTRAINT [FK_CollaborationSpaceInvite_Artist] FOREIGN KEY ([ArtistId]) REFERENCES [Artist]([ArtistId]),
)
