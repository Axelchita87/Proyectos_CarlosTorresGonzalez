CREATE TABLE [dbo].[Error_log_ServiceCharge] (
    [Id]                 INT           IDENTITY (1, 1) NOT NULL,
    [StatusTransaccion]  NVARCHAR (50) NULL,
    [MensajeAmistoso]    NVARCHAR (50) NULL,
    [NumeroAutorizacion] NVARCHAR (50) NULL,
    [NumeroOperacion]    NVARCHAR (50) NULL,
    [Fecha_creacion]     DATETIME      NULL
);

