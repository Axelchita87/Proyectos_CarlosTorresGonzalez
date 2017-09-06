CREATE TABLE [dbo].[R_JOB_ATTRIBUTE] (
    [ID_JOB_ATTRIBUTE] BIGINT        NOT NULL,
    [ID_JOB]           INT           NULL,
    [NR]               INT           NULL,
    [CODE]             VARCHAR (255) NULL,
    [VALUE_NUM]        BIGINT        NULL,
    [VALUE_STR]        TEXT          NULL,
    PRIMARY KEY CLUSTERED ([ID_JOB_ATTRIBUTE] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_JOB_ATTRIBUTE_LOOKUP]
    ON [dbo].[R_JOB_ATTRIBUTE]([ID_JOB] ASC, [CODE] ASC, [NR] ASC);

