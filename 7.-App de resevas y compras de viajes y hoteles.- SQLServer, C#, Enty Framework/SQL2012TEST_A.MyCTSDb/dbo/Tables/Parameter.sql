CREATE TABLE [dbo].[Parameter] (
    [ParameterName] NVARCHAR (100) NOT NULL,
    [Values]        NVARCHAR (500) NULL,
    [Description]   NVARCHAR (500) NULL,
    CONSTRAINT [PK_Parameter] PRIMARY KEY CLUSTERED ([ParameterName] ASC)
);

