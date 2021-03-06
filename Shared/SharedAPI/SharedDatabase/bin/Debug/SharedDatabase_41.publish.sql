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
PRINT N'Rename refactoring operation with key 01b80c6c-63e9-4efe-9f52-84fb893feeea is skipped, element [dbo].[SongComment].[Id] (SqlSimpleColumn) will not be renamed to SongCommentId';


GO
PRINT N'Creating [dbo].[SongComment]...';


GO
CREATE TABLE [dbo].[SongComment] (
    [SongCommentId] INT            NOT NULL,
    [SongId]        INT            NULL,
    [Comment]       VARCHAR (1000) NULL,
    [Rating]        INT            NOT NULL,
    [CreateDate]    DATETIME       NULL,
    [IsApproved]    BIT            NOT NULL,
    [IsAnonymous]   BIT            NOT NULL,
    [Name]          VARCHAR (50)   NULL,
    [EmailAddress]  VARCHAR (150)  NULL,
    PRIMARY KEY CLUSTERED ([SongCommentId] ASC)
);


GO
PRINT N'Creating Default Constraint on [dbo].[SongComment]....';


GO
ALTER TABLE [dbo].[SongComment]
    ADD DEFAULT 3 FOR [Rating];


GO
PRINT N'Creating Default Constraint on [dbo].[SongComment]....';


GO
ALTER TABLE [dbo].[SongComment]
    ADD DEFAULT 0 FOR [IsApproved];


GO
PRINT N'Creating Default Constraint on [dbo].[SongComment]....';


GO
ALTER TABLE [dbo].[SongComment]
    ADD DEFAULT 0 FOR [IsAnonymous];


GO
-- Refactoring step to update target server with deployed transaction logs
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '01b80c6c-63e9-4efe-9f52-84fb893feeea')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('01b80c6c-63e9-4efe-9f52-84fb893feeea')

GO

GO
PRINT N'Update complete.'
GO
