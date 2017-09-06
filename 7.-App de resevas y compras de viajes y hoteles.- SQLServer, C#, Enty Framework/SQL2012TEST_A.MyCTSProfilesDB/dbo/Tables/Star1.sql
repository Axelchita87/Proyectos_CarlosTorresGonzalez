CREATE TABLE [dbo].[Star1] (
    [Pccid]    VARCHAR (10)  NULL,
    [Level1]   NVARCHAR (50) NULL,
    [Type]     VARCHAR (3)   NULL,
    [Text]     VARCHAR (100) NULL,
    [Date]     DATETIME      NULL,
    [Purged]   BIT           NULL,
    [Metadata] AS            ([dbo].[CalculateMetadata]([Type],[Text]))
);


GO
CREATE NONCLUSTERED INDEX [_dta_index_Star1_8_997578592__K2_3_4]
    ON [dbo].[Star1]([Level1] ASC)
    INCLUDE([Type], [Text]);

