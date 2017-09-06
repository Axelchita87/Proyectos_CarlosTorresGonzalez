CREATE TABLE [dbo].[Star1] (
    [IDStar1] INT           NOT NULL,
    [PCCID]   VARCHAR (50)  NULL,
    [L1]      INT           NULL,
    [L2]      VARCHAR (30)  NULL,
    [Line]    BIGINT        NULL,
    [Type]    VARCHAR (1)   NULL,
    [Text]    VARCHAR (100) NULL,
    [Date]    DATETIME      NULL,
    [Hour]    DATETIME      NULL,
    [Enabled] BIT           NULL,
    CONSTRAINT [PK_Star1_1] PRIMARY KEY CLUSTERED ([IDStar1] ASC)
);

