CREATE TABLE [dbo].[GenreLookUp]
(
	[GenreLookUpId] INT NOT NULL IDENTITY PRIMARY KEY,
	GenreName NVarchar(50) NOT NULL, 
    [Culture] NVARCHAR(4) NULL DEFAULT 'en'
)
