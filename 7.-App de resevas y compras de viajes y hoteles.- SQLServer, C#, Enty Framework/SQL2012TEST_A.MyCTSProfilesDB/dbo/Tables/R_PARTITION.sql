﻿CREATE TABLE [dbo].[R_PARTITION] (
    [ID_PARTITION]        BIGINT        NOT NULL,
    [ID_PARTITION_SCHEMA] INT           NULL,
    [PARTITION_ID]        VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([ID_PARTITION] ASC)
);

