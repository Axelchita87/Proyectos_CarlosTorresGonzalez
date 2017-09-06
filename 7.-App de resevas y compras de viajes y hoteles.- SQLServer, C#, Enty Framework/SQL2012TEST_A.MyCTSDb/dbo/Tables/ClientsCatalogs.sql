CREATE TABLE [dbo].[ClientsCatalogs] (
    [Attribute1]        VARCHAR (50)  NULL,
    [RemarkLabelID]     VARCHAR (5)   NULL,
    [Code]              VARCHAR (50)  NULL,
    [DescriptionCode]   VARCHAR (100) NULL,
    [AllowInsertValues] BIT           CONSTRAINT [DF_ClientsCatalogs_NEW_AllowInsertValues] DEFAULT ((1)) NULL
);

