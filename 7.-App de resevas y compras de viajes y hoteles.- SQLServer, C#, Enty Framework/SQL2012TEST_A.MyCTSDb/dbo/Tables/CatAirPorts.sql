CREATE TABLE [dbo].[CatAirPorts] (
    [CatAirPorId]        INT           IDENTITY (1, 1) NOT NULL,
    [CatAirPorCode]      VARCHAR (3)   NULL,
    [CatAirPorName]      VARCHAR (150) NULL,
    [CatAirPorCountryId] VARCHAR (2)   NOT NULL,
    CONSTRAINT [PK_CatAirPorts] PRIMARY KEY CLUSTERED ([CatAirPorId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_CatAirPorts]
    ON [dbo].[CatAirPorts]([CatAirPorCode] ASC);

