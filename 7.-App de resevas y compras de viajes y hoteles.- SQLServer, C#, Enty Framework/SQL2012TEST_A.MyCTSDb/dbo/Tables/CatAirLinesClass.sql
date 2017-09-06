CREATE TABLE [dbo].[CatAirLinesClass] (
    [CatAirLinClaId]   VARCHAR (5)   NOT NULL,
    [CatAirLinClaName] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_CatAirLinesClass] PRIMARY KEY CLUSTERED ([CatAirLinClaId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_CatAirLinesClass]
    ON [dbo].[CatAirLinesClass]([CatAirLinClaName] ASC);

