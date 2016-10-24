CREATE TABLE [dbo].[Artist]
(
	[ArtistId] INT NOT NULL PRIMARY KEY IDENTITY, 
	[OldUserId] uniqueidentifier null,
    [UserName] VARCHAR(256) NOT NULL, 
    [Country] VARCHAR(50) NULL, 
    [Provence] VARCHAR(65) NULL, 
	[City] VARCHAR(50) NULL, 
    [CreateDate] DATETIME NOT NULL DEFAULT getdate(),
	[ModifiedDate] DATETIME NOT NULL DEFAULT getdate(), 
    [WebSite] VARCHAR(255) NULL, 
    [ProfilePrivacyLevel] TINYINT NOT NULL DEFAULT 0, 
    [ContactPrivacyLevel] TINYINT NOT NULL DEFAULT 0, 
    [ProfileViews] BIGINT NOT NULL DEFAULT 0, 
	[ProfileLastViewDate] SMALLDATETIME NULL, 
    [Rating] TINYINT NULL DEFAULT 3, 
    [AvatarURL] VARCHAR(255) NULL, 
    [EmailAddress] VARCHAR(256) NULL, 
    [FileUploadsInBytes] INT NOT NULL DEFAULT 0, 
    [FileUploadQuotaInBytes] INT NOT NULL DEFAULT 0, 
    [LastActivityDate] DATETIME NOT NULL DEFAULT getdate(), 
    [ShowChatStatus] BIT NOT NULL DEFAULT 1, 
    [AllowChatSounds] BIT NOT NULL DEFAULT 1
)
