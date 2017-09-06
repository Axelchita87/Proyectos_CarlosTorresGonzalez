CREATE TABLE [dbo].[LogOnlinePayServices] (
    [fcFormTypeCodeFOP] NVARCHAR (10)   NOT NULL,
    [fiPaxNumber]       INT             NOT NULL,
    [fcPNR]             VARCHAR (10)    NOT NULL,
    [fdtFechaRegistro]  DATETIME        CONSTRAINT [DF_LogOnlinePayServices_fdtFechaRegistro] DEFAULT (getdate()) NOT NULL,
    [fcAutorization]    VARCHAR (10)    NOT NULL,
    [fcOperation]       VARCHAR (10)    NOT NULL,
    [fcTarjeta]         VARCHAR (16)    NOT NULL,
    [fdMonto]           DECIMAL (18, 2) NOT NULL,
    [fcBoleto]          VARCHAR (50)    NULL,
    [fcRemark]          VARCHAR (100)   NULL,
    CONSTRAINT [PK_LogOnlinePayServices] PRIMARY KEY CLUSTERED ([fcFormTypeCodeFOP] ASC, [fcPNR] ASC, [fcAutorization] ASC, [fcOperation] ASC)
);

