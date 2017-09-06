CREATE TABLE [dbo].[InterJetPointToPoint] (
    [ID]        INT          NOT NULL,
    [PointTo]   VARCHAR (50) NOT NULL,
    [PointFrom] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_InterJetPointToPoint] PRIMARY KEY CLUSTERED ([ID] ASC)
);

