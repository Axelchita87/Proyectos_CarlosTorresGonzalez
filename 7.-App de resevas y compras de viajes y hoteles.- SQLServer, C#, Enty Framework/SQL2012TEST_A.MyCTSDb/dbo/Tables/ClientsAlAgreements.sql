CREATE TABLE [dbo].[ClientsAlAgreements] (
    [IDClientsAgreement] INT           NOT NULL,
    [Attribute1]         VARCHAR (50)  NOT NULL,
    [AirlineID]          VARCHAR (5)   NOT NULL,
    [ITCode]             VARCHAR (100) NULL,
    [ITCommand]          VARCHAR (10)  NULL,
    [FlightType]         VARCHAR (1)   NULL,
    CONSTRAINT [PK_ClientsAgreements] PRIMARY KEY CLUSTERED ([IDClientsAgreement] ASC)
);

