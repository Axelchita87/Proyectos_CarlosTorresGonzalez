CREATE TABLE [dbo].[VolarisLog] (
    [ID]         INT          IDENTITY (1, 1) NOT NULL,
    [VolarisPNR] VARCHAR (50) NULL,
    [Approved]   BIT          NOT NULL,
    [Invoiced]   BIT          NOT NULL,
    [SabrePNR]   VARCHAR (50) NULL,
    [Agent]      VARCHAR (10) NOT NULL,
    [AgentMail]  VARCHAR (50) NOT NULL,
    [AuthCode]   VARCHAR (10) NULL,
    [Date]       DATETIME     NOT NULL,
    [Amount]     DECIMAL (18) NOT NULL,
    CONSTRAINT [PK_VolarisLog] PRIMARY KEY CLUSTERED ([ID] ASC)
);

