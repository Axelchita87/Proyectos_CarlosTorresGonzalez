CREATE TABLE [dbo].[LogClipboardCTS] (
    [ID]         INT         IDENTITY (1, 1) NOT NULL,
    [Date]       DATETIME    NOT NULL,
    [Agent]      VARCHAR (2) NOT NULL,
    [OptionUsed] TINYINT     NOT NULL,
    [PNR]        VARCHAR (6) NULL,
    CONSTRAINT [PK_LogClipboardCTS] PRIMARY KEY CLUSTERED ([ID] ASC)
);

