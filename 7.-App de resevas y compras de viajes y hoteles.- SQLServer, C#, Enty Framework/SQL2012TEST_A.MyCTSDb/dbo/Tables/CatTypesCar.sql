CREATE TABLE [dbo].[CatTypesCar] (
    [IdTypeCar]   INT           IDENTITY (1, 1) NOT NULL,
    [Code]        NCHAR (4)     NULL,
    [Description] NVARCHAR (50) NULL,
    CONSTRAINT [PK_CatTypesCar] PRIMARY KEY CLUSTERED ([IdTypeCar] ASC)
);

