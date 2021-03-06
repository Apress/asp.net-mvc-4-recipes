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
/*
The column [dbo].[Artist].[ArtistId] on table [dbo].[Artist] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue you must either: add a default value to the column, mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The type for column UserId in table [dbo].[Artist] is currently  INT NOT NULL but is being changed to  UNIQUEIDENTIFIER NOT NULL. There is no implicit or explicit conversion.
*/

IF EXISTS (select top 1 1 from [dbo].[Artist])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Rename refactoring operation with key 63c9f6f6-0b6b-4be3-8de7-45eb8874aaae is skipped, element [dbo].[CollaborationSpace].[Id] (SqlSimpleColumn) will not be renamed to CollaborationSpaceId';


GO
PRINT N'Rename refactoring operation with key e407f64e-703e-48be-b57b-4cab35971c23 is skipped, element [dbo].[CollaborationSpace].[RestrictContributersToBand] (SqlSimpleColumn) will not be renamed to RestrictContributorsToBand';


GO
PRINT N'Rename refactoring operation with key c40fbeab-4359-49be-b4bf-a3f8bd4e729f is skipped, element [dbo].[ArtistCollaborationSpaces].[Id] (SqlSimpleColumn) will not be renamed to ArtistCollaborationSpaceId';


GO
PRINT N'Rename refactoring operation with key bc518951-1857-427d-9677-49b63d25f63f is skipped, element [dbo].[Artist].[UserId] (SqlSimpleColumn) will not be renamed to ArtistId';


GO
PRINT N'Rename refactoring operation with key 7117728c-4a60-4b4b-8f00-3a597b048a1d is skipped, element [dbo].[Band].[Id] (SqlSimpleColumn) will not be renamed to BandId';


GO
PRINT N'Dropping DF__tmp_ms_xx__Profi__1920BF5C...';


GO
ALTER TABLE [dbo].[Artist] DROP CONSTRAINT [DF__tmp_ms_xx__Profi__1920BF5C];


GO
PRINT N'Dropping DF__tmp_ms_xx__Profi__1A14E395...';


GO
ALTER TABLE [dbo].[Artist] DROP CONSTRAINT [DF__tmp_ms_xx__Profi__1A14E395];


GO
PRINT N'Dropping DF__tmp_ms_xx__Conta__1B0907CE...';


GO
ALTER TABLE [dbo].[Artist] DROP CONSTRAINT [DF__tmp_ms_xx__Conta__1B0907CE];


GO
PRINT N'Dropping DF__tmp_ms_xx__Profi__1BFD2C07...';


GO
ALTER TABLE [dbo].[Artist] DROP CONSTRAINT [DF__tmp_ms_xx__Profi__1BFD2C07];


GO
PRINT N'Dropping DF__tmp_ms_xx__Ratin__1CF15040...';


GO
ALTER TABLE [dbo].[Artist] DROP CONSTRAINT [DF__tmp_ms_xx__Ratin__1CF15040];


GO
PRINT N'Starting rebuilding table [dbo].[Artist]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Artist] (
    [ArtistId]            INT              NOT NULL,
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
        
        INSERT INTO [dbo].[tmp_ms_xx_Artist] ([UserId], [ArtistDisplayName], [Bio], [MusicalInfluences], [Country], [Provence], [City], [ProfileCreateDate], [WebSite], [ProfilePrivacyLevel], [ContactPrivacyLevel], [ProfileViews], [ProfileLastViewDate], [Rating])
        SELECT [UserId],
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
        FROM   [dbo].[Artist];
        
    END

DROP TABLE [dbo].[Artist];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Artist]', N'Artist';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating [dbo].[ArtistCollaborationSpaces]...';


GO
CREATE TABLE [dbo].[ArtistCollaborationSpaces] (
    [ArtistCollaborationSpaceId] INT      NOT NULL,
    [ArtistId]                   INT      NOT NULL,
    [CollaborationSpaceId]       INT      NOT NULL,
    [IsCreator]                  BIT      NOT NULL,
    [FirstContributionDate]      DATETIME NOT NULL,
    [LastContributionDate]       DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([ArtistCollaborationSpaceId] ASC)
);


GO
PRINT N'Creating [dbo].[Band]...';


GO
CREATE TABLE [dbo].[Band] (
    [BandId]                 INT           NOT NULL,
    [BandName]               VARCHAR (50)  NOT NULL,
    [BandBio]                VARCHAR (500) NULL,
    [BandLogoUrl]            VARCHAR (100) NULL,
    [BandBackgroundImageUrl] VARCHAR (100) NULL,
    [BandDisplayPhotoUrl]    VARCHAR (100) NULL,
    [CreateDate]             DATETIME      NULL,
    [ModifiedDate]           DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([BandId] ASC)
);


GO
PRINT N'Creating [dbo].[CollaborationSpace]...';


