CREATE TABLE [dbo].[MessageRecipient](
	[MessageRecipientId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[MessageId] [int] NOT NULL,
	[ArtistId] INT NOT NULL,
	[MessageRead] [bit] NOT NULL,
	[MessageStatus] [smallint] NOT NULL,
	[Folder] [varchar](50) NULL,
    CONSTRAINT [FK_MessageRecipient_Message] FOREIGN KEY (MessageId) REFERENCES [Message]([MessageId]),
	CONSTRAINT [FK_MessageRecipient_Artist] FOREIGN KEY (ArtistId) REFERENCES [Artist]([ArtistId]),
)
