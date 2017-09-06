CREATE TABLE [dbo].[LowFareAirLinesErrorLog] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [Agent]        VARCHAR (50)   NOT NULL,
    [ErrorMessage] NVARCHAR (MAX) NOT NULL,
    [AirLine]      VARCHAR (50)   NOT NULL,
    [Date]         DATETIME       NOT NULL,
    [ServiceName]  VARCHAR (50)   NOT NULL,
    CONSTRAINT [PK_LowFareAirLinesErrorLog] PRIMARY KEY CLUSTERED ([ID] ASC)
);

