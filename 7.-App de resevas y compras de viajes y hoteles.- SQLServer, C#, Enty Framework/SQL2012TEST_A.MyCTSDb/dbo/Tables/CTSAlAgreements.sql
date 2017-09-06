CREATE TABLE [dbo].[CTSAlAgreements] (
    [IDCTSAlAgreement] INT         NOT NULL,
    [AirlineID]        VARCHAR (5) NULL,
    [ClassType]        VARCHAR (1) NULL,
    [ITCode]           VARCHAR (5) NULL,
    [ITCommand]        VARCHAR (1) NULL,
    [FlightType]       VARCHAR (1) NULL,
    [InitDate]         DATETIME    NULL,
    [FinalDate]        DATETIME    NULL,
    CONSTRAINT [PK_CTSAlAgreements] PRIMARY KEY CLUSTERED ([IDCTSAlAgreement] ASC)
);

