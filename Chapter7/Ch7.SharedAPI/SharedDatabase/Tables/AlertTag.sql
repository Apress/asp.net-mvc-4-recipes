CREATE TABLE [dbo].[AlertTag](
	[AlertTagId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED ,
	[AlertId] [int] NOT NULL,
	[Tag] [varchar](36) NOT NULL, 
    CONSTRAINT [FK_AlertTag_Alert] FOREIGN KEY ([AlertId]) REFERENCES [Alert]([AlertId])
)





