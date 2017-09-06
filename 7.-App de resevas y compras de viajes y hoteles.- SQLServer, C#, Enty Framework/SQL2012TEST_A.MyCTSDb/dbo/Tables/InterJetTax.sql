CREATE TABLE [dbo].[InterJetTax] (
    [DepartureStation] VARCHAR (50) NOT NULL,
    [IVA]              VARCHAR (50) NOT NULL,
    [TUA]              VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_InterJetTax] PRIMARY KEY CLUSTERED ([DepartureStation] ASC)
);

