CREATE TABLE [dbo].[CatHotels] (
    [CatHotId]        INT           IDENTITY (1, 1) NOT NULL,
    [CatHotCode]      VARCHAR (5)   NULL,
    [CatHotNameChain] VARCHAR (150) NULL,
    CONSTRAINT [PK_CatHotels] PRIMARY KEY CLUSTERED ([CatHotId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_CatHotels]
    ON [dbo].[CatHotels]([CatHotCode] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CatHotels_1]
    ON [dbo].[CatHotels]([CatHotNameChain] ASC);

