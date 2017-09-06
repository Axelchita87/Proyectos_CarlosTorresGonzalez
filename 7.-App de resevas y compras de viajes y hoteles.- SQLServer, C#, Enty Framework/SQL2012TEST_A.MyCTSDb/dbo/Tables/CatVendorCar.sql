CREATE TABLE [dbo].[CatVendorCar] (
    [IdVendorCar] INT           IDENTITY (1, 1) NOT NULL,
    [Code]        NCHAR (2)     NULL,
    [Vendor]      NVARCHAR (50) NULL,
    CONSTRAINT [PK_CatVendorCar] PRIMARY KEY CLUSTERED ([IdVendorCar] ASC)
);

