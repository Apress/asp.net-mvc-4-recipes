CREATE TABLE [dbo].[EmailVerification]
(
	[EmailVerificationId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ArtistId] [int] NOT NULL,
	[emailaddress] [varchar](150) NOT NULL,
	[VerificationCode] [varchar](50) NOT NULL,
	[NotificationSendDate] [datetime] NOT NULL,
	[VerificationDate] [datetime] NULL,
)
