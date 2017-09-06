CREATE TABLE [dbo].[CatStarsFirstLevel_old] (
    [Pccid]        NVARCHAR (10) NOT NULL,
    [Star1Name]    NVARCHAR (50) NULL,
    [StarL2Exist]  BIT           NULL,
    [Active]       BIT           CONSTRAINT [DF_CatStarsFirstLevel_Active] DEFAULT ((1)) NULL,
    [InactiveDate] DATETIME      NULL,
    [IsNew]        BIT           NULL,
    [DK]           NVARCHAR (50) NULL
);


GO
CREATE STATISTICS [_dta_stat_2105058535_1_2_4_7]
    ON [dbo].[CatStarsFirstLevel_old]([Pccid], [Star1Name], [Active], [IsNew]);

