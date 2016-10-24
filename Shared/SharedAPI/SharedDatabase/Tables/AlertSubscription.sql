CREATE TABLE [dbo].[AlertSubscription](
	[AlertSubscriptionId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED ,
	[ArtistId] INT NOT NULL,
	[Tags] [varchar](50) NOT NULL, 
    CONSTRAINT [FK_AlertSubscription_Artist] FOREIGN KEY ([ArtistId]) REFERENCES [Artist]([ArtistId]),
) 


