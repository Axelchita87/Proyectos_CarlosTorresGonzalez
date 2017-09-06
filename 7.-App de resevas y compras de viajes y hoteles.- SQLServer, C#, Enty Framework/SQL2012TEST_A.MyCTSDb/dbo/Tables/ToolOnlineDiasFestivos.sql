CREATE TABLE [dbo].[ToolOnlineDiasFestivos] (
    [IDDiaFest]   INT          IDENTITY (1, 1) NOT NULL,
    [Fecha]       DATETIME     NULL,
    [TipoFestivo] VARCHAR (10) NULL,
    [Horario]     VARCHAR (10) NULL
);

