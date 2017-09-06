CREATE TABLE [dbo].[Applications] (
    [ApplicationName]        NVARCHAR (256)   COLLATE Modern_Spanish_CI_AS NOT NULL,
    [LoweredApplicationName] NVARCHAR (256)   COLLATE Modern_Spanish_CI_AS NOT NULL,
    [ApplicationId]          UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Description]            NVARCHAR (256)   COLLATE Modern_Spanish_CI_AS NULL,
    [OrgId]                  INT              NULL,
    PRIMARY KEY NONCLUSTERED ([ApplicationId] ASC),
    UNIQUE NONCLUSTERED ([ApplicationName] ASC),
    UNIQUE NONCLUSTERED ([LoweredApplicationName] ASC)
);

