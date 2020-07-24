CREATE TABLE [db_owner].[Categories] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Title]     NVARCHAR (MAX) NULL,
    [Image]     NVARCHAR (MAX) NULL,
    [Status]    INT            NOT NULL,
    [CreatedBy] NVARCHAR (MAX) NULL,
    [CreatedOn] DATETIME2 (7)  DEFAULT ('0001-01-01T00:00:00.0000000') NOT NULL,
    [DeletedBy] NVARCHAR (MAX) NULL,
    [DeletedOn] DATETIME2 (7)  NULL,
    [UpdatedBy] NVARCHAR (MAX) NULL,
    [UpdatedOn] DATETIME2 (7)  NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([Id] ASC)
);

