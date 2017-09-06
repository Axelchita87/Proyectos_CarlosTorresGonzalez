CREATE TABLE [dbo].[DetailStars] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [FieldName]     NVARCHAR (1000) NULL,
    [OrderNum]      INT             NULL,
    [Level]         INT             NULL,
    [Visible]       BIT             NULL,
    [Observaciones] NVARCHAR (200)  NULL,
    CONSTRAINT [PK_DetailStars] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_DetailStars_DetailStars] FOREIGN KEY ([Id]) REFERENCES [dbo].[DetailStars] ([Id])
);

