CREATE TABLE [dbo].[SabreErrMsg] (
    [SabreErrMsgId]          INT            NOT NULL,
    [SabreErrMsgCommandName] NVARCHAR (300) NULL,
    CONSTRAINT [PK_SabreErrMsg] PRIMARY KEY CLUSTERED ([SabreErrMsgId] ASC)
);

