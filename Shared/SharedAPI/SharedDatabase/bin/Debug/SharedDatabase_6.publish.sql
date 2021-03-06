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
PRINT N'Dropping FK_Media_ToTable...';


GO
ALTER TABLE [dbo].[Media] DROP CONSTRAINT [FK_Media_ToTable];


GO
PRINT N'Altering [dbo].[Media]...';


GO
ALTER TABLE [dbo].[Media] ALTER COLUMN [ArtistId] INT NULL;


GO
ALTER TABLE [dbo].[Media]
    ADD [IsDeleted] BIT DEFAULT 0 NOT NULL;


GO
PRINT N'Creating FK_Media_ToTable...';


GO
ALTER TABLE [dbo].[Media] WITH NOCHECK
    ADD CONSTRAINT [FK_Media_ToTable] FOREIGN KEY ([ArtistId]) REFERENCES [dbo].[Artist] ([ArtistId]);


GO
PRINT N'Creating [dbo].[u_DeleteArtist]...';


GO
CREATE PROCEDURE [dbo].[u_DeleteArtist]
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
 


 

 set nocount off
 end
GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Media] WITH CHECK CHECK CONSTRAINT [FK_Media_ToTable];


GO
PRINT N'Update complete.'
GO
