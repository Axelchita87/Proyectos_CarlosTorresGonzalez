CREATE TABLE [dbo].[CatAirLines] (
    [CatAirLinAlfaId]       VARCHAR (5)   NOT NULL,
    [CatAirLinNumId]        VARCHAR (5)   NULL,
    [CatAirLinName]         VARCHAR (150) NULL,
    [CatAirLinSocialReason] VARCHAR (150) NULL,
    CONSTRAINT [PK_CatAirLines] PRIMARY KEY CLUSTERED ([CatAirLinAlfaId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_CatAirLines]
    ON [dbo].[CatAirLines]([CatAirLinAlfaId] ASC);

