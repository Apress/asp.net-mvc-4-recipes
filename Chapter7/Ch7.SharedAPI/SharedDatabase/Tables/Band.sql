CREATE TABLE [dbo].[Band]
(
	[BandId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [BandName] VARCHAR(50) NOT NULL, 
    [BandBio] VARCHAR(1000) NULL, 
    [BandLogoUrl] VARCHAR(100) NULL, 
    [BandBackgroundImageUrl] VARCHAR(100) NULL, 
    [BandDisplayPhotoUrl] VARCHAR(100) NULL, 
    [CreateDate] DATETIME NULL, 
    [ModifiedDate] DATETIME NULL
)
