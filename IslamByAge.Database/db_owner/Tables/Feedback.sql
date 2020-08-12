﻿CREATE TABLE [dbo].[Feedback]
(
	[Id] INT IDENTITY (1, 1)  NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(250) NULL, 
    [Email] VARCHAR(250) NULL, 
    [Message] VARCHAR(MAX) NULL,
    [CreatedOn]   DATETIME2 (7)  DEFAULT ('0001-01-01T00:00:00.0000000') NOT NULL,
)
