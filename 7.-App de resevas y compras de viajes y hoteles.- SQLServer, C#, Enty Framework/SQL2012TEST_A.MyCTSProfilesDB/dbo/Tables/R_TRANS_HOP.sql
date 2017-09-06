CREATE TABLE [dbo].[R_TRANS_HOP] (
    [ID_TRANS_HOP]      BIGINT   NOT NULL,
    [ID_TRANSFORMATION] INT      NULL,
    [ID_STEP_FROM]      INT      NULL,
    [ID_STEP_TO]        INT      NULL,
    [ENABLED]           CHAR (1) NULL,
    PRIMARY KEY CLUSTERED ([ID_TRANS_HOP] ASC)
);

