CREATE TABLE [dbo].[Users_copy] (
    [ApplicationId]          UNIQUEIDENTIFIER NOT NULL,
    [UserId]                 UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [UserName]               NVARCHAR (256)   NOT NULL,
    [LoweredUserName]        NVARCHAR (256)   NOT NULL,
    [UserMail]               NVARCHAR (50)    DEFAULT ((0)) NULL,
    [LastActivityDate]       DATETIME         NULL,
    [Firm]                   NVARCHAR (50)    NULL,
    [Password]               NVARCHAR (50)    NULL,
    [FamilyName]             NVARCHAR (50)    NULL,
    [Agent]                  NVARCHAR (50)    NULL,
    [Queue]                  NVARCHAR (50)    NULL,
    [PCC]                    NVARCHAR (50)    NULL,
    [TA]                     NVARCHAR (50)    NULL,
    [GDS]                    NVARCHAR (10)    NULL,
    [MyCTSVersion]           NVARCHAR (10)    NULL,
    [IsMySabreBlocked]       BIT              DEFAULT ((1)) NOT NULL,
    [ProfileAllAccess]       NVARCHAR (3)     NULL,
    [InstallFramework35]     BIT              DEFAULT ((0)) NOT NULL,
    [IsFramework35Installed] BIT              DEFAULT ((0)) NOT NULL,
    [ProductivityMail]       BIT              DEFAULT ((0)) NOT NULL,
    [Supervisor]             BIT              NULL,
    [UpgradeStatus]          INT              DEFAULT ((2)) NULL,
    [AgentMail]              NVARCHAR (50)    NULL,
    [StatusFirm]             CHAR (1)         NULL,
    PRIMARY KEY NONCLUSTERED ([UserId] ASC),
    CONSTRAINT [FK__Users_cop__Appli__0662F0A3] FOREIGN KEY ([ApplicationId]) REFERENCES [dbo].[Applications] ([ApplicationId])
);


GO
CREATE NONCLUSTERED INDEX [IX_Users_Firm_PCC]
    ON [dbo].[Users_copy]([Firm] DESC, [PCC] DESC);

