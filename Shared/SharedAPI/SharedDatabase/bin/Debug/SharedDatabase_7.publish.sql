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
PRINT N'Dropping DF__tmp_ms_xx__Profi__1FCDBCEB...';


GO
ALTER TABLE [dbo].[Artist] DROP CONSTRAINT [DF__tmp_ms_xx__Profi__1FCDBCEB];


GO
PRINT N'Dropping DF__tmp_ms_xx__Profi__20C1E124...';


GO
ALTER TABLE [dbo].[Artist] DROP CONSTRAINT [DF__tmp_ms_xx__Profi__20C1E124];


GO
PRINT N'Dropping DF__tmp_ms_xx__Conta__21B6055D...';


GO
ALTER TABLE [dbo].[Artist] DROP CONSTRAINT [DF__tmp_ms_xx__Conta__21B6055D];


GO
PRINT N'Dropping DF__tmp_ms_xx__Profi__22AA2996...';


GO
ALTER TABLE [dbo].[Artist] DROP CONSTRAINT [DF__tmp_ms_xx__Profi__22AA2996];


GO
PRINT N'Dropping DF__tmp_ms_xx__Ratin__239E4DCF...';


GO
ALTER TABLE [dbo].[Artist] DROP CONSTRAINT [DF__tmp_ms_xx__Ratin__239E4DCF];


GO
PRINT N'Dropping DF__ArtistBan__IsAct__45F365D3...';


GO
ALTER TABLE [dbo].[ArtistBand] DROP CONSTRAINT [DF__ArtistBan__IsAct__45F365D3];


GO
PRINT N'Dropping DF__ArtistBan__Allow__46E78A0C...';


GO
ALTER TABLE [dbo].[ArtistBand] DROP CONSTRAINT [DF__ArtistBan__Allow__46E78A0C];


GO
PRINT N'Dropping DF__ArtistBan__IsMem__47DBAE45...';


GO
ALTER TABLE [dbo].[ArtistBand] DROP CONSTRAINT [DF__ArtistBan__IsMem__47DBAE45];


GO
PRINT N'Dropping DF__ArtistCol__IsCre__2A4B4B5E...';


GO
ALTER TABLE [dbo].[ArtistCollaborationSpaces] DROP CONSTRAINT [DF__ArtistCol__IsCre__2A4B4B5E];


GO
PRINT N'Dropping DF__ArtistCol__First__2B3F6F97...';


GO
ALTER TABLE [dbo].[ArtistCollaborationSpaces] DROP CONSTRAINT [DF__ArtistCol__First__2B3F6F97];


GO
PRINT N'Dropping DF__ArtistCol__LastC__2C3393D0...';


GO
ALTER TABLE [dbo].[ArtistCollaborationSpaces] DROP CONSTRAINT [DF__ArtistCol__LastC__2C3393D0];


GO
PRINT N'Dropping DF__Collabora__Restr__2D27B809...';


GO
ALTER TABLE [dbo].[CollaborationSpace] DROP CONSTRAINT [DF__Collabora__Restr__2D27B809];


GO
PRINT N'Dropping DF__Collabora__Allow__2E1BDC42...';


GO
ALTER TABLE [dbo].[CollaborationSpace] DROP CONSTRAINT [DF__Collabora__Allow__2E1BDC42];


GO
PRINT N'Dropping DF__Collabora__Copyr__2F10007B...';


GO
ALTER TABLE [dbo].[CollaborationSpace] DROP CONSTRAINT [DF__Collabora__Copyr__2F10007B];


GO
PRINT N'Dropping DF__Collabora__Allow__300424B4...';


GO
ALTER TABLE [dbo].[CollaborationSpace] DROP CONSTRAINT [DF__Collabora__Allow__300424B4];


GO
PRINT N'Dropping DF__Collabora__Creat__30F848ED...';


GO
ALTER TABLE [dbo].[CollaborationSpace] DROP CONSTRAINT [DF__Collabora__Creat__30F848ED];


GO
PRINT N'Dropping DF__Collabora__Modif__31EC6D26...';


GO
ALTER TABLE [dbo].[CollaborationSpace] DROP CONSTRAINT [DF__Collabora__Modif__31EC6D26];


GO
PRINT N'Dropping DF__Collabora__Numbe__32E0915F...';


