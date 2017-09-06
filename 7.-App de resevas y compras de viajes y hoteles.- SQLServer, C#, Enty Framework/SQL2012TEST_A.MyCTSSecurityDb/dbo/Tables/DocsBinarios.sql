CREATE TABLE [dbo].[DocsBinarios] (
    [DocId]     INT           IDENTITY (1, 1) NOT NULL,
    [Documento] IMAGE         NULL,
    [NombreDoc] VARCHAR (100) NULL,
    [Extension] VARCHAR (50)  NULL
);

