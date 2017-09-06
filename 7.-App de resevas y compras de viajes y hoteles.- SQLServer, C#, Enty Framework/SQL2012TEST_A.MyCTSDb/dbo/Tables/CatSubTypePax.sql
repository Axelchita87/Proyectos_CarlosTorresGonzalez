CREATE TABLE [dbo].[CatSubTypePax] (
    [CatTypPaxAutonumeric] INT          NOT NULL,
    [CatTypPaxId]          VARCHAR (15) NOT NULL,
    [CatSubTypPaxId]       VARCHAR (15) NOT NULL,
    [CatSubTypPaxName]     VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_SubTypePax] PRIMARY KEY CLUSTERED ([CatTypPaxAutonumeric] ASC)
);

