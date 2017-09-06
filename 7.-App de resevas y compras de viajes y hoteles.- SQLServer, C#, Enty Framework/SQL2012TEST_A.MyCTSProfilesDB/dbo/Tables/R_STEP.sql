CREATE TABLE [dbo].[R_STEP] (
    [ID_STEP]           BIGINT        NOT NULL,
    [ID_TRANSFORMATION] INT           NULL,
    [NAME]              VARCHAR (255) NULL,
    [DESCRIPTION]       TEXT          NULL,
    [ID_STEP_TYPE]      INT           NULL,
    [DISTRIBUTE]        CHAR (1)      NULL,
    [COPIES]            INT           NULL,
    [GUI_LOCATION_X]    INT           NULL,
    [GUI_LOCATION_Y]    INT           NULL,
    [GUI_DRAW]          CHAR (1)      NULL,
    PRIMARY KEY CLUSTERED ([ID_STEP] ASC)
);

