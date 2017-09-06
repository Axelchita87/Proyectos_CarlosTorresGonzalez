CREATE TABLE [dbo].[CommandsActions] (
    [ID]                 INT             IDENTITY (1, 1) NOT NULL,
    [Command]            NVARCHAR (1500) NULL,
    [UserControl]        INT             NULL,
    [Message]            NVARCHAR (250)  NULL,
    [CommandType]        NVARCHAR (5)    CONSTRAINT [DF_APICommands_CommandType] DEFAULT (N'MSG') NOT NULL,
    [Allow]              BIT             CONSTRAINT [DF_CommandsRestricted_Allow] DEFAULT ((0)) NOT NULL,
    [CommandsAllowed]    NVARCHAR (150)  NULL,
    [CommandsRestricted] NVARCHAR (150)  NULL,
    CONSTRAINT [PK_APICommands] PRIMARY KEY CLUSTERED ([ID] ASC)
);

