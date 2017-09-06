CREATE TABLE [dbo].[R_LOG] (
    [ID_LOG]          BIGINT        NOT NULL,
    [NAME]            VARCHAR (255) NULL,
    [ID_LOGLEVEL]     INT           NULL,
    [LOGTYPE]         VARCHAR (255) NULL,
    [FILENAME]        VARCHAR (255) NULL,
    [FILEEXTENTION]   VARCHAR (255) NULL,
    [ADD_DATE]        CHAR (1)      NULL,
    [ADD_TIME]        CHAR (1)      NULL,
    [ID_DATABASE_LOG] INT           NULL,
    [TABLE_NAME_LOG]  VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([ID_LOG] ASC)
);

