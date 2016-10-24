CREATE TABLE [dbo].[Playlist]
(
	[PlaylistId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] VARCHAR(50) NULL, 
    [ArtistId] INT NULL, 
    [BandId] INT NULL, 
    [IsSitePlaylist] BIT NOT NULL DEFAULT 0, 
    [IsDefaultPlaylist] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_Playlist_Artist] FOREIGN KEY ([ArtistId]) REFERENCES [Artist]([ArtistId]), 
    CONSTRAINT [FK_Playlist_Band] FOREIGN KEY ([BandId]) REFERENCES [Band]([BandId])
)
