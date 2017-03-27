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
PRINT N'Rename refactoring operation with key e3ad0f09-0b05-4b5e-8843-78a46d0bdaa5, bc518951-1857-427d-9677-49b63d25f63f is skipped, element [dbo].[Artist].[Id] (SqlSimpleColumn) will not be renamed to ArtistId';


GO
PRINT N'Rename refactoring operation with key ca67eee0-6342-4f1c-8c38-e6af1d2310a6 is skipped, element [dbo].[Artist].[CreateDate] (SqlSimpleColumn) will not be renamed to ProfileCreateDate';


GO
PRINT N'Rename refactoring operation with key 63c9f6f6-0b6b-4be3-8de7-45eb8874aaae is skipped, element [dbo].[CollaborationSpace].[Id] (SqlSimpleColumn) will not be renamed to CollaborationSpaceId';


GO
PRINT N'Rename refactoring operation with key e407f64e-703e-48be-b57b-4cab35971c23 is skipped, element [dbo].[CollaborationSpace].[RestrictContributersToBand] (SqlSimpleColumn) will not be renamed to RestrictContributorsToBand';


GO
PRINT N'Rename refactoring operation with key c40fbeab-4359-49be-b4bf-a3f8bd4e729f is skipped, element [dbo].[ArtistCollaborationSpaces].[Id] (SqlSimpleColumn) will not be renamed to ArtistCollaborationSpaceId';


GO
PRINT N'Rename refactoring operation with key 7117728c-4a60-4b4b-8f00-3a597b048a1d is skipped, element [dbo].[Band].[Id] (SqlSimpleColumn) will not be renamed to BandId';


GO
PRINT N'Rename refactoring operation with key 5a6856fd-1534-48ee-8ac9-e631f48223cc is skipped, element [dbo].[ArtistBand].[Id] (SqlSimpleColumn) will not be renamed to ArtistBandId';


GO
PRINT N'Rename refactoring operation with key aa02e475-9662-4c90-be67-70f7a4dbd4e2 is skipped, element [dbo].[ArtistBand].[DateJoined] (SqlSimpleColumn) will not be renamed to JoinedDate';


GO
PRINT N'Rename refactoring operation with key 39c736f6-acf1-423e-95b8-7ab463660af9 is skipped, element [dbo].[ArtistBand].[MemberStatus] (SqlSimpleColumn) will not be renamed to IsActiveMember';


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
PRINT N'Rename refactoring operation with key 5f8015a3-ca17-4dc6-befd-a35526b5e724 is skipped, element [dbo].[CollaborationSpaceComment].[Id] (SqlSimpleColumn) will not be renamed to CollaborationSpaceCpmmentId';


GO
PRINT N'Rename refactoring operation with key 3a1fe86d-092e-4eed-82f8-c3e3a2fd9217 is skipped, element [dbo].[CollaborationSpaceFile].[Id] (SqlSimpleColumn) will not be renamed to CollabortationSpaceFileId';


GO
PRINT N'Rename refactoring operation with key 7cf8a7ad-3fc5-4421-aa3d-a5792cc34485 is skipped, element [dbo].[CollaborationSpaceFile].[MediaID] (SqlSimpleColumn) will not be renamed to MediaId';


GO
PRINT N'Rename refactoring operation with key 1ae508c9-a3db-4d1d-9a7a-6a1b7c663db9 is skipped, element [dbo].[Message].[UserID] (SqlSimpleColumn) will not be renamed to ArtistID';


GO
PRINT N'Rename refactoring operation with key 294109f5-3078-4744-b610-68de6acbe1db is skipped, element [dbo].[Message].[MessageID] (SqlSimpleColumn) will not be renamed to MessageId';


GO
PRINT N'Rename refactoring operation with key c5a0a597-f99a-46fa-999f-107634f35634 is skipped, element [dbo].[MessageRecipient].[UserId] (SqlSimpleColumn) will not be renamed to ArtistId';


GO
PRINT N'Rename refactoring operation with key 7f57805f-235e-4db7-9006-79ae9e274bda is skipped, element [dbo].[MessageSpam].[MessageID] (SqlSimpleColumn) will not be renamed to MessageId';


GO
PRINT N'Rename refactoring operation with key 16086210-332d-47d8-bc2e-17ae75e49df1 is skipped, element [dbo].[Task].[UserID] (SqlSimpleColumn) will not be renamed to ArtistId';


GO
PRINT N'Rename refactoring operation with key 262cd966-7c8e-42c1-b30d-5bbd8b50a825 is skipped, element [dbo].[BannedEmailAddress].[Id] (SqlSimpleColumn) will not be renamed to EmailAddress';


GO
PRINT N'Rename refactoring operation with key 5e6b8a73-8453-46e3-8058-7517a9393d94 is skipped, element [dbo].[Alert].[UserId] (SqlSimpleColumn) will not be renamed to ArtistId';


