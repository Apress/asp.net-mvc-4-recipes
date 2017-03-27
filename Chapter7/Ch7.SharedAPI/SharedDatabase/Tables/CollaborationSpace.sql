CREATE TABLE [dbo].[CollaborationSpace]
(
	[CollaborationSpaceId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] VARCHAR(100) NOT NULL, 
    [Description] VARCHAR(5000) NOT NULL, 
    [RestrictContributorsToBand] BIT NOT NULL DEFAULT 0, 
    [BandId] INT NULL, 
    [AllowPublicView] BIT NOT NULL DEFAULT 1, 
    [CopyrightModel] TINYINT NOT NULL DEFAULT 0, 
    [AllowContributorsToPublish] BIT NOT NULL DEFAULT 0, 
    [CreateDate] DATETIME NOT NULL DEFAULT getdate(), 
    [ModifiedDate] DATETIME NOT NULL DEFAULT getdate(), 
    [LastPostDate] DATETIME NULL,
	[PublishedDate] DATETIME NULL,  
    [NumberViews] INT NOT NULL DEFAULT 0, 
    [NumberComments] INT NOT NULL DEFAULT 0, 
    [Status] TINYINT NOT NULL DEFAULT 0, 
    [ConceptId] INT NULL , 
    [ConceptMediaType] VARCHAR(5) NULL, 
    CONSTRAINT [FK_CollaborationSpace_ToTable] FOREIGN KEY ([BandId]) REFERENCES [Band]([BandId])
)
