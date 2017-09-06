CREATE TABLE [dbo].[CatFormats] (
    [IDFormat]    INT           IDENTITY (1, 1) NOT NULL,
    [Code]        NCHAR (10)    NOT NULL,
    [Description] NVARCHAR (50) NULL,
    CONSTRAINT [PK_CatFormatos_1] PRIMARY KEY CLUSTERED ([IDFormat] ASC)
);