GO
CREATE TABLE [dbo].[CollaborationSpace] (
    [CollaborationSpaceId]       INT              NOT NULL,
    [Title]                      VARCHAR (100)    NOT NULL,
    [Description]                VARCHAR (500)    NOT NULL,
    [RestrictContributorsToBand] BIT              NOT NULL,
    [BandId]                     INT              NULL,
    [AllowPublicView]            BIT              NOT NULL,
    [CopyrightModel]             TINYINT          NOT NULL,
    [CreatedBy]                  UNIQUEIDENTIFIER NOT NULL,
    [AllowContributorsToPublish] BIT              NOT NULL,
    [CreateDate]                 DATETIME         NOT NULL,
    [ModifiedDate]               DATETIME         NOT NULL,
    [LastPostDate]               DATETIME         NULL,
    [PublishedDate]              DATETIME         NULL,
    [NumberViews]                INT              NOT NULL,
    [NumberComments]             INT              NOT NULL,
    [Status]                     TINYINT          NOT NULL,
    [ConceptId]                  INT              NOT NULL,
    PRIMARY KEY CLUSTERED ([CollaborationSpaceId] ASC)
);


GO
PRINT N'Creating Default Constraint on [dbo].[ArtistCollaborationSpaces]....';


GO
ALTER TABLE [dbo].[ArtistCollaborationSpaces]
    ADD DEFAULT 0 FOR [IsCreator];


GO
PRINT N'Creating Default Constraint on [dbo].[ArtistCollaborationSpaces]....';


GO
ALTER TABLE [dbo].[ArtistCollaborationSpaces]
    ADD DEFAULT getdate() FOR [FirstContributionDate];


GO
PRINT N'Creating Default Constraint on [dbo].[ArtistCollaborationSpaces]....';


GO
ALTER TABLE [dbo].[ArtistCollaborationSpaces]
    ADD DEFAULT getdate() FOR [LastContributionDate];


GO
PRINT N'Creating Default Constraint on [dbo].[CollaborationSpace]....';


GO
ALTER TABLE [dbo].[CollaborationSpace]
    ADD DEFAULT 0 FOR [RestrictContributorsToBand];


GO
PRINT N'Creating Default Constraint on [dbo].[CollaborationSpace]....';


GO
ALTER TABLE [dbo].[CollaborationSpace]
    ADD DEFAULT 1 FOR [AllowPublicView];


GO
PRINT N'Creating Default Constraint on [dbo].[CollaborationSpace]....';


GO
ALTER TABLE [dbo].[CollaborationSpace]
    ADD DEFAULT 0 FOR [CopyrightModel];


GO
PRINT N'Creating Default Constraint on [dbo].[CollaborationSpace]....';


GO
ALTER TABLE [dbo].[CollaborationSpace]
    ADD DEFAULT 0 FOR [AllowContributorsToPublish];


GO
PRINT N'Creating Default Constraint on [dbo].[CollaborationSpace]....';


GO
ALTER TABLE [dbo].[CollaborationSpace]
    ADD DEFAULT getdate() FOR [CreateDate];


GO
PRINT N'Creating Default Constraint on [dbo].[CollaborationSpace]....';


GO
ALTER TABLE [dbo].[CollaborationSpace]
    ADD DEFAULT getdate() FOR [ModifiedDate];


GO
PRINT N'Creating Default Constraint on [dbo].[CollaborationSpace]....';


GO
ALTER TABLE [dbo].[CollaborationSpace]
    ADD DEFAULT 0 FOR [NumberViews];


GO
PRINT N'Creating Default Constraint on [dbo].[CollaborationSpace]....';


GO
ALTER TABLE [dbo].[CollaborationSpace]
    ADD DEFAULT 0 FOR [NumberComments];


GO
PRINT N'Creating Default Constraint on [dbo].[CollaborationSpace]....';


GO
ALTER TABLE [dbo].[CollaborationSpace]
    ADD DEFAULT 0 FOR [Status];


GO
PRINT N'Creating Default Constraint on [dbo].[CollaborationSpace]....';


GO
ALTER TABLE [dbo].[CollaborationSpace]
    ADD DEFAULT 0 FOR [ConceptId];


GO
PRINT N'Creating FK_ArtistCollaborationSpaces_ToTable...';


GO
ALTER TABLE [dbo].[ArtistCollaborationSpaces] WITH NOCHECK
    ADD CONSTRAINT [FK_ArtistCollaborationSpaces_ToTable] FOREIGN KEY ([ArtistId]) REFERENCES [dbo].[Artist] ([ArtistId]);


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
-- Refactoring step to update target server with deployed transaction logs
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

GO

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[ArtistCollaborationSpaces] WITH CHECK CHECK CONSTRAINT [FK_ArtistCollaborationSpaces_ToTable];

ALTER TABLE [dbo].[ArtistCollaborationSpaces] WITH CHECK CHECK CONSTRAINT [FK_ArtistCollaborationSpaces_ToTable_1];

ALTER TABLE [dbo].[CollaborationSpace] WITH CHECK CHECK CONSTRAINT [FK_CollaborationSpace_ToTable];


GO
PRINT N'Update complete.'
GO
