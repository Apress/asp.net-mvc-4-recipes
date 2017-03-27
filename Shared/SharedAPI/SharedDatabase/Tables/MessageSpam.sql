CREATE TABLE [dbo].[MessageSpam](
	[MessageSpamID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[MessageId] [int] NOT NULL,
	[MessageBodyHash] [int] NOT NULL
) 
