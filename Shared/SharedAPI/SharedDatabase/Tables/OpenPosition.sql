CREATE TABLE [dbo].[OpenPosition]
(
	[OpenPositionId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[CollaborationSpaceId] [int] NULL,
	[Talent] [varchar](50) NOT NULL,
	[SkillLevel] [int] NOT NULL DEFAULT 0,
	[Details] [varchar](1000) NULL,
	[DatePosted] [datetime] NOT NULL DEFAULT getdate(),
	[DateModified] [datetime] NOT NULL DEFAULT getdate(),
	[Status] [int] NOT NULL DEFAULT 0,
	[BandId] [int] NULL,
	[LocalOnly] [bit] NOT NULL DEFAULT 0,
	[LocalCity] [varchar](50) NULL,
	[LocalCountry] [varchar](50) NULL,
	[LocalProvence] [varchar](50) NULL,
	[AuditionsSubmitted] [int] NOT NULL DEFAULT 0,
	[ApprovalMode] [int] NOT NULL DEFAULT 0,
)
