CREATE TABLE [dbo].[Qualities_Future] (
    [IDQuality] INT            NOT NULL,
    [Name]      VARCHAR (150)  NULL,
    [Type]      VARCHAR (10)   NULL,
    [Remark]    VARCHAR (150)  NULL,
    [Enabled]   BIT            NULL,
    [Condition] VARCHAR (255)  NULL,
    [Command]   VARCHAR (255)  NULL,
    [Formula]   VARCHAR (1000) NULL,
    [AccionID]  INT            NULL,
    CONSTRAINT [PK_Qualities] PRIMARY KEY CLUSTERED ([IDQuality] ASC)
);

