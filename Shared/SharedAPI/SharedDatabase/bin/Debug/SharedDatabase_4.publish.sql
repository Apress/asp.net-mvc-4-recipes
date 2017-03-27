﻿/*
Deployment script for Ch7SharedDatabase

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "Ch7SharedDatabase"
:setvar DefaultFilePrefix "Ch7SharedDatabase"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Rename refactoring operation with key 7e4b03e7-ec93-4afd-87e4-6d230b2bcc62 is skipped, element [dbo].[Song].[Id] (SqlSimpleColumn) will not be renamed to SongId';


GO
PRINT N'Rename refactoring operation with key a598edb1-d45e-423c-a93c-f7503b7b3e55 is skipped, element [dbo].[Song].[AlbumArtist] (SqlSimpleColumn) will not be renamed to ReleaseYear';


GO
PRINT N'Rename refactoring operation with key 042a50ef-6c18-4672-bc05-48fdfc1f3902, 686ed737-e4ad-43d8-9315-91d08aa685bc is skipped, element [dbo].[Song].[Album] (SqlSimpleColumn) will not be renamed to ArtworkURL';


GO
PRINT N'Rename refactoring operation with key 03f706a4-f7e0-416a-bc64-8aeb277e154d is skipped, element [dbo].[Media].[Id] (SqlSimpleColumn) will not be renamed to MediaId';


GO
PRINT N'Rename refactoring operation with key 3c6ad0fb-41d1-47a5-b89c-eb51ae774165 is skipped, element [dbo].[Media].[FileName] (SqlSimpleColumn) will not be renamed to FriendlyFileName';


GO
PRINT N'Rename refactoring operation with key 03104f30-768f-4e3d-adca-e8e41f84dd78 is skipped, element [dbo].[Media].[FileSize] (SqlSimpleColumn) will not be renamed to FileSizeInBytes';


GO
PRINT N'Rename refactoring operation with key 5ff45258-440a-4f1f-b1e4-483b3f7b3ac7, f4828e4d-025c-4bea-a677-a92628b3e5d7 is skipped, element [dbo].[Media].[hieght] (SqlSimpleColumn) will not be renamed to AllowDownload';


GO
PRINT N'Rename refactoring operation with key c054cabe-f455-475a-9485-44a109972dbe is skipped, element [dbo].[PlayList].[Id] (SqlSimpleColumn) will not be renamed to PlaylistId';


GO
PRINT N'Rename refactoring operation with key b7ba2a71-730c-4cc5-8111-7a4c4166fce8 is skipped, element [dbo].[PlaylistItem].[Id] (SqlSimpleColumn) will not be renamed to PlaylistItemId';


GO
PRINT N'Creating [dbo].[Media]...';


GO
CREATE TABLE [dbo].[Media] (
    [MediaId]                INT           NOT NULL,
    [ArtistId]               INT           NOT NULL,
    [FriendlyFileName]       VARCHAR (50)  NOT NULL,
    [FileExtention]          VARCHAR (5)   NOT NULL,
    [LocalFilePath]          VARCHAR (255) NULL,
    [WebURL]                 VARCHAR (255) NULL,
    [IsCloudBlob]            BIT           NOT NULL,
    [AzureStorageContainer]  VARCHAR (50)  NULL,
    [AzureBlobReferenceName] VARCHAR (50)  NULL,
    [MediaType]              TINYINT       NOT NULL,
    [FileSizeInBytes]        INT           NOT NULL,
    [BitRateInKbps]          INT           NOT NULL,
    [AllowDownload]          INT           NOT NULL,
    [DownloadCount]          INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([MediaId] ASC)
);


GO
PRINT N'Creating [dbo].[PlayList]...';


GO
CREATE TABLE [dbo].[PlayList] (
    [PlaylistId]        INT          NOT NULL,
    [Title]             VARCHAR (50) NULL,
    [ArtistId]          INT          NULL,
    [BandId]            INT          NULL,
    [IsSitePlaylist]    BIT          NOT NULL,
    [IsDefaultPlaylist] BIT          NOT NULL,
    PRIMARY KEY CLUSTERED ([PlaylistId] ASC)
);


GO
PRINT N'Creating [dbo].[PlaylistItem]...';


GO
CREATE TABLE [dbo].[PlaylistItem] (
    [PlaylistItemId] INT NOT NULL,
    [PlayListId]     INT NOT NULL,
    [SongId]         INT NOT NULL,
    [DisplayOrder]   INT NOT NULL,
    PRIMARY KEY CLUSTERED ([PlaylistItemId] ASC)
);


GO
PRINT N'Creating [dbo].[Song]...';


GO
CREATE TABLE [dbo].[Song] (
    [SongId]           INT            NOT NULL,
    [MediaId]          INT            NOT NULL,
    [SongTitle]        VARCHAR (50)   NOT NULL,
    [ReleaseYear]      INT            NULL,
    [ArtworkURL]       VARCHAR (255)  NULL,
    [ArtworkThumbURL]  VARCHAR (255)  NULL,
    [Lyrics]           VARCHAR (1024) NULL,
    [SongDescription]  VARCHAR (1024) NULL,
    [ArtistName]       VARCHAR (50)   NULL,
    [ArtistProfileUrl] VARCHAR (255)  NULL,
    [Genre]            VARCHAR (50)   NULL,
    PRIMARY KEY CLUSTERED ([SongId] ASC)
);


GO
PRINT N'Creating Default Constraint on [dbo].[Media]....';


GO
ALTER TABLE [dbo].[Media]
    ADD DEFAULT 0 FOR [IsCloudBlob];


GO
PRINT N'Creating Default Constraint on [dbo].[Media]....';


GO
ALTER TABLE [dbo].[Media]
    ADD DEFAULT 0 FOR [MediaType];


GO
PRINT N'Creating Default Constraint on [dbo].[Media]....';


GO
ALTER TABLE [dbo].[Media]
    ADD DEFAULT 0 FOR [FileSizeInBytes];


GO
PRINT N'Creating Default Constraint on [dbo].[Media]....';


GO
ALTER TABLE [dbo].[Media]
    ADD DEFAULT 0 FOR [BitRateInKbps];


GO
PRINT N'Creating Default Constraint on [dbo].[Media]....';


GO
ALTER TABLE [dbo].[Media]
    ADD DEFAULT 0 FOR [AllowDownload];


GO
PRINT N'Creating Default Constraint on [dbo].[Media]....';


GO
ALTER TABLE [dbo].[Media]
    ADD DEFAULT 0 FOR [DownloadCount];


GO
PRINT N'Creating Default Constraint on [dbo].[PlayList]....';


GO
ALTER TABLE [dbo].[PlayList]
    ADD DEFAULT 0 FOR [IsSitePlaylist];


GO
PRINT N'Creating Default Constraint on [dbo].[PlayList]....';


GO
ALTER TABLE [dbo].[PlayList]
    ADD DEFAULT 0 FOR [IsDefaultPlaylist];


GO
PRINT N'Creating Default Constraint on [dbo].[PlaylistItem]....';


GO
ALTER TABLE [dbo].[PlaylistItem]
    ADD DEFAULT 0 FOR [DisplayOrder];


GO
PRINT N'Creating FK_Media_ToTable...';


GO
ALTER TABLE [dbo].[Media] WITH NOCHECK
    ADD CONSTRAINT [FK_Media_ToTable] FOREIGN KEY ([ArtistId]) REFERENCES [dbo].[Artist] ([ArtistId]);


GO
PRINT N'Creating FK_PlayList_Artist...';


GO
ALTER TABLE [dbo].[PlayList] WITH NOCHECK
    ADD CONSTRAINT [FK_PlayList_Artist] FOREIGN KEY ([ArtistId]) REFERENCES [dbo].[Artist] ([ArtistId]);


GO
PRINT N'Creating FK_PlayList_Band...';


GO
ALTER TABLE [dbo].[PlayList] WITH NOCHECK
    ADD CONSTRAINT [FK_PlayList_Band] FOREIGN KEY ([BandId]) REFERENCES [dbo].[Band] ([BandId]);


GO
PRINT N'Creating FK_PlaylistItem_PayList...';


GO
ALTER TABLE [dbo].[PlaylistItem] WITH NOCHECK
    ADD CONSTRAINT [FK_PlaylistItem_PayList] FOREIGN KEY ([PlayListId]) REFERENCES [dbo].[PlayList] ([PlaylistId]);


GO
PRINT N'Creating FK_Song_Media...';


GO
ALTER TABLE [dbo].[Song] WITH NOCHECK
    ADD CONSTRAINT [FK_Song_Media] FOREIGN KEY ([MediaId]) REFERENCES [dbo].[Media] ([MediaId]);


GO
-- Refactoring step to update target server with deployed transaction logs
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '7e4b03e7-ec93-4afd-87e4-6d230b2bcc62')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('7e4b03e7-ec93-4afd-87e4-6d230b2bcc62')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'a598edb1-d45e-423c-a93c-f7503b7b3e55')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('a598edb1-d45e-423c-a93c-f7503b7b3e55')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '042a50ef-6c18-4672-bc05-48fdfc1f3902')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('042a50ef-6c18-4672-bc05-48fdfc1f3902')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '03f706a4-f7e0-416a-bc64-8aeb277e154d')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('03f706a4-f7e0-416a-bc64-8aeb277e154d')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '3c6ad0fb-41d1-47a5-b89c-eb51ae774165')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('3c6ad0fb-41d1-47a5-b89c-eb51ae774165')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '03104f30-768f-4e3d-adca-e8e41f84dd78')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('03104f30-768f-4e3d-adca-e8e41f84dd78')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '5ff45258-440a-4f1f-b1e4-483b3f7b3ac7')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('5ff45258-440a-4f1f-b1e4-483b3f7b3ac7')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'f4828e4d-025c-4bea-a677-a92628b3e5d7')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('f4828e4d-025c-4bea-a677-a92628b3e5d7')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '686ed737-e4ad-43d8-9315-91d08aa685bc')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('686ed737-e4ad-43d8-9315-91d08aa685bc')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'c054cabe-f455-475a-9485-44a109972dbe')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('c054cabe-f455-475a-9485-44a109972dbe')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'b7ba2a71-730c-4cc5-8111-7a4c4166fce8')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('b7ba2a71-730c-4cc5-8111-7a4c4166fce8')

GO

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Media] WITH CHECK CHECK CONSTRAINT [FK_Media_ToTable];

ALTER TABLE [dbo].[PlayList] WITH CHECK CHECK CONSTRAINT [FK_PlayList_Artist];

ALTER TABLE [dbo].[PlayList] WITH CHECK CHECK CONSTRAINT [FK_PlayList_Band];

ALTER TABLE [dbo].[PlaylistItem] WITH CHECK CHECK CONSTRAINT [FK_PlaylistItem_PayList];

ALTER TABLE [dbo].[Song] WITH CHECK CHECK CONSTRAINT [FK_Song_Media];


GO
PRINT N'Update complete.'
GO
