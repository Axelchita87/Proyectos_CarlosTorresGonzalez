CREATE TABLE [dbo].[SabreMessages] (
    [ID]            INT            IDENTITY (1, 1) NOT NULL,
    [ModuleID]      INT            NOT NULL,
    [APIMessage]    NVARCHAR (300) NOT NULL,
    [UserMessage]   NVARCHAR (300) NOT NULL,
    [ShowControl]   BIT            CONSTRAINT [DF_SabreMessages_ShowControl] DEFAULT ((0)) NOT NULL,
    [IsConditional] BIT            CONSTRAINT [DF_SabreMessages_IsConditional] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_SabreMessages] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_SabreMessages_Modules] FOREIGN KEY ([ModuleID]) REFERENCES [dbo].[Modules] ([ModulesId]) ON UPDATE CASCADE
);

