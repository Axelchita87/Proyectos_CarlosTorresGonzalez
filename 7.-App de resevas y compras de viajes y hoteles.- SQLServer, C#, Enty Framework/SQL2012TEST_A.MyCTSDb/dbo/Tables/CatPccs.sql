CREATE TABLE [dbo].[CatPccs] (
    [CatPccId]       VARCHAR (50)     NOT NULL,
    [CatPccName]     VARCHAR (150)    NULL,
    [Status]         NVARCHAR (1)     NULL,
    [StandardClass]  NVARCHAR (1)     NULL,
    [SpecificClass]  NVARCHAR (1)     NULL,
    [Confirmation]   NVARCHAR (1)     NULL,
    [BusinessClass1] NVARCHAR (1)     NULL,
    [BusinessClass2] NVARCHAR (1)     NULL,
    [BusinessClass3] NVARCHAR (1)     NULL,
    [BusinessClass4] NVARCHAR (1)     NULL,
    [ApplicationId]  UNIQUEIDENTIFIER NULL,
    [Type]           NVARCHAR (50)    NULL,
    [Tool]           NCHAR (20)       NULL,
    [GDS]            NVARCHAR (50)    NULL,
    [ActiveDate]     DATETIME         NULL,
    [InactiveDate]   NVARCHAR (50)    NULL,
    PRIMARY KEY CLUSTERED ([CatPccId] ASC)
);

