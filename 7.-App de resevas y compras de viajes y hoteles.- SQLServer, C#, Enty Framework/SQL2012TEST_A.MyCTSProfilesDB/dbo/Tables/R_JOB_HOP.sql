CREATE TABLE [dbo].[R_JOB_HOP] (
    [ID_JOB_HOP]            BIGINT   NOT NULL,
    [ID_JOB]                INT      NULL,
    [ID_JOBENTRY_COPY_FROM] INT      NULL,
    [ID_JOBENTRY_COPY_TO]   INT      NULL,
    [ENABLED]               CHAR (1) NULL,
    [EVALUATION]            CHAR (1) NULL,
    [UNCONDITIONAL]         CHAR (1) NULL,
    PRIMARY KEY CLUSTERED ([ID_JOB_HOP] ASC)
);

