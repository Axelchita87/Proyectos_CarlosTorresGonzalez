CREATE TABLE [dbo].[CatCurrencyCountry] (
    [CatCurCouAutoId] INT          IDENTITY (1, 1) NOT NULL,
    [CatCurCouId]     VARCHAR (5)  NOT NULL,
    [CatCurCouCode]   VARCHAR (5)  NOT NULL,
    [CatCurCouName]   VARCHAR (20) NOT NULL,
    CONSTRAINT [PK_CurrencyCountry] PRIMARY KEY CLUSTERED ([CatCurCouAutoId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_CatCurrencyCountry]
    ON [dbo].[CatCurrencyCountry]([CatCurCouCode] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CatCurrencyCountry_1]
    ON [dbo].[CatCurrencyCountry]([CatCurCouName] ASC);

