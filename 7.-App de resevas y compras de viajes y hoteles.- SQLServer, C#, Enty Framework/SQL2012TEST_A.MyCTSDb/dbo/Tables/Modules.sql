CREATE TABLE [dbo].[Modules] (
    [ModulesId]   INT            NOT NULL,
    [ModulesName] NVARCHAR (150) NULL,
    [ModulesSrc]  NVARCHAR (250) NOT NULL,
    CONSTRAINT [PK_Modules] PRIMARY KEY CLUSTERED ([ModulesId] ASC)
);

