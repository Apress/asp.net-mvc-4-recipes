CREATE TABLE [dbo].[PlaylistItem]
(
	[PlaylistItemId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PlaylistId] INT NOT NULL, 
    [SongId] INT NOT NULL, 
    [DisplayOrder] INT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_PlaylistItem_Paylist] FOREIGN KEY ([PlaylistId]) REFERENCES [Playlist]([PlaylistId]) ON DELETE CASCADE, 
    CONSTRAINT [FK_PlaylistItem_Song] FOREIGN KEY ([SongId]) REFERENCES [Song]([SongId])
)
