CREATE TABLE [dbo].[StarNew2] (
    [Pccid]    VARCHAR (10)  NULL,
    [Level1]   NVARCHAR (50) NULL,
    [Level2]   NVARCHAR (50) NULL,
    [Type]     VARCHAR (3)   NULL,
    [Text]     VARCHAR (100) NULL,
    [Date]     DATETIME      NULL,
    [Purged]   BIT           NULL,
    [Metadata] VARCHAR (MAX) NULL,
    [Email]    NVARCHAR (50) NULL
);

