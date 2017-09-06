CREATE TABLE [dbo].[CatMealCodes] (
    [CatMeaCodId]          INT            NOT NULL,
    [CatMeaCodCode]        NCHAR (5)      NULL,
    [CatMeaCodALCode]      NCHAR (2)      NULL,
    [CatMeaCodDescription] NVARCHAR (100) NULL,
    CONSTRAINT [PK_CatMealCodes] PRIMARY KEY CLUSTERED ([CatMeaCodId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_CatMealCodes]
    ON [dbo].[CatMealCodes]([CatMeaCodCode] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CatMealCodes_1]
    ON [dbo].[CatMealCodes]([CatMeaCodALCode] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CatMealCodes_2]
    ON [dbo].[CatMealCodes]([CatMeaCodDescription] ASC);

