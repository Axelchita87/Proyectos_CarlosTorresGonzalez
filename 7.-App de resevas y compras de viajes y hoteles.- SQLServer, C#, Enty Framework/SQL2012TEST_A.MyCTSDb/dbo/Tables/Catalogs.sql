CREATE TABLE [dbo].[Catalogs] (
    [FileName]    NVARCHAR (250) NOT NULL,
    [SPName]      NVARCHAR (150) NULL,
    [OrderBy]     INT            NULL,
    [Description] NVARCHAR (250) NULL,
    CONSTRAINT [PK_Catalogs] PRIMARY KEY CLUSTERED ([FileName] ASC)
);

