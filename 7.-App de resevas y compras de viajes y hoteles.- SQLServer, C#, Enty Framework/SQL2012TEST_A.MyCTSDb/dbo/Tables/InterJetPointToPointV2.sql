CREATE TABLE [dbo].[InterJetPointToPointV2] (
    [ID]              INT          NOT NULL,
    [To]              VARCHAR (50) NOT NULL,
    [From]            VARCHAR (50) NOT NULL,
    [IsInternational] BIT          NULL,
    CONSTRAINT [PK_InterJetPointToPointV2] PRIMARY KEY CLUSTERED ([ID] ASC)
);

