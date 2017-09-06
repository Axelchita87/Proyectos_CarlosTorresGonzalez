CREATE TABLE [dbo].[Profile] (
    [UserId]               UNIQUEIDENTIFIER NOT NULL,
    [PropertyNames]        NTEXT            COLLATE Modern_Spanish_CI_AS NOT NULL,
    [PropertyValuesString] NTEXT            COLLATE Modern_Spanish_CI_AS NULL,
    [PropertyValuesBinary] IMAGE            NULL,
    [LastUpdatedDate]      DATETIME         NULL,
    CONSTRAINT [PK__Profile__0E6E26BF] PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [FK_Profile_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId])
);

