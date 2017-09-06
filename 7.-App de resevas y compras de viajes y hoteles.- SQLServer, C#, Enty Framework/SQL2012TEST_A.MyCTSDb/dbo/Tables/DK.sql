CREATE TABLE [dbo].[DK] (
    [IDDK]          VARCHAR (10)  NOT NULL,
    [CorporativeID] VARCHAR (50)  NOT NULL,
    [Name]          VARCHAR (150) NULL,
    [Enabled]       BIT           NULL,
    CONSTRAINT [PK_DK_New] PRIMARY KEY CLUSTERED ([IDDK] ASC)
);

