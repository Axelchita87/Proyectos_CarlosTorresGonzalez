﻿CREATE TABLE [dbo].[R_CLUSTER] (
    [ID_CLUSTER]             BIGINT        NOT NULL,
    [NAME]                   VARCHAR (255) NULL,
    [BASE_PORT]              VARCHAR (255) NULL,
    [SOCKETS_BUFFER_SIZE]    VARCHAR (255) NULL,
    [SOCKETS_FLUSH_INTERVAL] VARCHAR (255) NULL,
    [SOCKETS_COMPRESSED]     CHAR (1)      NULL,
    [DYNAMIC_CLUSTER]        CHAR (1)      NULL,
    PRIMARY KEY CLUSTERED ([ID_CLUSTER] ASC)
);

