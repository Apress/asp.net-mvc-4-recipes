CREATE TABLE [dbo].[Alert](
	[AlertId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Headline] [varchar](50) NOT NULL,
	[Summary] [varchar](500) NOT NULL,
	[ArtistId] INT NOT NULL,
	[ActorDisplayName] [varchar](50) NOT NULL,
	[ActorUrl] [varchar](255) NOT NULL,
	[ActorAvatarUrl] [varchar](255) NOT NULL,
	[AlertUrl] [varchar](255) NOT NULL,
	[AlertAddedDate] [datetime] NOT NULL,
	[ClickCount] [int] NOT NULL DEFAULT 0,
	[AlertDate] [datetime] NOT NULL DEFAULT getdate(),
	[Category] [int] NOT NULL,
	[ItemIdentifier] [varchar](50) NOT NULL,
	[ItemDetailIdentifier] [int] NOT NULL DEFAULT 0
) 




