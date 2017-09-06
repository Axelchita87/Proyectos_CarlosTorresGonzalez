CREATE TABLE [dbo].[CatStatusCodes] (
    [CatStaCodId]          INT            NOT NULL,
    [CatStaCodCode]        NCHAR (2)      NULL,
    [CatStaCodDescription] NVARCHAR (350) NULL,
    CONSTRAINT [PK_CatStatusCodes] PRIMARY KEY CLUSTERED ([CatStaCodId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_CatStatusCodes]
    ON [dbo].[CatStatusCodes]([CatStaCodCode] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CatStatusCodes_1]
    ON [dbo].[CatStatusCodes]([CatStaCodDescription] ASC);