GO
ALTER TABLE [dbo].[CollaborationSpace] DROP CONSTRAINT [DF__Collabora__Numbe__32E0915F];


GO
PRINT N'Dropping DF__Collabora__Numbe__33D4B598...';


GO
ALTER TABLE [dbo].[CollaborationSpace] DROP CONSTRAINT [DF__Collabora__Numbe__33D4B598];


GO
PRINT N'Dropping DF__Collabora__Statu__34C8D9D1...';


GO
ALTER TABLE [dbo].[CollaborationSpace] DROP CONSTRAINT [DF__Collabora__Statu__34C8D9D1];


GO
PRINT N'Dropping DF__Collabora__Conce__35BCFE0A...';


GO
ALTER TABLE [dbo].[CollaborationSpace] DROP CONSTRAINT [DF__Collabora__Conce__35BCFE0A];


GO
PRINT N'Dropping DF__Media__IsCloudBl__52593CB8...';


GO
ALTER TABLE [dbo].[Media] DROP CONSTRAINT [DF__Media__IsCloudBl__52593CB8];


GO
PRINT N'Dropping DF__Media__MediaType__534D60F1...';


GO
ALTER TABLE [dbo].[Media] DROP CONSTRAINT [DF__Media__MediaType__534D60F1];


GO
PRINT N'Dropping DF__Media__FileSizeI__5441852A...';


GO
ALTER TABLE [dbo].[Media] DROP CONSTRAINT [DF__Media__FileSizeI__5441852A];


GO
PRINT N'Dropping DF__Media__BitRateIn__5535A963...';


GO
ALTER TABLE [dbo].[Media] DROP CONSTRAINT [DF__Media__BitRateIn__5535A963];


GO
PRINT N'Dropping DF__Media__AllowDown__5629CD9C...';


GO
ALTER TABLE [dbo].[Media] DROP CONSTRAINT [DF__Media__AllowDown__5629CD9C];


GO
PRINT N'Dropping DF__Media__DownloadC__571DF1D5...';


GO
ALTER TABLE [dbo].[Media] DROP CONSTRAINT [DF__Media__DownloadC__571DF1D5];


GO
PRINT N'Dropping DF__Media__IsDeleted__60A75C0F...';


GO
ALTER TABLE [dbo].[Media] DROP CONSTRAINT [DF__Media__IsDeleted__60A75C0F];


GO
PRINT N'Dropping DF__PlayList__IsSite__5812160E...';


GO
ALTER TABLE [dbo].[PlayList] DROP CONSTRAINT [DF__PlayList__IsSite__5812160E];


GO
PRINT N'Dropping DF__PlayList__IsDefa__59063A47...';


GO
ALTER TABLE [dbo].[PlayList] DROP CONSTRAINT [DF__PlayList__IsDefa__59063A47];


GO
PRINT N'Dropping DF__PlaylistI__Displ__59FA5E80...';


GO
ALTER TABLE [dbo].[PlaylistItem] DROP CONSTRAINT [DF__PlaylistI__Displ__59FA5E80];


GO
PRINT N'Dropping FK_ArtistCollaborationSpaces_ToTable...';


GO
ALTER TABLE [dbo].[ArtistCollaborationSpaces] DROP CONSTRAINT [FK_ArtistCollaborationSpaces_ToTable];


GO
PRINT N'Dropping FK_ArtistBand_ToArtist...';


GO
ALTER TABLE [dbo].[ArtistBand] DROP CONSTRAINT [FK_ArtistBand_ToArtist];


GO
PRINT N'Dropping FK_Media_ToTable...';


GO
ALTER TABLE [dbo].[Media] DROP CONSTRAINT [FK_Media_ToTable];


GO
PRINT N'Dropping FK_PlayList_Artist...';


GO
ALTER TABLE [dbo].[PlayList] DROP CONSTRAINT [FK_PlayList_Artist];


GO
PRINT N'Dropping FK_ArtistBand_ToBand...';


GO
ALTER TABLE [dbo].[ArtistBand] DROP CONSTRAINT [FK_ArtistBand_ToBand];


GO
PRINT N'Dropping FK_ArtistCollaborationSpaces_ToTable_1...';


