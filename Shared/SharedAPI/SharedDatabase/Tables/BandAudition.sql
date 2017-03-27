CREATE TABLE [dbo].[BandAudition]
(
	[BandAuditionId] [int] IDENTITY(1,1) NOT NULL  PRIMARY KEY CLUSTERED,
	[ProjectOpenPositionId] [int] NOT NULL,
	[ArtistId] [int] NOT NULL,
	[SongId] [int] NOT NULL,
	[VotesRequired] [int] NOT NULL,
	[VotesRecieved] [int] NOT NULL,
	[Status] [varchar](10) NOT NULL, 
    CONSTRAINT [FK_BandAudition_Artist] FOREIGN KEY ([ArtistId]) REFERENCES [Artist]([ArtistId]),
	CONSTRAINT [FK_BandAudition_Song] FOREIGN KEY ([SongId]) REFERENCES [Song]([SongId]),
)