GO
PRINT N'Rename refactoring operation with key e5001875-661a-4363-80f7-d4a28970f1b9 is skipped, element [dbo].[Song].[ArtistName] (SqlSimpleColumn) will not be renamed to Action';


GO
PRINT N'Rename refactoring operation with key 3c7e55c3-f2e8-4662-bb8a-10a6d16dc91c is skipped, element [dbo].[Song].[ArtistProfileUrl] (SqlSimpleColumn) will not be renamed to Controller';


GO
PRINT N'Rename refactoring operation with key 82e0cd83-865c-40ba-8dc8-bf6a71c76e99 is skipped, element [dbo].[Song].[Genre] (SqlSimpleColumn) will not be renamed to GenreId';


GO
PRINT N'Rename refactoring operation with key 47e0ffee-3f71-4af6-972f-229f72a1ba20 is skipped, element [dbo].[UserSkill].[UserID] (SqlSimpleColumn) will not be renamed to ArtistId';


GO
PRINT N'Rename refactoring operation with key 01b80c6c-63e9-4efe-9f52-84fb893feeea is skipped, element [dbo].[SongComment].[Id] (SqlSimpleColumn) will not be renamed to SongCommentId';


GO
PRINT N'Rename refactoring operation with key fee81d5e-a3e9-4142-b316-6c140c01949a is skipped, element [dbo].[CollaborationSpaceGenre].[Id] (SqlSimpleColumn) will not be renamed to CollaborationSpaceGenreId';


GO
PRINT N'Rename refactoring operation with key 88152d09-e864-4d5a-a12a-1564d8fd26ba is skipped, element [dbo].[CollaborationSpaceInvite].[SenderId] (SqlSimpleColumn) will not be renamed to ArtistId';


GO
PRINT N'Rename refactoring operation with key 4741fea1-74a7-4723-b3ea-11271d358849 is skipped, element [dbo].[CollaborationSpaceInvite].[DateSent] (SqlSimpleColumn) will not be renamed to CreateDate';


GO
PRINT N'Rename refactoring operation with key 7c565b39-3712-4c23-a02d-2e181c016eb5 is skipped, element [dbo].[CollaborationSpaceInvite].[LinkHash] (SqlSimpleColumn) will not be renamed to LinkIdentifier';


GO
PRINT N'Rename refactoring operation with key c303d19c-fa9d-46ab-8b30-a2fa3124410e is skipped, element [dbo].[BandAudition].[PublishedMediaId] (SqlSimpleColumn) will not be renamed to SongId';


GO
PRINT N'Dropping FK_CollaborationSpaceGenre_CollaborationSpace...';


GO
ALTER TABLE [dbo].[CollaborationSpaceGenre] DROP CONSTRAINT [FK_CollaborationSpaceGenre_CollaborationSpace];


GO
PRINT N'Dropping FK_CollaborationSpaceGenre_GenreLookUp...';


GO
ALTER TABLE [dbo].[CollaborationSpaceGenre] DROP CONSTRAINT [FK_CollaborationSpaceGenre_GenreLookUp];


GO
PRINT N'Starting rebuilding table [dbo].[CollaborationSpaceGenre]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_CollaborationSpaceGenre] (
    [CollaborationSpaceGenreId] INT IDENTITY (1, 1) NOT NULL,
    [CollaborationSpaceId]      INT NOT NULL,
    [GenreLookUpId]             INT NOT NULL,
    PRIMARY KEY CLUSTERED ([CollaborationSpaceGenreId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[CollaborationSpaceGenre])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_CollaborationSpaceGenre] ON;
        INSERT INTO [dbo].[tmp_ms_xx_CollaborationSpaceGenre] ([CollaborationSpaceGenreId], [CollaborationSpaceId], [GenreLookUpId])
        SELECT   [CollaborationSpaceGenreId],
                 [CollaborationSpaceId],
                 [GenreLookUpId]
        FROM     [dbo].[CollaborationSpaceGenre]
        ORDER BY [CollaborationSpaceGenreId] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_CollaborationSpaceGenre] OFF;
    END

DROP TABLE [dbo].[CollaborationSpaceGenre];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_CollaborationSpaceGenre]', N'CollaborationSpaceGenre';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating FK_CollaborationSpaceGenre_CollaborationSpace...';


GO
ALTER TABLE [dbo].[CollaborationSpaceGenre] WITH NOCHECK
    ADD CONSTRAINT [FK_CollaborationSpaceGenre_CollaborationSpace] FOREIGN KEY ([CollaborationSpaceId]) REFERENCES [dbo].[CollaborationSpace] ([CollaborationSpaceId]);


GO
PRINT N'Creating FK_CollaborationSpaceGenre_GenreLookUp...';


GO
ALTER TABLE [dbo].[CollaborationSpaceGenre] WITH NOCHECK
    ADD CONSTRAINT [FK_CollaborationSpaceGenre_GenreLookUp] FOREIGN KEY ([GenreLookUpId]) REFERENCES [dbo].[GenreLookUp] ([GenreLookUpId]);


