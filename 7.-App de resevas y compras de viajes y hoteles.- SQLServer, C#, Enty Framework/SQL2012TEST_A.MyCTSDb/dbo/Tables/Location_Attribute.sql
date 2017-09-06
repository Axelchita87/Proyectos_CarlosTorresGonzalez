CREATE TABLE [dbo].[Location_Attribute] (
    [Location]    VARCHAR (50) NULL,
    [Attribute1]  VARCHAR (50) NULL,
    [Status]      VARCHAR (3)  NULL,
    [Status_Site] VARCHAR (3)  NULL
);


GO
CREATE NONCLUSTERED INDEX [IDX_ByLoc]
    ON [dbo].[Location_Attribute]([Location] ASC, [Attribute1] ASC);

