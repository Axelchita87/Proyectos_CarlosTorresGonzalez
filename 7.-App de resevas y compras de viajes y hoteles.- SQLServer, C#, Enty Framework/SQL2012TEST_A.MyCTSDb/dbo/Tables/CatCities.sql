CREATE TABLE [dbo].[CatCities] (
    [CatCitId]    VARCHAR (3)   NOT NULL,
    [CatCitName]  VARCHAR (150) NOT NULL,
    [CatCitCouId] VARCHAR (2)   NOT NULL,
    CONSTRAINT [PK_CatCities_1] PRIMARY KEY CLUSTERED ([CatCitId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_CatCities]
    ON [dbo].[CatCities]([CatCitName] ASC);

