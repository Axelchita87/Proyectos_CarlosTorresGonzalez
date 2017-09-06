﻿CREATE TABLE [dbo].[R_DIRECTORY] (
    [ID_DIRECTORY]        BIGINT        NOT NULL,
    [ID_DIRECTORY_PARENT] INT           NULL,
    [DIRECTORY_NAME]      VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([ID_DIRECTORY] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_R_DIRECTORY_AK]
    ON [dbo].[R_DIRECTORY]([ID_DIRECTORY_PARENT] ASC, [DIRECTORY_NAME] ASC);
