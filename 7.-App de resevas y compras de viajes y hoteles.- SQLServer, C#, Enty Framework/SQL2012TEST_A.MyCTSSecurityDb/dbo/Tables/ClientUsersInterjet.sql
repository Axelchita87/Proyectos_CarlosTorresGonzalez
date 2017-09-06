CREATE TABLE [dbo].[ClientUsersInterjet] (
    [Id]           INT           NOT NULL,
    [Users]        NVARCHAR (50) NOT NULL,
    [FareType]     CHAR (10)     NOT NULL,
    [Company]      NVARCHAR (50) NOT NULL,
    [Password]     NVARCHAR (50) NULL,
    [NumberPurse]  NVARCHAR (50) NULL,
    [SpecialRates] BIT           NULL
);

