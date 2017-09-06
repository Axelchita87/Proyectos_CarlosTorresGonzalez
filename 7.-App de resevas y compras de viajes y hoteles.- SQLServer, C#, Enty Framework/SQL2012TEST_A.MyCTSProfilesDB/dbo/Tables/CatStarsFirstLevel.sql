CREATE TABLE [dbo].[CatStarsFirstLevel] (
    [Pccid]        NVARCHAR (10) NOT NULL,
    [Star1Name]    NVARCHAR (50) NULL,
    [StarL2Exist]  BIT           NULL,
    [Active]       BIT           DEFAULT ((1)) NULL,
    [InactiveDate] DATETIME      NULL,
    [IsNew]        BIT           NULL,
    [DK]           NVARCHAR (50) NULL
);


GO
CREATE NONCLUSTERED INDEX [_dta_index_CatStarsFirstLevel_8_2037582297__K1_K2_K4_K6_7]
    ON [dbo].[CatStarsFirstLevel]([Pccid] ASC, [Star1Name] ASC, [Active] ASC, [IsNew] ASC)
    INCLUDE([DK]);

