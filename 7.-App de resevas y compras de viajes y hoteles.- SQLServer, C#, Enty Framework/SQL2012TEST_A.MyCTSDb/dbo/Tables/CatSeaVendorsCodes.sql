CREATE TABLE [dbo].[CatSeaVendorsCodes] (
    [CatSeaVenCodId]   INT            NOT NULL,
    [CatSeaVenCodCode] NCHAR (2)      NULL,
    [CatSeaVenCodName] NVARCHAR (100) NULL,
    CONSTRAINT [PK_CatSeaVendorsCodes] PRIMARY KEY CLUSTERED ([CatSeaVenCodId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_CatSeaVendorsCodes]
    ON [dbo].[CatSeaVendorsCodes]([CatSeaVenCodCode] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CatSeaVendorsCodes_1]
    ON [dbo].[CatSeaVendorsCodes]([CatSeaVenCodName] ASC);

