CREATE TABLE [dbo].[ArtistBlock]
(
	[ArtistBlockId] INT NOT NULL PRIMARY KEY,
	[ArtistId] [int] NOT NULL,
	[BlockedArtistId] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL DEFAULT getdate(),
	[ReportAsSpammer] [bit] NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_ArtistBlock_Artist] FOREIGN KEY ([ArtistId]) REFERENCES [Artist]([ArtistId]),
)
