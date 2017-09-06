CREATE TABLE [dbo].[CatCarTypesCodes] (
    [CatCarTypCodId]          INT            NOT NULL,
    [CatCarTypCodCode]        NCHAR (5)      NULL,
    [CatCarTypCodDescription] NVARCHAR (300) NULL,
    CONSTRAINT [PK_CatCarTypesCodes] PRIMARY KEY CLUSTERED ([CatCarTypCodId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_CatCarTypesCodes]
    ON [dbo].[CatCarTypesCodes]([CatCarTypCodCode] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CatCarTypesCodes_1]
    ON [dbo].[CatCarTypesCodes]([CatCarTypCodDescription] ASC);

