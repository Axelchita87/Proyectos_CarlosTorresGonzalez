CREATE TABLE [dbo].[R_JOBENTRY_COPY] (
    [ID_JOBENTRY_COPY] BIGINT   NOT NULL,
    [ID_JOBENTRY]      INT      NULL,
    [ID_JOB]           INT      NULL,
    [ID_JOBENTRY_TYPE] INT      NULL,
    [NR]               INT      NULL,
    [GUI_LOCATION_X]   INT      NULL,
    [GUI_LOCATION_Y]   INT      NULL,
    [GUI_DRAW]         CHAR (1) NULL,
    [PARALLEL]         CHAR (1) NULL,
    PRIMARY KEY CLUSTERED ([ID_JOBENTRY_COPY] ASC)
);

