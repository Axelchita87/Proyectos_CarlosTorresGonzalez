CREATE TABLE [dbo].[CatStarsSecondLevel] (
    [Pccid]        NVARCHAR (10) NOT NULL,
    [Star1id]      NVARCHAR (50) NOT NULL,
    [Star2Name]    NVARCHAR (50) NOT NULL,
    [Active]       BIT           CONSTRAINT [DF_CatStarsSecondLevel_Active] DEFAULT ((1)) NULL,
    [InactiveDate] DATETIME      NULL,
    [IsNew]        BIT           NULL,
    CONSTRAINT [PK_CatStarsSecondLevel] PRIMARY KEY CLUSTERED ([Pccid] ASC, [Star1id] ASC, [Star2Name] ASC)
);


GO
CREATE NONCLUSTERED INDEX [_dta_index_CatStarsSecondLevel_8_965578478__K1_K3_K4_K6_K2]
    ON [dbo].[CatStarsSecondLevel]([Pccid] ASC, [Star2Name] ASC, [Active] ASC, [IsNew] ASC, [Star1id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CatStarsSecondLevel]
    ON [dbo].[CatStarsSecondLevel]([Pccid] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CatStarsSecondLevel_1]
    ON [dbo].[CatStarsSecondLevel]([Star1id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CatStarsSecondLevel_2]
    ON [dbo].[CatStarsSecondLevel]([Star2Name] ASC);

