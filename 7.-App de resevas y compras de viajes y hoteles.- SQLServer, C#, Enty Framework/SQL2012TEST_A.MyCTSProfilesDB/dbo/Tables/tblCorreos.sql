CREATE TABLE [dbo].[tblCorreos] (
    [Posicion] INT           NOT NULL,
    [Email]    VARCHAR (100) NOT NULL,
    [pccId]    VARCHAR (50)  NOT NULL,
    [Level1]   VARCHAR (100) NOT NULL,
    [level2]   VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_tblCorreos] PRIMARY KEY CLUSTERED ([pccId] ASC, [Level1] ASC, [level2] ASC)
);


GO
CREATE NONCLUSTERED INDEX [_dta_index_tblCorreos_8_322100188__K3_K5_K4_2]
    ON [dbo].[tblCorreos]([pccId] ASC, [level2] ASC, [Level1] ASC)
    INCLUDE([Email]);

