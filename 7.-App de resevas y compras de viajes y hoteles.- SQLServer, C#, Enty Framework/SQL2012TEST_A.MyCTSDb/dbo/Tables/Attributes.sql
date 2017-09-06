CREATE TABLE [dbo].[Attributes] (
    [ID]          INT           IDENTITY (1, 1) NOT NULL,
    [Attribute1]  VARCHAR (50)  NULL,
    [NameMyCTS]   VARCHAR (150) NULL,
    [StatID]      INT           NULL,
    [Class]       VARCHAR (50)  NULL,
    [Queue]       VARCHAR (50)  NULL,
    [Queue2]      VARCHAR (50)  NULL,
    [Reservation] BIT           CONSTRAINT [DF_Attributes_Reservation] DEFAULT ((1)) NULL,
    [Emision]     BIT           CONSTRAINT [DF_Attributes_Emision] DEFAULT ((1)) NULL,
    [Modified]    DATETIME      NULL,
    [Enabled]     BIT           NULL,
    [OrgId]       INT           NULL,
    CONSTRAINT [PK_Attributes] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Attributes]
    ON [dbo].[Attributes]([Attribute1] ASC);

