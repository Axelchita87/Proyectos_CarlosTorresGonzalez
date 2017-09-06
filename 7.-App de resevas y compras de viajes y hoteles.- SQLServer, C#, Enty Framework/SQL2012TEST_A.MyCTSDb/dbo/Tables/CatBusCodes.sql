CREATE TABLE [dbo].[CatBusCodes] (
    [CatBusCodId]   INT            NOT NULL,
    [CatBusCodCode] NCHAR (3)      NOT NULL,
    [CatBusCodName] NVARCHAR (300) NULL,
    CONSTRAINT [PK_CatBusCodes] PRIMARY KEY CLUSTERED ([CatBusCodId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_CatBusCodes]
    ON [dbo].[CatBusCodes]([CatBusCodCode] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CatBusCodes_1]
    ON [dbo].[CatBusCodes]([CatBusCodName] ASC);

