
CREATE TABLE [dbo].[ArtistSkill](
	[ArtistTalentID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED,
	[ArtistId] INT NOT NULL,
	[TalentName] [varchar](50) NOT NULL,
	[SkillLevel] [int] NOT NULL DEFAULT 3,
	[Details] varchar(500) NULL,
	[Styles] varchar(500) NOT NULL, 
    CONSTRAINT [FK_ArtistSkill_Artist] FOREIGN KEY ([ArtistId]) REFERENCES [Artist]([ArtistId])
)

