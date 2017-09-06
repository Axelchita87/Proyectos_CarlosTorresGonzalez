CREATE TABLE [dbo].[AllPromoFOP] (
    [IdPromo]               INT           NULL,
    [Airline]               VARCHAR (50)  NULL,
    [TypeCard]              VARCHAR (50)  NULL,
    [EmissionBank]          VARCHAR (50)  NULL,
    [DatePromoBegin]        DATETIME      NULL,
    [DatePromoEnd]          DATETIME      NULL,
    [MonthsWithInterest]    VARCHAR (50)  NULL,
    [MonthsWithoutInterest] VARCHAR (50)  NULL,
    [Description]           VARCHAR (MAX) NULL,
    [Amount]                VARCHAR (50)  NULL,
    [Origen]                VARCHAR (50)  NULL,
    [Destination]           VARCHAR (50)  NULL,
    [OrigenZone]            VARCHAR (50)  NULL,
    [DestinationZone]       VARCHAR (50)  NULL,
    [CountryEmission]       VARCHAR (50)  NULL,
    [SharedFlight]          BIT           NULL,
    [IncludedClasses]       VARCHAR (50)  NULL,
    [ExcludedClasses]       VARCHAR (50)  NULL,
    [ApplyDatePromoFlight]  BIT           NULL,
    [Observaciones]         VARCHAR (MAX) NULL
);

