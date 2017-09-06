CREATE TABLE [dbo].[R_JOBENTRY_ATTRIBUTE] (
    [ID_JOBENTRY_ATTRIBUTE] BIGINT          NOT NULL,
    [ID_JOB]                INT             NULL,
    [ID_JOBENTRY]           INT             NULL,
    [NR]                    INT             NULL,
    [CODE]                  VARCHAR (255)   NULL,
    [VALUE_NUM]             DECIMAL (13, 2) NULL,
    [VALUE_STR]             TEXT            NULL,
    PRIMARY KEY CLUSTERED ([ID_JOBENTRY_ATTRIBUTE] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_R_JOBENTRY_ATTRIBUTE_LOOKUP]
    ON [dbo].[R_JOBENTRY_ATTRIBUTE]([ID_JOBENTRY_ATTRIBUTE] ASC, [CODE] ASC, [NR] ASC);

