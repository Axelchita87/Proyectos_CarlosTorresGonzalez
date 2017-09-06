CREATE TABLE [dbo].[R_DATABASE] (
    [ID_DATABASE]         BIGINT        NOT NULL,
    [NAME]                VARCHAR (255) NULL,
    [ID_DATABASE_TYPE]    INT           NULL,
    [ID_DATABASE_CONTYPE] INT           NULL,
    [HOST_NAME]           VARCHAR (255) NULL,
    [DATABASE_NAME]       VARCHAR (255) NULL,
    [PORT]                INT           NULL,
    [USERNAME]            VARCHAR (255) NULL,
    [PASSWORD]            VARCHAR (255) NULL,
    [SERVERNAME]          VARCHAR (255) NULL,
    [DATA_TBS]            VARCHAR (255) NULL,
    [INDEX_TBS]           VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([ID_DATABASE] ASC)
);

