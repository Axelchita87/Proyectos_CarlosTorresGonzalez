CREATE TABLE [dbo].[ConMail] (
    [ID]               FLOAT (53)       NULL,
    [ApplicationId]    NVARCHAR (255)   NULL,
    [UserId]           UNIQUEIDENTIFIER NULL,
    [UserName]         NVARCHAR (255)   NULL,
    [LoweredUserName]  NVARCHAR (255)   NULL,
    [UserMail]         NVARCHAR (255)   NULL,
    [LastActivityDate] DATETIME         NULL,
    [Firm]             NVARCHAR (255)   NULL,
    [Password]         NVARCHAR (255)   NULL,
    [FamilyName]       NVARCHAR (255)   NULL,
    [Agent]            NVARCHAR (255)   NULL,
    [Queue]            FLOAT (53)       NULL,
    [PCC]              NVARCHAR (255)   NULL,
    [TA]               NVARCHAR (255)   NULL,
    [GDS]              NVARCHAR (255)   NULL
);

