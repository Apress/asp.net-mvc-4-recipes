CREATE TABLE [dbo].[BandGenre]
(
	[BandGenreId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [BandId] INT NOT NULL, 
    [GenreLookUpId] INT NOT NULL, 
    CONSTRAINT [FK_BandGenre_Band] FOREIGN KEY ([BandId]) REFERENCES [Band]([BandId]), 
    CONSTRAINT [FK_BandGenre_GenreLookUp] FOREIGN KEY (GenreLookUpId) REFERENCES [GenreLookUp]([GenreLookUpId])
)