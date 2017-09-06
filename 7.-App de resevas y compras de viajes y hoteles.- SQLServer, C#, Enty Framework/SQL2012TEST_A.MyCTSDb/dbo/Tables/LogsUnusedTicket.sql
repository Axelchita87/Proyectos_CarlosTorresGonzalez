CREATE TABLE [dbo].[LogsUnusedTicket] (
    [LogID]        INT           IDENTITY (1, 1) NOT NULL,
    [UnusedTicket] NVARCHAR (60) NOT NULL,
    [DateRegister] DATETIME      NOT NULL,
    CONSTRAINT [PK_LogsUnusedTicket] PRIMARY KEY CLUSTERED ([LogID] ASC)
);

