CREATE TABLE [dbo].[LabelsRemarks] (
    [IDRemarkLabel]   VARCHAR (50)  NOT NULL,
    [Command]         VARCHAR (50)  NULL,
    [LabelCommand]    VARCHAR (150) NULL,
    [CommandERP]      VARCHAR (50)  NULL,
    [LabelCommandERP] VARCHAR (150) NULL,
    [Description]     VARCHAR (100) NULL,
    CONSTRAINT [PK_Remarks] PRIMARY KEY CLUSTERED ([IDRemarkLabel] ASC)
);

