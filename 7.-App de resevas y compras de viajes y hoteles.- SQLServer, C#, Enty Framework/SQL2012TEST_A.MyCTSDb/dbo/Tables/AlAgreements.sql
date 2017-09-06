CREATE TABLE [dbo].[AlAgreements] (
    [IDAlCode]               VARCHAR (5)   NOT NULL,
    [InternationalComission] VARCHAR (2)   NULL,
    [DomesticComission]      VARCHAR (2)   NULL,
    [TourCode]               VARCHAR (100) NULL,
    [OSI]                    VARCHAR (100) NULL,
    CONSTRAINT [PK_AlAgreements] PRIMARY KEY CLUSTERED ([IDAlCode] ASC)
);

