CREATE TABLE [dbo].[CatAirLinesFare] (
    [CatAirLinFarId]   VARCHAR (5)   NOT NULL,
    [CatAirLinFarName] VARCHAR (150) NOT NULL,
    [CCAut]            BIT           CONSTRAINT [DF_CatAirLinesFare_CCAut] DEFAULT ((1)) NULL,
    [CCMan]            BIT           CONSTRAINT [DF_CatAirLinesFare_CCMan] DEFAULT ((1)) NULL,
    [Cash]             BIT           CONSTRAINT [DF_CatAirLinesFare_Cash] DEFAULT ((1)) NULL,
    [PMix]             BIT           CONSTRAINT [DF_CatAirLinesFare_PMix] DEFAULT ((1)) NULL,
    [Misc]             BIT           CONSTRAINT [DF_CatAirLinesFare_Misc] DEFAULT ((1)) NULL,
    [LogoAirLine]      IMAGE         NULL,
    [OPManual]         BIT           NULL,
    CONSTRAINT [PK_CatAirLinesFare] PRIMARY KEY CLUSTERED ([CatAirLinFarId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_CatAirLinesFare]
    ON [dbo].[CatAirLinesFare]([CatAirLinFarName] ASC);

