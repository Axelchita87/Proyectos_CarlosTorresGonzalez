CREATE TABLE [dbo].[Metadatas] (
    [IdMetadata]  INT           IDENTITY (1, 1) NOT NULL,
    [Metadata]    VARCHAR (50)  NOT NULL,
    [Type]        CHAR (1)      NOT NULL,
    [Value]       VARCHAR (50)  NULL,
    [Description] VARCHAR (100) NULL,
    CONSTRAINT [PK_Metadatas] PRIMARY KEY CLUSTERED ([IdMetadata] ASC)
);

