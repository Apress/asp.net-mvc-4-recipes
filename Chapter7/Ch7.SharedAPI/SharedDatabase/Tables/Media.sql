CREATE TABLE [dbo].[Media]
(
	[MediaId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ArtistId] INT NULL, 
    [FriendlyFileName] VARCHAR(50) NOT NULL,
	[FileExtention] VARCHAR(5) NOT NULL,  
    [LocalFilePath] VARCHAR(255) NULL, 
    [WebURL] VARCHAR(255) NULL, 
    [IsCloudBlob] BIT NOT NULL DEFAULT 0, 
    [AzureStorageContainer] VARCHAR(50) NULL, 
    [AzureBlobReferenceName] VARCHAR(50) NULL, 
    [MediaType] TINYINT NOT NULL DEFAULT 0, 
    [FileSizeInBytes] INT NOT NULL DEFAULT 0, 
    [BitRateInKbps] INT NOT NULL DEFAULT 0, 
    [AllowDownload] INT NOT NULL DEFAULT 0, 
    [DownloadCount] INT NOT NULL DEFAULT 0, 
    [IsDeleted] BIT NOT NULL DEFAULT 0, 
	[IsFileDeleted] BIT NOT NULL DEFAULT 0, 
    [RIPEMD160Hash] VARCHAR(40) NULL,
    [CreateDate] DATETIME NOT NULL DEFAULT getdate(), 
    [ModifiedDate] DATETIME NOT NULL DEFAULT getdate(), 
    CONSTRAINT [FK_Media_ToTable] FOREIGN KEY ([ArtistId]) REFERENCES [Artist]([ArtistId]) 
)
