CREATE TABLE [dbo].[ArtistFavorites]
(
	[ArtistFavoriteId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ArtistId] [int] NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[ItemId] [int] NULL,
	[Category] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL DEFAULT getdate(), 
    CONSTRAINT [FK_ArtistFavorites_Artist] FOREIGN KEY ([ArtistId]) REFERENCES [Artist]([ArtistId]),
)
