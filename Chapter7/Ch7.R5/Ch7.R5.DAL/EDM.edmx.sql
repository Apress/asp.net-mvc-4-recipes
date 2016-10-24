
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 09/21/2012 01:49:31
-- Generated from EDMX file: G:\WorkingFolder\MVCBook\Chapter7\Ch7.R5\Ch7.R5.DAL\EDM.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [NewDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Artists'
CREATE TABLE [dbo].[Artists] (
    [ArtistId] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(256)  NOT NULL,
    [Country] nvarchar(50)  NOT NULL,
    [Provence] nvarchar(65)  NULL,
    [City] nvarchar(50)  NULL,
    [CreateDate] datetime  NOT NULL
);
GO

-- Creating table 'ArtistSkills'
CREATE TABLE [dbo].[ArtistSkills] (
    [ArtistSkillId] int IDENTITY(1,1) NOT NULL,
    [TalentName] nvarchar(50)  NOT NULL,
    [SkillLevel] int  NOT NULL,
    [Details] nvarchar(500)  NULL,
    [Styles] nvarchar(500)  NOT NULL,
    [Artist_ArtistId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ArtistId] in table 'Artists'
ALTER TABLE [dbo].[Artists]
ADD CONSTRAINT [PK_Artists]
    PRIMARY KEY CLUSTERED ([ArtistId] ASC);
GO

-- Creating primary key on [ArtistSkillId] in table 'ArtistSkills'
ALTER TABLE [dbo].[ArtistSkills]
ADD CONSTRAINT [PK_ArtistSkills]
    PRIMARY KEY CLUSTERED ([ArtistSkillId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Artist_ArtistId] in table 'ArtistSkills'
ALTER TABLE [dbo].[ArtistSkills]
ADD CONSTRAINT [FK_ArtistArtistSkill]
    FOREIGN KEY ([Artist_ArtistId])
    REFERENCES [dbo].[Artists]
        ([ArtistId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ArtistArtistSkill'
CREATE INDEX [IX_FK_ArtistArtistSkill]
ON [dbo].[ArtistSkills]
    ([Artist_ArtistId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------