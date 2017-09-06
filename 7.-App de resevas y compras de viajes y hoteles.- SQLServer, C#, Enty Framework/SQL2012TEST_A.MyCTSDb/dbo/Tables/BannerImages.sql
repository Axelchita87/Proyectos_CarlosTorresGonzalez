CREATE TABLE [dbo].[BannerImages] (
    [ImageId]   INT           IDENTITY (1, 1) NOT NULL,
    [Content]   IMAGE         NULL,
    [Name]      VARCHAR (100) COLLATE Latin1_General_CI_AI NULL,
    [Extension] VARCHAR (50)  COLLATE Latin1_General_CI_AI NULL,
    [Url]       VARCHAR (150) COLLATE Latin1_General_CI_AI NULL,
    [Activate]  VARCHAR (3)   COLLATE Latin1_General_CI_AI NOT NULL
);

