CREATE TABLE [dbo].[ToolOnlineLog] (
    [LogID]           VARCHAR (50)  NULL,
    [DateLog]         DATETIME      NULL,
    [PNR]             VARCHAR (6)   NULL,
    [DK]              VARCHAR (6)   NULL,
    [Attribute1]      VARCHAR (6)   NULL,
    [FormatSendQueue] VARCHAR (MAX) NULL,
    [Supervisor]      VARCHAR (4)   NULL,
    [Consultores]     VARCHAR (30)  NULL
);

