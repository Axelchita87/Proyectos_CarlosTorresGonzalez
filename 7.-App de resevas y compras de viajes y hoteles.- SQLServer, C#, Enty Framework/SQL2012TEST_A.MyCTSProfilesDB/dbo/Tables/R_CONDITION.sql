CREATE TABLE [dbo].[R_CONDITION] (
    [ID_CONDITION]        BIGINT        NOT NULL,
    [ID_CONDITION_PARENT] INT           NULL,
    [NEGATED]             CHAR (1)      NULL,
    [OPERATOR]            VARCHAR (255) NULL,
    [LEFT_NAME]           VARCHAR (255) NULL,
    [CONDITION_FUNCTION]  VARCHAR (255) NULL,
    [RIGHT_NAME]          VARCHAR (255) NULL,
    [ID_VALUE_RIGHT]      INT           NULL,
    PRIMARY KEY CLUSTERED ([ID_CONDITION] ASC)
);