GO
ALTER TABLE [dbo].[ArtistCollaborationSpaces] DROP CONSTRAINT [FK_ArtistCollaborationSpaces_ToTable_1];


GO
PRINT N'Dropping FK_CollaborationSpace_ToTable...';


GO
ALTER TABLE [dbo].[CollaborationSpace] DROP CONSTRAINT [FK_CollaborationSpace_ToTable];


GO
PRINT N'Dropping FK_PlayList_Band...';


GO
ALTER TABLE [dbo].[PlayList] DROP CONSTRAINT [FK_PlayList_Band];


GO
PRINT N'Dropping FK_Song_Media...';


GO
ALTER TABLE [dbo].[Song] DROP CONSTRAINT [FK_Song_Media];


GO
PRINT N'Dropping FK_PlaylistItem_PayList...';


GO
ALTER TABLE [dbo].[PlaylistItem] DROP CONSTRAINT [FK_PlaylistItem_PayList];


GO
PRINT N'Dropping FK_PlaylistItem_Song...';


GO
ALTER TABLE [dbo].[PlaylistItem] DROP CONSTRAINT [FK_PlaylistItem_Song];


GO
PRINT N'Starting rebuilding table [dbo].[Artist]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Artist] (
    [ArtistId]            INT              IDENTITY (1, 1) NOT NULL,
    [UserId]              UNIQUEIDENTIFIER NOT NULL,
    [ArtistDisplayName]   VARCHAR (50)     NOT NULL,
    [Bio]                 VARCHAR (255)    NULL,
    [MusicalInfluences]   VARCHAR (255)    NULL,
    [Country]             VARCHAR (50)     NULL,
    [Provence]            VARCHAR (50)     NULL,
    [City]                VARCHAR (50)     NULL,
    [ProfileCreateDate]   SMALLDATETIME    DEFAULT getdate() NOT NULL,
    [WebSite]             VARCHAR (255)    NULL,
    [ProfilePrivacyLevel] TINYINT          DEFAULT 0 NOT NULL,
    [ContactPrivacyLevel] TINYINT          DEFAULT 0 NOT NULL,
    [ProfileViews]        BIGINT           DEFAULT 0 NOT NULL,
    [ProfileLastViewDate] SMALLDATETIME    NULL,
    [Rating]              TINYINT          DEFAULT 3 NULL,
    PRIMARY KEY CLUSTERED ([ArtistId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Artist])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Artist] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Artist] ([ArtistId], [UserId], [ArtistDisplayName], [Bio], [MusicalInfluences], [Country], [Provence], [City], [ProfileCreateDate], [WebSite], [ProfilePrivacyLevel], [ContactPrivacyLevel], [ProfileViews], [ProfileLastViewDate], [Rating])
        SELECT   [ArtistId],
                 [UserId],
                 [ArtistDisplayName],
                 [Bio],
                 [MusicalInfluences],
                 [Country],
                 [Provence],
                 [City],
                 [ProfileCreateDate],
                 [WebSite],
                 [ProfilePrivacyLevel],
                 [ContactPrivacyLevel],
                 [ProfileViews],
                 [ProfileLastViewDate],
                 [Rating]
        FROM     [dbo].[Artist]
        ORDER BY [ArtistId] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Artist] OFF;
    END

DROP TABLE [dbo].[Artist];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Artist]', N'Artist';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[ArtistBand]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_ArtistBand] (
    [ArtistBandId]   INT          IDENTITY (1, 1) NOT NULL,
    [ArtistId]       INT          NOT NULL,
    [BandId]         INT          NULL,
    [Role]           VARCHAR (50) NOT NULL,
    [JoinedDate]     DATETIME     NOT NULL,
    [AuditionDate]   DATETIME     NOT NULL,
    [AuditionStatus] TINYINT      NOT NULL,
    [IsActiveMember] BIT          DEFAULT 1 NOT NULL,
    [DeactivateDate] DATETIME     NULL,
    [AllowEditBand]  BIT          DEFAULT 0 NOT NULL,
    [IsMemberAdmin]  BIT          DEFAULT 0 NOT NULL,
    PRIMARY KEY CLUSTERED ([ArtistBandId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[ArtistBand])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_ArtistBand] ON;
        INSERT INTO [dbo].[tmp_ms_xx_ArtistBand] ([ArtistBandId], [ArtistId], [BandId], [Role], [JoinedDate], [AuditionDate], [AuditionStatus], [IsActiveMember], [DeactivateDate], [AllowEditBand], [IsMemberAdmin])
        SELECT   [ArtistBandId],
                 [ArtistId],
                 [BandId],
                 [Role],
                 [JoinedDate],
                 [AuditionDate],
                 [AuditionStatus],
                 [IsActiveMember],
                 [DeactivateDate],
                 [AllowEditBand],
                 [IsMemberAdmin]
        FROM     [dbo].[ArtistBand]
        ORDER BY [ArtistBandId] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_ArtistBand] OFF;
    END

