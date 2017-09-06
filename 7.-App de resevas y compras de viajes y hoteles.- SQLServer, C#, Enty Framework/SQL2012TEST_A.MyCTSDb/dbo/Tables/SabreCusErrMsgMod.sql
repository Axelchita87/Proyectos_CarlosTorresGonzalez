CREATE TABLE [dbo].[SabreCusErrMsgMod] (
    [SabreCusErrMsgModId]          INT IDENTITY (1, 1) NOT NULL,
    [SabreCusErrMsgModCusErrMsgId] INT NOT NULL,
    [SabreCusErrMsgModModulesId]   INT NOT NULL,
    [SabreCusErrMsgModShowModule]  INT NULL
);

