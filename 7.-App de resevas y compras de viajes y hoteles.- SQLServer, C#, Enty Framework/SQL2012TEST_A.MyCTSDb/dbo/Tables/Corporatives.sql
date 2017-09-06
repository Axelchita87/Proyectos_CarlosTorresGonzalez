CREATE TABLE [dbo].[Corporatives] (
    [ID]                 INT           IDENTITY (1, 1) NOT NULL,
    [CorporativeIdICAAV] VARCHAR (10)  NULL,
    [IDCorporative]      VARCHAR (50)  NULL,
    [Location_DK]        VARCHAR (6)   NULL,
    [Name]               VARCHAR (150) NULL,
    [StatID]             INT           NULL,
    [Class]              VARCHAR (50)  NULL,
    [Queue]              VARCHAR (50)  NULL,
    [Queue2]             VARCHAR (50)  NULL,
    [Reservation]        BIT           CONSTRAINT [DF_Corporatives_Reservation_New] DEFAULT ((1)) NULL,
    [Emision]            BIT           CONSTRAINT [DF_Corporatives_Emision_New] DEFAULT ((1)) NULL,
    [Modified]           DATETIME      NULL,
    [Enabled]            BIT           NULL
);

