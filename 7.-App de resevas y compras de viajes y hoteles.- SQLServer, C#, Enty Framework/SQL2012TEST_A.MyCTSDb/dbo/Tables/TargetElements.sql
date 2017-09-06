CREATE TABLE [dbo].[TargetElements] (
    [IDTE]        INT           NOT NULL,
    [Target]      VARCHAR (50)  NULL,
    [Description] VARCHAR (150) NULL,
    CONSTRAINT [PK_TargetElements] PRIMARY KEY CLUSTERED ([IDTE] ASC)
);

