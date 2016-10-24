CREATE TABLE [dbo].[ArtistProfile]
(
	[ArtistId] INT NOT NULL PRIMARY KEY,
	[Bio] VARCHAR(Max) NULL, 
    [MusicalInfluences] VARCHAR(1024) NULL, 
    [ProfileTemplateName] VARCHAR(50) NULL DEFAULT 'basic', 
    [FirstName] VARCHAR(50) NULL, 
    [LastName] VARCHAR(50) NULL, 
    CONSTRAINT [FK_ArtistProfile_Artist] FOREIGN KEY ([ArtistId]) REFERENCES [Artist]([ArtistId]), 
)
