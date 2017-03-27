CREATE TABLE [dbo].[Message](
	[MessageId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ArtistId] INT NOT NULL,
	[Subject] [varchar](50) NOT NULL,
	[Importance] [smallint] NOT NULL,
	[DateSent] [smalldatetime] NOT NULL,
	[MessageBody] [varchar](max) NOT NULL,
	CONSTRAINT [FK_Message_Artist] FOREIGN KEY (ArtistId) REFERENCES [Artist]([ArtistId]),
 )
 