CREATE TABLE [dbo].[VolarisPointToPointV2] (
    [ID]              INT           IDENTITY (1, 1) NOT NULL,
    [To]              NVARCHAR (50) NOT NULL,
    [From]            NVARCHAR (50) NOT NULL,
    [IsInternational] BIT           NULL,
    CONSTRAINT [PK_VolarisPointToPointV2] PRIMARY KEY CLUSTERED ([ID] ASC)
);

