CREATE TABLE [dbo].[CatStatesUSA] (
    [CstDtsUSAId]   INT           NOT NULL,
    [CatStaUSACode] NCHAR (2)     NULL,
    [CatStaUSAName] NVARCHAR (50) NULL,
    CONSTRAINT [PK_CatStatesUSA] PRIMARY KEY CLUSTERED ([CstDtsUSAId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_CatStatesUSA]
    ON [dbo].[CatStatesUSA]([CatStaUSACode] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CatStatesUSA_1]
    ON [dbo].[CatStatesUSA]([CatStaUSAName] ASC);