DROP TABLE [dbo].[ArtistBand];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_ArtistBand]', N'ArtistBand';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[ArtistCollaborationSpaces]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_ArtistCollaborationSpaces] (
    [ArtistCollaborationSpaceId] INT      IDENTITY (1, 1) NOT NULL,
    [ArtistId]                   INT      NOT NULL,
    [CollaborationSpaceId]       INT      NOT NULL,
    [IsCreator]                  BIT      DEFAULT 0 NOT NULL,
    [FirstContributionDate]      DATETIME DEFAULT getdate() NOT NULL,
    [LastContributionDate]       DATETIME DEFAULT getdate() NOT NULL,
    PRIMARY KEY CLUSTERED ([ArtistCollaborationSpaceId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[ArtistCollaborationSpaces])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_ArtistCollaborationSpaces] ON;
        INSERT INTO [dbo].[tmp_ms_xx_ArtistCollaborationSpaces] ([ArtistCollaborationSpaceId], [ArtistId], [CollaborationSpaceId], [IsCreator], [FirstContributionDate], [LastContributionDate])
        SELECT   [ArtistCollaborationSpaceId],
                 [ArtistId],
                 [CollaborationSpaceId],
                 [IsCreator],
                 [FirstContributionDate],
                 [LastContributionDate]
        FROM     [dbo].[ArtistCollaborationSpaces]
        ORDER BY [ArtistCollaborationSpaceId] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_ArtistCollaborationSpaces] OFF;
    END

DROP TABLE [dbo].[ArtistCollaborationSpaces];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_ArtistCollaborationSpaces]', N'ArtistCollaborationSpaces';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[Band]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Band] (
    [BandId]                 INT           IDENTITY (1, 1) NOT NULL,
    [BandName]               VARCHAR (50)  NOT NULL,
    [BandBio]                VARCHAR (500) NULL,
    [BandLogoUrl]            VARCHAR (100) NULL,
    [BandBackgroundImageUrl] VARCHAR (100) NULL,
    [BandDisplayPhotoUrl]    VARCHAR (100) NULL,
    [CreateDate]             DATETIME      NULL,
    [ModifiedDate]           DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([BandId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Band])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Band] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Band] ([BandId], [BandName], [BandBio], [BandLogoUrl], [BandBackgroundImageUrl], [BandDisplayPhotoUrl], [CreateDate], [ModifiedDate])
        SELECT   [BandId],
                 [BandName],
                 [BandBio],
                 [BandLogoUrl],
                 [BandBackgroundImageUrl],
                 [BandDisplayPhotoUrl],
                 [CreateDate],
                 [ModifiedDate]
        FROM     [dbo].[Band]
        ORDER BY [BandId] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Band] OFF;
    END

