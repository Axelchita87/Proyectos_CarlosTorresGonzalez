CREATE TABLE [dbo].[Users] (
    [ApplicationId]          UNIQUEIDENTIFIER NOT NULL,
    [UserId]                 UNIQUEIDENTIFIER CONSTRAINT [DF__Users__UserId__0519C6AF] DEFAULT (newid()) NOT NULL,
    [UserName]               NVARCHAR (256)   COLLATE Modern_Spanish_CI_AS NOT NULL,
    [LoweredUserName]        NVARCHAR (256)   COLLATE Modern_Spanish_CI_AS NOT NULL,
    [UserMail]               NVARCHAR (50)    COLLATE Modern_Spanish_CI_AS CONSTRAINT [DF__Users__IsAnonymo__060DEAE8] DEFAULT ((0)) NULL,
    [LastActivityDate]       DATETIME         NULL,
    [Firm]                   NVARCHAR (50)    COLLATE Modern_Spanish_CI_AS NULL,
    [Password]               NVARCHAR (50)    COLLATE Modern_Spanish_CI_AS NULL,
    [FamilyName]             NVARCHAR (50)    COLLATE Modern_Spanish_CI_AS NULL,
    [Agent]                  NVARCHAR (50)    COLLATE Modern_Spanish_CI_AS NULL,
    [Queue]                  NVARCHAR (50)    COLLATE Modern_Spanish_CI_AS NULL,
    [PCC]                    NVARCHAR (50)    COLLATE Modern_Spanish_CI_AS NULL,
    [TA]                     NVARCHAR (50)    COLLATE Modern_Spanish_CI_AS NULL,
    [GDS]                    NVARCHAR (10)    NULL,
    [MyCTSVersion]           NVARCHAR (10)    NULL,
    [IsMySabreBlocked]       BIT              CONSTRAINT [DF_Users_IsMySabreBlocked] DEFAULT ((1)) NOT NULL,
    [ProfileAllAccess]       NVARCHAR (3)     NULL,
    [InstallFramework35]     BIT              CONSTRAINT [DF_Users_InstallFramework35] DEFAULT ((0)) NOT NULL,
    [IsFramework35Installed] BIT              CONSTRAINT [DF_Users_IsFramework35Installed] DEFAULT ((0)) NOT NULL,
    [ProductivityMail]       BIT              CONSTRAINT [DF_Users_ProductivityMail] DEFAULT ((0)) NOT NULL,
    [Supervisor]             BIT              NULL,
    [UpgradeStatus]          INT              CONSTRAINT [DF_Users_UpgradeStatus] DEFAULT ((2)) NULL,
    [AgentMail]              NVARCHAR (50)    NULL,
    [StatusFirm]             CHAR (1)         NULL,
    [DateIn]                 DATETIME         CONSTRAINT [DF_Users_DateIn] DEFAULT (getdate()) NULL,
    [DateOut]                DATETIME         NULL,
    CONSTRAINT [PK__Users__0425A276] PRIMARY KEY NONCLUSTERED ([UserId] ASC),
    CONSTRAINT [FK_Users_Applications] FOREIGN KEY ([ApplicationId]) REFERENCES [dbo].[Applications] ([ApplicationId])
);


GO
CREATE NONCLUSTERED INDEX [IX_Users_Firm_PCC]
    ON [dbo].[Users]([Firm] DESC, [PCC] DESC);

