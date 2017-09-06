CREATE TABLE [dbo].[DocsSecondLevel] (
    [ImageId]    BIGINT          IDENTITY (1, 1) NOT NULL,
    [ProfileId]  BIGINT          NOT NULL,
    [FieldKey]   INT             NULL,
    [DocName]    NVARCHAR (50)   NULL,
    [Name]       NVARCHAR (50)   NOT NULL,
    [Image]      VARBINARY (MAX) NOT NULL,
    [InsertDate] SMALLDATETIME   NULL,
    [UpdateDate] SMALLDATETIME   NULL,
    [DeleteDate] SMALLDATETIME   NULL,
    [Enable]     BIT             NOT NULL,
    CONSTRAINT [PK__Document__7516F70C93AD1E2B] PRIMARY KEY CLUSTERED ([ImageId] ASC)
);

