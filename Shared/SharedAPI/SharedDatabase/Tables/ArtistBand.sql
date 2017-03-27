CREATE TABLE [dbo].[ArtistBand]
(
	[ArtistBandId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ArtistId] INT NOT NULL, 
    [BandId] INT NULL, 
    [Role] VARCHAR(50) NOT NULL, 
    [JoinedDate] DATETIME NOT NULL, 
    [IsActiveMember] BIT NOT NULL DEFAULT 1, 
	[DeactivateDate] DATETIME NULL, 
    [AllowEditBand] BIT NOT NULL DEFAULT 0, 
    [IsMemberAdmin] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_ArtistBand_ToArtist] FOREIGN KEY ([ArtistId]) REFERENCES [Artist]([ArtistId]), 
    CONSTRAINT [FK_ArtistBand_ToBand] FOREIGN KEY ([BandId]) REFERENCES [Band]([BandId])
)
