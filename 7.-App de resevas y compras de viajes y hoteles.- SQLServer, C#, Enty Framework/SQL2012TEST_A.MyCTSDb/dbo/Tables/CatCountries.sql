CREATE TABLE [dbo].[CatCountries] (
    [CatCouId]   VARCHAR (2)   NOT NULL,
    [CatCouName] VARCHAR (150) NULL,
    [CatZoneId]  NCHAR (3)     NULL,
    CONSTRAINT [PK_CatCountries] PRIMARY KEY CLUSTERED ([CatCouId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_CatCountries]
    ON [dbo].[CatCountries]([CatCouName] ASC);

