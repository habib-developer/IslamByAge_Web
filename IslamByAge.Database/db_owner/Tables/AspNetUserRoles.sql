CREATE TABLE [db_owner].[AspNetUserRoles] (
    [UserId] NVARCHAR (450) NOT NULL,
    [RoleId] NVARCHAR (450) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [db_owner].[AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [db_owner].[AspNetUsers] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId]
    ON [db_owner].[AspNetUserRoles]([RoleId] ASC);

