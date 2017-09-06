CREATE TABLE [dbo].[CatCommands] (
    [IDCommand]   INT            NOT NULL,
    [ClientID]    INT            NOT NULL,
    [Status]      NVARCHAR (1)   NULL,
    [Remark]      NVARCHAR (100) NULL,
    [SabreFormat] NVARCHAR (100) NULL,
    [Class]       NVARCHAR (50)  NULL,
    CONSTRAINT [PK_CatCommands] PRIMARY KEY CLUSTERED ([IDCommand] ASC),
    CONSTRAINT [FK_CatCommands_CatClients] FOREIGN KEY ([ClientID]) REFERENCES [dbo].[Clients] ([IDClient])
);

