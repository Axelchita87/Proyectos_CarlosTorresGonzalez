CREATE TABLE [dbo].[Roles] (
    [ApplicationId]   UNIQUEIDENTIFIER NOT NULL,
    [RoleId]          UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [RoleName]        NVARCHAR (256)   COLLATE Modern_Spanish_CI_AS NOT NULL,
    [LoweredRoleName] NVARCHAR (256)   COLLATE Modern_Spanish_CI_AS NOT NULL,
    [Description]     NVARCHAR (256)   COLLATE Modern_Spanish_CI_AS NULL,
    PRIMARY KEY NONCLUSTERED ([RoleId] ASC),
    CONSTRAINT [FK_Roles_Applications] FOREIGN KEY ([ApplicationId]) REFERENCES [dbo].[Applications] ([ApplicationId])
);

