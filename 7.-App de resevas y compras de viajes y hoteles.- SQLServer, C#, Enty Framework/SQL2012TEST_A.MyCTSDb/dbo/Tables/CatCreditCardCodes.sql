CREATE TABLE [dbo].[CatCreditCardCodes] (
    [CatCreCarCodId]   INT           NOT NULL,
    [CatCreCarCodCode] NCHAR (2)     NULL,
    [CatCreCarCodName] NVARCHAR (50) NULL,
    CONSTRAINT [PK_CatCreditCardCodes] PRIMARY KEY CLUSTERED ([CatCreCarCodId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_CatCreditCardCodes]
    ON [dbo].[CatCreditCardCodes]([CatCreCarCodCode] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CatCreditCardCodes_1]
    ON [dbo].[CatCreditCardCodes]([CatCreCarCodName] ASC);

