CREATE TABLE [db_owner].[Topics] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (MAX) NULL,
    [Description] NVARCHAR (MAX) NULL,
    [Body]        NVARCHAR (MAX) NULL,
    [Status]      INT            NOT NULL,
    [CategoryId]  INT            DEFAULT ((0)) NOT NULL,
    [CreatedBy]   NVARCHAR (MAX) NULL,
    [CreatedOn]   DATETIME2 (7)  DEFAULT ('0001-01-01T00:00:00.0000000') NOT NULL,
    [DeletedBy]   NVARCHAR (MAX) NULL,
    [DeletedOn]   DATETIME2 (7)  NULL,
    [UpdatedBy]   NVARCHAR (MAX) NULL,
    [UpdatedOn]   DATETIME2 (7)  NULL,
    CONSTRAINT [PK_Topics] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Topics_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [db_owner].[Categories] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Topics_CategoryId]
    ON [db_owner].[Topics]([CategoryId] ASC);

