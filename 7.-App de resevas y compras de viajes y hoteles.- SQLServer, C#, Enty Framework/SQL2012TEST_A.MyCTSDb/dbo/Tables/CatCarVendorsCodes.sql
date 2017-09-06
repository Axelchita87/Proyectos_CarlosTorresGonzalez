CREATE TABLE [dbo].[CatCarVendorsCodes] (
    [CatCarVenCodId]   INT         NOT NULL,
    [CatCarVenCodCode] NCHAR (2)   NULL,
    [CatCarVenCodName] NCHAR (100) NULL,
    CONSTRAINT [PK_CatCarVendorsCodes] PRIMARY KEY CLUSTERED ([CatCarVenCodId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_CatCarVendorsCodes]
    ON [dbo].[CatCarVendorsCodes]([CatCarVenCodCode] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CatCarVendorsCodes_1]
    ON [dbo].[CatCarVendorsCodes]([CatCarVenCodName] ASC);

