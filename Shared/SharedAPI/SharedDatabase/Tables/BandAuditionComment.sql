CREATE TABLE [dbo].[BandAuditionComment]
(
	[BandAuditionCommentId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[BandAuditionId] [int] NOT NULL,
	[ArtistId] [int] NOT NULL,
	[Comment] [varchar](1000) NOT NULL,
	[Rating] [int] NOT NULL DEFAULT 0,
	[Vote] [bit] NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_BandAuditionComment_Artist] FOREIGN KEY ([ArtistId]) REFERENCES [Artist]([ArtistId]), 
    CONSTRAINT [FK_BandAuditionComment_BandAudition] FOREIGN KEY ([BandAuditionId]) REFERENCES [BandAudition]([BandAuditionId])
)
