CREATE TABLE [dbo].[R_STEP_ATTRIBUTE] (
    [ID_STEP_ATTRIBUTE] BIGINT        NOT NULL,
    [ID_TRANSFORMATION] INT           NULL,
    [ID_STEP]           INT           NULL,
    [NR]                INT           NULL,
    [CODE]              VARCHAR (255) NULL,
    [VALUE_NUM]         BIGINT        NULL,
    [VALUE_STR]         TEXT          NULL,
    PRIMARY KEY CLUSTERED ([ID_STEP_ATTRIBUTE] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_R_STEP_ATTRIBUTE_LOOKUP]
    ON [dbo].[R_STEP_ATTRIBUTE]([ID_STEP] ASC, [CODE] ASC, [NR] ASC);

