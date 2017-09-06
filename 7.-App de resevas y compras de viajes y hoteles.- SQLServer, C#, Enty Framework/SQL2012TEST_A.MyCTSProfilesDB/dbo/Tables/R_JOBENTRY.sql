CREATE TABLE [dbo].[R_JOBENTRY] (
    [ID_JOBENTRY]      BIGINT        NOT NULL,
    [ID_JOB]           INT           NULL,
    [ID_JOBENTRY_TYPE] INT           NULL,
    [NAME]             VARCHAR (255) NULL,
    [DESCRIPTION]      TEXT          NULL,
    PRIMARY KEY CLUSTERED ([ID_JOBENTRY] ASC)
);

