﻿CREATE TABLE [dbo].[Quiz]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Category] NVARCHAR(128) NOT NULL, 
    [Question] NVARCHAR(MAX) NOT NULL, 
    [Answer1] NVARCHAR(MAX) NOT NULL, 
    [Answer2] NVARCHAR(MAX) NOT NULL, 
    [Answer3] NVARCHAR(MAX) NOT NULL, 
    [Answer4] NVARCHAR(MAX) NOT NULL
)