DROP TABLE [dbo].[Band];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Band]', N'Band';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[CollaborationSpace]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_CollaborationSpace] (
    [CollaborationSpaceId]       INT              IDENTITY (1, 1) NOT NULL,
    [Title]                      VARCHAR (100)    NOT NULL,
    [Description]                VARCHAR (500)    NOT NULL,
    [RestrictContributorsToBand] BIT              DEFAULT 0 NOT NULL,
    [BandId]                     INT              NULL,
    [AllowPublicView]            BIT              DEFAULT 1 NOT NULL,
    [CopyrightModel]             TINYINT          DEFAULT 0 NOT NULL,
    [CreatedBy]                  UNIQUEIDENTIFIER NOT NULL,
    [AllowContributorsToPublish] BIT              DEFAULT 0 NOT NULL,
    [CreateDate]                 DATETIME         DEFAULT getdate() NOT NULL,
    [ModifiedDate]               DATETIME         DEFAULT getdate() NOT NULL,
    [LastPostDate]               DATETIME         NULL,
    [PublishedDate]              DATETIME         NULL,
    [NumberViews]                INT              DEFAULT 0 NOT NULL,
    [NumberComments]             INT              DEFAULT 0 NOT NULL,
    [Status]                     TINYINT          DEFAULT 0 NOT NULL,
    [ConceptId]                  INT              DEFAULT 0 NOT NULL,
    PRIMARY KEY CLUSTERED ([CollaborationSpaceId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[CollaborationSpace])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_CollaborationSpace] ON;
        INSERT INTO [dbo].[tmp_ms_xx_CollaborationSpace] ([CollaborationSpaceId], [Title], [Description], [RestrictContributorsToBand], [BandId], [AllowPublicView], [CopyrightModel], [CreatedBy], [AllowContributorsToPublish], [CreateDate], [ModifiedDate], [LastPostDate], [PublishedDate], [NumberViews], [NumberComments], [Status], [ConceptId])
        SELECT   [CollaborationSpaceId],
                 [Title],
                 [Description],
                 [RestrictContributorsToBand],
                 [BandId],
                 [AllowPublicView],
                 [CopyrightModel],
                 [CreatedBy],
                 [AllowContributorsToPublish],
                 [CreateDate],
                 [ModifiedDate],
                 [LastPostDate],
                 [PublishedDate],
                 [NumberViews],
                 [NumberComments],
                 [Status],
                 [ConceptId]
        FROM     [dbo].[CollaborationSpace]
        ORDER BY [CollaborationSpaceId] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_CollaborationSpace] OFF;
    END

DROP TABLE [dbo].[CollaborationSpace];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_CollaborationSpace]', N'CollaborationSpace';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[Media]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Media] (
    [MediaId]                INT           IDENTITY (1, 1) NOT NULL,
    [ArtistId]               INT           NULL,
    [FriendlyFileName]       VARCHAR (50)  NOT NULL,
    [FileExtention]          VARCHAR (5)   NOT NULL,
    [LocalFilePath]          VARCHAR (255) NULL,
    [WebURL]                 VARCHAR (255) NULL,
    [IsCloudBlob]            BIT           DEFAULT 0 NOT NULL,
    [AzureStorageContainer]  VARCHAR (50)  NULL,
    [AzureBlobReferenceName] VARCHAR (50)  NULL,
    [MediaType]              TINYINT       DEFAULT 0 NOT NULL,
    [FileSizeInBytes]        INT           DEFAULT 0 NOT NULL,
    [BitRateInKbps]          INT           DEFAULT 0 NOT NULL,
    [AllowDownload]          INT           DEFAULT 0 NOT NULL,
    [DownloadCount]          INT           DEFAULT 0 NOT NULL,
    [IsDeleted]              BIT           DEFAULT 0 NOT NULL,
    PRIMARY KEY CLUSTERED ([MediaId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Media])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Media] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Media] ([MediaId], [ArtistId], [FriendlyFileName], [FileExtention], [LocalFilePath], [WebURL], [IsCloudBlob], [AzureStorageContainer], [AzureBlobReferenceName], [MediaType], [FileSizeInBytes], [BitRateInKbps], [AllowDownload], [DownloadCount], [IsDeleted])
        SELECT   [MediaId],
                 [ArtistId],
                 [FriendlyFileName],
                 [FileExtention],
                 [LocalFilePath],
                 [WebURL],
                 [IsCloudBlob],
                 [AzureStorageContainer],
                 [AzureBlobReferenceName],
                 [MediaType],
                 [FileSizeInBytes],
                 [BitRateInKbps],
                 [AllowDownload],
                 [DownloadCount],
                 [IsDeleted]
        FROM     [dbo].[Media]
        ORDER BY [MediaId] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Media] OFF;
    END

