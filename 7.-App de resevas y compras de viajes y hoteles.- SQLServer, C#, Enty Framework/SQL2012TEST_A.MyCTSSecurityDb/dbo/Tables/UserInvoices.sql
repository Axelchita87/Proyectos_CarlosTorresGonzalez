CREATE TABLE [dbo].[UserInvoices] (
    [UserMail]     NVARCHAR (50)  NOT NULL,
    [Password]     NVARCHAR (50)  NOT NULL,
    [OrgId]        INT            NOT NULL,
    [CreationDate] DATETIME       NOT NULL,
    [Status]       BIT            NOT NULL,
    [FamilyName]   NVARCHAR (100) NOT NULL,
    CONSTRAINT [IX_UserInvoices] UNIQUE NONCLUSTERED ([UserMail] ASC)
);

