CREATE TABLE [dbo].[CatZones] (
    [CatZoneId]   NCHAR (3)     NOT NULL,
    [CatZoneName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_CatZones] PRIMARY KEY CLUSTERED ([CatZoneId] ASC)
);

