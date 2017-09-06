CREATE TABLE [dbo].[CatCarEquipmentCodes] (
    [CatCarEquCodId]   INT            NOT NULL,
    [CatCarEquCodCode] NCHAR (4)      NULL,
    [CatCarEquCodName] NVARCHAR (300) NULL,
    CONSTRAINT [PK_CatCarEquipmentCodes] PRIMARY KEY CLUSTERED ([CatCarEquCodId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_CatCarEquipmentCodes]
    ON [dbo].[CatCarEquipmentCodes]([CatCarEquCodCode] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CatCarEquipmentCodes_1]
    ON [dbo].[CatCarEquipmentCodes]([CatCarEquCodName] ASC);

