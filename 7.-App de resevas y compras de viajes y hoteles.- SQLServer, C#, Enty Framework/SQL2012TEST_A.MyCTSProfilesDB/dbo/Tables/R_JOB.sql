CREATE TABLE [dbo].[R_JOB] (
    [ID_JOB]               BIGINT        NOT NULL,
    [ID_DIRECTORY]         INT           NULL,
    [NAME]                 VARCHAR (255) NULL,
    [DESCRIPTION]          TEXT          NULL,
    [EXTENDED_DESCRIPTION] TEXT          NULL,
    [JOB_VERSION]          VARCHAR (255) NULL,
    [JOB_STATUS]           INT           NULL,
    [ID_DATABASE_LOG]      INT           NULL,
    [TABLE_NAME_LOG]       VARCHAR (255) NULL,
    [CREATED_USER]         VARCHAR (255) NULL,
    [CREATED_DATE]         DATETIME      NULL,
    [MODIFIED_USER]        VARCHAR (255) NULL,
    [MODIFIED_DATE]        DATETIME      NULL,
    [USE_BATCH_ID]         CHAR (1)      NULL,
    [PASS_BATCH_ID]        CHAR (1)      NULL,
    [USE_LOGFIELD]         CHAR (1)      NULL,
    [SHARED_FILE]          VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([ID_JOB] ASC)
);