DROP TABLE [dbo].[Media];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Media]', N'Media';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[PlayList]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_PlayList] (
    [PlaylistId]        INT          IDENTITY (1, 1) NOT NULL,
    [Title]             VARCHAR (50) NULL,
    [ArtistId]          INT          NULL,
    [BandId]            INT          NULL,
    [IsSitePlaylist]    BIT          DEFAULT 0 NOT NULL,
    [IsDefaultPlaylist] BIT          DEFAULT 0 NOT NULL,
    PRIMARY KEY CLUSTERED ([PlaylistId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[PlayList])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_PlayList] ON;
        INSERT INTO [dbo].[tmp_ms_xx_PlayList] ([PlaylistId], [Title], [ArtistId], [BandId], [IsSitePlaylist], [IsDefaultPlaylist])
        SELECT   [PlaylistId],
                 [Title],
                 [ArtistId],
                 [BandId],
                 [IsSitePlaylist],
                 [IsDefaultPlaylist]
        FROM     [dbo].[PlayList]
        ORDER BY [PlaylistId] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_PlayList] OFF;
    END

DROP TABLE [dbo].[PlayList];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_PlayList]', N'PlayList';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[PlaylistItem]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_PlaylistItem] (
    [PlaylistItemId] INT IDENTITY (1, 1) NOT NULL,
    [PlayListId]     INT NOT NULL,
    [SongId]         INT NOT NULL,
    [DisplayOrder]   INT DEFAULT 0 NOT NULL,
    PRIMARY KEY CLUSTERED ([PlaylistItemId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[PlaylistItem])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_PlaylistItem] ON;
        INSERT INTO [dbo].[tmp_ms_xx_PlaylistItem] ([PlaylistItemId], [PlayListId], [SongId], [DisplayOrder])
        SELECT   [PlaylistItemId],
                 [PlayListId],
                 [SongId],
                 [DisplayOrder]
        FROM     [dbo].[PlaylistItem]
        ORDER BY [PlaylistItemId] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_PlaylistItem] OFF;
    END

DROP TABLE [dbo].[PlaylistItem];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_PlaylistItem]', N'PlaylistItem';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[Song]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Song] (
    [SongId]           INT            IDENTITY (1, 1) NOT NULL,
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

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Song])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Song] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Song] ([SongId], [MediaId], [SongTitle], [ReleaseYear], [ArtworkURL], [ArtworkThumbURL], [Lyrics], [SongDescription], [ArtistName], [ArtistProfileUrl], [Genre])
        SELECT   [SongId],
                 [MediaId],
                 [SongTitle],
                 [ReleaseYear],
                 [ArtworkURL],
                 [ArtworkThumbURL],
                 [Lyrics],
                 [SongDescription],
                 [ArtistName],
                 [ArtistProfileUrl],
                 [Genre]
        FROM     [dbo].[Song]
        ORDER BY [SongId] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Song] OFF;
    END

DROP TABLE [dbo].[Song];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Song]', N'Song';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating FK_ArtistCollaborationSpaces_ToTable...';


GO
ALTER TABLE [dbo].[ArtistCollaborationSpaces] WITH NOCHECK
    ADD CONSTRAINT [FK_ArtistCollaborationSpaces_ToTable] FOREIGN KEY ([ArtistId]) REFERENCES [dbo].[Artist] ([ArtistId]);


GO
PRINT N'Creating FK_ArtistBand_ToArtist...';


GO
ALTER TABLE [dbo].[ArtistBand] WITH NOCHECK
    ADD CONSTRAINT [FK_ArtistBand_ToArtist] FOREIGN KEY ([ArtistId]) REFERENCES [dbo].[Artist] ([ArtistId]);


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
PRINT N'Creating FK_ArtistBand_ToBand...';


GO
ALTER TABLE [dbo].[ArtistBand] WITH NOCHECK
    ADD CONSTRAINT [FK_ArtistBand_ToBand] FOREIGN KEY ([BandId]) REFERENCES [dbo].[Band] ([BandId]);


GO
PRINT N'Creating FK_ArtistCollaborationSpaces_ToTable_1...';


GO
ALTER TABLE [dbo].[ArtistCollaborationSpaces] WITH NOCHECK
    ADD CONSTRAINT [FK_ArtistCollaborationSpaces_ToTable_1] FOREIGN KEY ([CollaborationSpaceId]) REFERENCES [dbo].[CollaborationSpace] ([CollaborationSpaceId]);


GO
PRINT N'Creating FK_CollaborationSpace_ToTable...';


