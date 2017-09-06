CREATE TABLE [dbo].[QueueCatalog] (
    [Queue]   NVARCHAR (50) NULL,
    [Asigned] BIT           NULL
);


GO
GRANT DELETE
    ON OBJECT::[dbo].[QueueCatalog] TO [miniUserMyCTS]
    WITH GRANT OPTION
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[QueueCatalog] TO [miniUserMyCTS]
    WITH GRANT OPTION
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[QueueCatalog] TO [miniUserMyCTS]
    WITH GRANT OPTION
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[QueueCatalog] TO [miniUserMyCTS]
    WITH GRANT OPTION
    AS [dbo];

