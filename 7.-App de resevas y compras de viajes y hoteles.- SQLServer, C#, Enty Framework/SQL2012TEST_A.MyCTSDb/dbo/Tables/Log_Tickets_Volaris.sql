CREATE TABLE [dbo].[Log_Tickets_Volaris] (
    [ID]           INT          IDENTITY (1, 1) NOT NULL,
    [Date]         DATETIME     NOT NULL,
    [PNR_Airline]  VARCHAR (10) NOT NULL,
    [PNR_Sabre]    VARCHAR (10) NULL,
    [TicketNumber] VARCHAR (50) NOT NULL
);

