CREATE TABLE [dbo].[CorporativeFeesRules] (
    [Attribute1]          VARCHAR (10)  NULL,
    [RuleNumber]          INT           IDENTITY (1, 1) NOT NULL,
    [Priority]            INT           NULL,
    [Description]         VARCHAR (50)  NULL,
    [ExtendedDescription] VARCHAR (200) NULL,
    [DefaultFee]          DECIMAL (18)  CONSTRAINT [DF_CorporativeFeesRules_DefaultFee] DEFAULT ((0)) NULL,
    [DefaultMount]        MONEY         CONSTRAINT [DF_CorporativeFeesRules_DefaultMount] DEFAULT ((0)) NULL,
    [Mandatory]           BIT           NOT NULL,
    [ActivationState]     BIT           NULL,
    [StartDate]           DATETIME      NULL,
    [ExpirationDate]      DATETIME      NULL,
    [CreatedByAgent]      NVARCHAR (2)  NULL
);

