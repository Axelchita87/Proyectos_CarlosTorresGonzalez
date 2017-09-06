CREATE TABLE [dbo].[Enterprise] (
    [IDEnterprise] INT          NOT NULL,
    [Name]         VARCHAR (50) NULL,
    [Enabled]      BIT          NULL,
    CONSTRAINT [PK_Enterprise] PRIMARY KEY CLUSTERED ([IDEnterprise] ASC)
);