GO
ALTER TABLE [dbo].[CollaborationSpace] WITH NOCHECK
    ADD CONSTRAINT [FK_CollaborationSpace_ToTable] FOREIGN KEY ([BandId]) REFERENCES [dbo].[Band] ([BandId]);


GO
PRINT N'Creating FK_PlayList_Band...';


GO
ALTER TABLE [dbo].[PlayList] WITH NOCHECK
    ADD CONSTRAINT [FK_PlayList_Band] FOREIGN KEY ([BandId]) REFERENCES [dbo].[Band] ([BandId]);


GO
PRINT N'Creating FK_Song_Media...';


GO
ALTER TABLE [dbo].[Song] WITH NOCHECK
    ADD CONSTRAINT [FK_Song_Media] FOREIGN KEY ([MediaId]) REFERENCES [dbo].[Media] ([MediaId]);


GO
PRINT N'Creating FK_PlaylistItem_PayList...';


GO
ALTER TABLE [dbo].[PlaylistItem] WITH NOCHECK
    ADD CONSTRAINT [FK_PlaylistItem_PayList] FOREIGN KEY ([PlayListId]) REFERENCES [dbo].[PlayList] ([PlaylistId]);


GO
PRINT N'Creating FK_PlaylistItem_Song...';


GO
ALTER TABLE [dbo].[PlaylistItem] WITH NOCHECK
    ADD CONSTRAINT [FK_PlaylistItem_Song] FOREIGN KEY ([SongId]) REFERENCES [dbo].[Song] ([SongId]);


GO
PRINT N'Altering [dbo].[u_DeleteArtist]...';


GO
ALTER PROCEDURE [dbo].[u_DeleteArtist]
	@ArtistId int = 0
AS
 begin
 set nocount on
 
 --mark media items owned by this user as deleted
 update media
 set ArtistId=null,
 IsDeleted=1
 where ArtistId = @ArtistId

 -- delete all songs
 delete from Song
 where SongId in (
 select songId from PlaylistItem  
 inner join PlayList 
 on (PlayList.PlaylistId = PlaylistItem.PlayListId)
 where PlayList.artistid = @ArtistId)

 delete from PlayListItem 
 where PlayListId in (select PlaylistId from PlayList where ArtistId = @ArtistId)


 delete from  PlayList where ArtistId = @ArtistId


 delete from ArtistCollaborationSpaces where artistId = @ArtistId
 delete from ArtistBand where artistid = @ArtistId
 
 -- remove any orphaned bands
 delete b
 from  Band b
  left join ArtistBand ab
 ON ab.BandId =  b.BandId
 where ab.BandId IS NULL

 

 set nocount off
 end
GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[ArtistCollaborationSpaces] WITH CHECK CHECK CONSTRAINT [FK_ArtistCollaborationSpaces_ToTable];

ALTER TABLE [dbo].[ArtistBand] WITH CHECK CHECK CONSTRAINT [FK_ArtistBand_ToArtist];

ALTER TABLE [dbo].[Media] WITH CHECK CHECK CONSTRAINT [FK_Media_ToTable];

ALTER TABLE [dbo].[PlayList] WITH CHECK CHECK CONSTRAINT [FK_PlayList_Artist];

ALTER TABLE [dbo].[ArtistBand] WITH CHECK CHECK CONSTRAINT [FK_ArtistBand_ToBand];

ALTER TABLE [dbo].[ArtistCollaborationSpaces] WITH CHECK CHECK CONSTRAINT [FK_ArtistCollaborationSpaces_ToTable_1];

ALTER TABLE [dbo].[CollaborationSpace] WITH CHECK CHECK CONSTRAINT [FK_CollaborationSpace_ToTable];

ALTER TABLE [dbo].[PlayList] WITH CHECK CHECK CONSTRAINT [FK_PlayList_Band];

ALTER TABLE [dbo].[Song] WITH CHECK CHECK CONSTRAINT [FK_Song_Media];

ALTER TABLE [dbo].[PlaylistItem] WITH CHECK CHECK CONSTRAINT [FK_PlaylistItem_PayList];

ALTER TABLE [dbo].[PlaylistItem] WITH CHECK CHECK CONSTRAINT [FK_PlaylistItem_Song];


GO
PRINT N'Update complete.'
GO