GO
-- Refactoring step to update target server with deployed transaction logs
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'e3ad0f09-0b05-4b5e-8843-78a46d0bdaa5')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('e3ad0f09-0b05-4b5e-8843-78a46d0bdaa5')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'ca67eee0-6342-4f1c-8c38-e6af1d2310a6')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('ca67eee0-6342-4f1c-8c38-e6af1d2310a6')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '63c9f6f6-0b6b-4be3-8de7-45eb8874aaae')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('63c9f6f6-0b6b-4be3-8de7-45eb8874aaae')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'e407f64e-703e-48be-b57b-4cab35971c23')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('e407f64e-703e-48be-b57b-4cab35971c23')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'c40fbeab-4359-49be-b4bf-a3f8bd4e729f')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('c40fbeab-4359-49be-b4bf-a3f8bd4e729f')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'bc518951-1857-427d-9677-49b63d25f63f')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('bc518951-1857-427d-9677-49b63d25f63f')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '7117728c-4a60-4b4b-8f00-3a597b048a1d')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('7117728c-4a60-4b4b-8f00-3a597b048a1d')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '5a6856fd-1534-48ee-8ac9-e631f48223cc')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('5a6856fd-1534-48ee-8ac9-e631f48223cc')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'aa02e475-9662-4c90-be67-70f7a4dbd4e2')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('aa02e475-9662-4c90-be67-70f7a4dbd4e2')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '39c736f6-acf1-423e-95b8-7ab463660af9')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('39c736f6-acf1-423e-95b8-7ab463660af9')
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
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '5f8015a3-ca17-4dc6-befd-a35526b5e724')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('5f8015a3-ca17-4dc6-befd-a35526b5e724')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '3a1fe86d-092e-4eed-82f8-c3e3a2fd9217')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('3a1fe86d-092e-4eed-82f8-c3e3a2fd9217')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '7cf8a7ad-3fc5-4421-aa3d-a5792cc34485')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('7cf8a7ad-3fc5-4421-aa3d-a5792cc34485')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '1ae508c9-a3db-4d1d-9a7a-6a1b7c663db9')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('1ae508c9-a3db-4d1d-9a7a-6a1b7c663db9')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '294109f5-3078-4744-b610-68de6acbe1db')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('294109f5-3078-4744-b610-68de6acbe1db')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'c5a0a597-f99a-46fa-999f-107634f35634')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('c5a0a597-f99a-46fa-999f-107634f35634')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '7f57805f-235e-4db7-9006-79ae9e274bda')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('7f57805f-235e-4db7-9006-79ae9e274bda')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '16086210-332d-47d8-bc2e-17ae75e49df1')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('16086210-332d-47d8-bc2e-17ae75e49df1')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '262cd966-7c8e-42c1-b30d-5bbd8b50a825')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('262cd966-7c8e-42c1-b30d-5bbd8b50a825')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '5e6b8a73-8453-46e3-8058-7517a9393d94')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('5e6b8a73-8453-46e3-8058-7517a9393d94')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'e5001875-661a-4363-80f7-d4a28970f1b9')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('e5001875-661a-4363-80f7-d4a28970f1b9')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '3c7e55c3-f2e8-4662-bb8a-10a6d16dc91c')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('3c7e55c3-f2e8-4662-bb8a-10a6d16dc91c')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '82e0cd83-865c-40ba-8dc8-bf6a71c76e99')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('82e0cd83-865c-40ba-8dc8-bf6a71c76e99')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '47e0ffee-3f71-4af6-972f-229f72a1ba20')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('47e0ffee-3f71-4af6-972f-229f72a1ba20')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '01b80c6c-63e9-4efe-9f52-84fb893feeea')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('01b80c6c-63e9-4efe-9f52-84fb893feeea')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'fee81d5e-a3e9-4142-b316-6c140c01949a')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('fee81d5e-a3e9-4142-b316-6c140c01949a')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '88152d09-e864-4d5a-a12a-1564d8fd26ba')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('88152d09-e864-4d5a-a12a-1564d8fd26ba')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '4741fea1-74a7-4723-b3ea-11271d358849')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('4741fea1-74a7-4723-b3ea-11271d358849')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '7c565b39-3712-4c23-a02d-2e181c016eb5')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('7c565b39-3712-4c23-a02d-2e181c016eb5')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'c303d19c-fa9d-46ab-8b30-a2fa3124410e')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('c303d19c-fa9d-46ab-8b30-a2fa3124410e')

GO

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[CollaborationSpaceGenre] WITH CHECK CHECK CONSTRAINT [FK_CollaborationSpaceGenre_CollaborationSpace];

ALTER TABLE [dbo].[CollaborationSpaceGenre] WITH CHECK CHECK CONSTRAINT [FK_CollaborationSpaceGenre_GenreLookUp];


GO
PRINT N'Update complete.'
GO
