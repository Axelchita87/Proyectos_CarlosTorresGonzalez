CREATE TABLE [dbo].[CatEquipmentCar] (
    [IdEquipmentCar] INT           IDENTITY (1, 1) NOT NULL,
    [Code]           NCHAR (3)     NULL,
    [Description]    NVARCHAR (50) NULL,
    CONSTRAINT [PK_CatEquipmentCar] PRIMARY KEY CLUSTERED ([IdEquipmentCar] ASC)
);

