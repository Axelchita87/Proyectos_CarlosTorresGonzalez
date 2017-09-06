CREATE TABLE [dbo].[TACatalog] (
    [Type]    NVARCHAR (255) NULL,
    [Pcc]     NVARCHAR (255) NULL,
    [TA]      NVARCHAR (255) NULL,
    [Asigned] BIT            NULL
);


GO
GRANT SELECT
    ON OBJECT::[dbo].[TACatalog] TO [miniUserMyCTS]
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[TACatalog] TO [miniUserMyCTS]
    AS [dbo];

