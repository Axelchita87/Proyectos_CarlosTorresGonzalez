CREATE TABLE [dbo].[LogAuthCCPending] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [PNR]       VARCHAR (6)   NOT NULL,
    [AuthCode]  VARCHAR (6)   NULL,
    [CardType]  VARCHAR (2)   NULL,
    [Amount]    VARCHAR (50)  NULL,
    [Bank]      VARCHAR (50)  NULL,
    [Ticket]    VARCHAR (MAX) NULL,
    [Date]      DATETIME      NULL,
    [CommandWP] VARCHAR (50)  NULL
);

