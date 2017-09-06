CREATE TABLE [dbo].[UpdatedProfiles] (
    [Id]                  BIGINT       IDENTITY (1, 1) NOT NULL,
    [Id_perfil]           INT          NULL,
    [FieldKey]            SMALLINT     NULL,
    [ChangedValue]        VARCHAR (30) NULL,
    [Correo]              VARCHAR (30) NULL,
    [PCC]                 VARCHAR (5)  NULL,
    [Level1]              VARCHAR (30) NULL,
    [Level2]              VARCHAR (30) NULL,
    [fechaActualizacion]  DATETIME     NULL,
    [Intento]             SMALLINT     NULL,
    [StatusActualizacion] BIT          NULL
);

