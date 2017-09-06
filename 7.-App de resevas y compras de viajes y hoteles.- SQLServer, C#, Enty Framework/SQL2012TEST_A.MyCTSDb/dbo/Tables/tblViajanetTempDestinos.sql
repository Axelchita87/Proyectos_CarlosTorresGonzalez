CREATE TABLE [dbo].[tblViajanetTempDestinos] (
    [IdRegistro]        VARCHAR (50) NULL,
    [AeropuertoDestino] VARCHAR (50) NULL,
    [AeropuertoOrigen]  VARCHAR (50) NULL,
    [Categoria]         VARCHAR (50) NULL,
    [Destino]           VARCHAR (50) NULL,
    [Origen]            VARCHAR (50) NULL,
    [Prioridad]         VARCHAR (50) NULL,
    [Precio]            VARCHAR (50) NULL,
    [Aerolinea]         VARCHAR (50) NULL,
    [Url]               VARCHAR (50) NULL,
    [FechaInsercion]    DATETIME     CONSTRAINT [DF_tblViajanetTempDestinos_FechaInsercion] DEFAULT (getdate()) NOT NULL,
    [FechaViaje]        VARCHAR (50) NULL,
    [NombreDestino]     VARCHAR (50) NULL
);

