CREATE TABLE [dbo].[CusErrMsg] (
    [CusErrMsgId]            INT            NOT NULL,
    [CusErrMsgSabreErrMsgId] INT            NOT NULL,
    [CusErrMsgModuleId]      INT            NULL,
    [CusErrMsgUserMsg]       NVARCHAR (300) NULL,
    [CusErrMsgModuleSrc]     NVARCHAR (250) NULL,
    CONSTRAINT [PK_CusErrMsg] PRIMARY KEY CLUSTERED ([CusErrMsgId] ASC),
    CONSTRAINT [FK_CusErrMsg_SabreErrMsg1] FOREIGN KEY ([CusErrMsgSabreErrMsgId]) REFERENCES [dbo].[SabreErrMsg] ([SabreErrMsgId])
);

