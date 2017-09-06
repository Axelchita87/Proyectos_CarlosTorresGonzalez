CREATE TABLE [dbo].[Clients] (
    [IDClient]    INT            NOT NULL,
    [Name]        NVARCHAR (50)  NULL,
    [Address]     NVARCHAR (50)  NULL,
    [Description] NVARCHAR (100) NULL,
    [Queue]       NCHAR (10)     NULL,
    [CountLines]  BIT            NULL,
    CONSTRAINT [PK_CatUsers] PRIMARY KEY CLUSTERED ([IDClient] ASC)
);

