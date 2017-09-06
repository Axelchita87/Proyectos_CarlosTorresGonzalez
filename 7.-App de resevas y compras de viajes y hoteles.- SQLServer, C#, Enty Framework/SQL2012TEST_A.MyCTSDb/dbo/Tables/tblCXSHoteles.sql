CREATE TABLE [dbo].[tblCXSHoteles] (
    [fdtFechaRegistro] DATETIME        CONSTRAINT [DF_tblCXSHoteles_fdtFechaRegistro] DEFAULT (getdate()) NOT NULL,
    [fcPNR]            VARCHAR (15)    NOT NULL,
    [fcTransaccionId]  VARCHAR (50)    NULL,
    [fcReservacion]    VARCHAR (20)    NULL,
    [fcFactura]        VARCHAR (20)    NULL,
    [fcSerie]          VARCHAR (20)    NULL,
    [fcFacturaCargo]   VARCHAR (20)    NULL,
    [fcSerieCargo]     VARCHAR (20)    NULL,
    [fiOrgId]          INT             NOT NULL,
    [Id]               INT             NOT NULL,
    [fcAutorization]   VARCHAR (10)    NULL,
    [fcOperation]      VARCHAR (10)    NULL,
    [fcNumeroTarjeta]  VARCHAR (50)    NULL,
    [fcFormaDePago]    VARCHAR (10)    NULL,
    [fdMonto]          DECIMAL (18, 4) NULL,
    CONSTRAINT [PK_tblCXSHoteles_1] PRIMARY KEY CLUSTERED ([fcPNR] ASC, [fiOrgId] ASC, [Id] ASC)
);

