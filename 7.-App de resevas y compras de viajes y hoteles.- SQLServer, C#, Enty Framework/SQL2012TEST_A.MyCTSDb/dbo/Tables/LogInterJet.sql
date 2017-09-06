CREATE TABLE [dbo].[LogInterJet] (
    [ID]              INT          IDENTITY (1, 1) NOT NULL,
    [Agent]           VARCHAR (50) NULL,
    [Date]            DATETIME     NULL,
    [ReservationCode] VARCHAR (10) NULL,
    [Approved]        BIT          NOT NULL,
    [Invoiced]        BIT          NOT NULL,
    [RecordLocator]   VARCHAR (10) NULL,
    [Amount]          DECIMAL (18) NULL,
    CONSTRAINT [PK_LogInterJet] PRIMARY KEY CLUSTERED ([ID] ASC)
);

