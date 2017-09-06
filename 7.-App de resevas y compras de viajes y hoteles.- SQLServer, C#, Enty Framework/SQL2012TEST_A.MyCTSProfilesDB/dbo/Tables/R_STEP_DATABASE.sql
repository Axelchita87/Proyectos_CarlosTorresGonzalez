﻿CREATE TABLE [dbo].[R_STEP_DATABASE] (
    [ID_TRANSFORMATION] INT NULL,
    [ID_STEP]           INT NULL,
    [ID_DATABASE]       INT NULL
);


GO
CREATE NONCLUSTERED INDEX [IDX_R_STEP_DATABASE_LU1]
    ON [dbo].[R_STEP_DATABASE]([ID_TRANSFORMATION] ASC);


GO
CREATE NONCLUSTERED INDEX [IDX_R_STEP_DATABASE_LU2]
    ON [dbo].[R_STEP_DATABASE]([ID_DATABASE] ASC);
