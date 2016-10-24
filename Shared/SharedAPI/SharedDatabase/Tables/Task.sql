CREATE TABLE [dbo].[Task](
	[TaskID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[ArtistId] INT NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[Details] [varchar](255) NOT NULL,
	[DueDate] [datetime] NULL,
	[State] [int] NULL,
	[LinkType] [int] NULL,
	[LinkTypeID] [int] NULL,
	[CreateDate] [smalldatetime] NOT NULL DEFAULT getDate(),
	[ModifiedDate] [smalldatetime] NOT NULL DEFAULT getDate(), 
    CONSTRAINT [FK_Task_Artist] FOREIGN KEY (ArtistId) REFERENCES [Artist]([ArtistId])
) 