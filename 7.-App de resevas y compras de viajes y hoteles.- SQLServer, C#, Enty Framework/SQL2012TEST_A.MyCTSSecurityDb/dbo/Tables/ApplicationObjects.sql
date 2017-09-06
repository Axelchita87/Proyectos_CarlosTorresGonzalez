CREATE TABLE [dbo].[ApplicationObjects] (
    [ID]        INT            IDENTITY (1, 1) NOT NULL,
    [Text]      VARCHAR (150)  NOT NULL,
    [Name]      VARCHAR (250)  NULL,
    [EventName] VARCHAR (100)  NULL,
    [Roles]     VARCHAR (200)  NULL,
    [ParentID]  INT            NOT NULL,
    [ShortCut]  NVARCHAR (100) NULL,
    [ImageName] NVARCHAR (100) NULL,
    [Checked]   TINYINT        CONSTRAINT [DF_ApplicationObjects_Checked] DEFAULT ((0)) NOT NULL,
    [Order]     INT            NULL
);

