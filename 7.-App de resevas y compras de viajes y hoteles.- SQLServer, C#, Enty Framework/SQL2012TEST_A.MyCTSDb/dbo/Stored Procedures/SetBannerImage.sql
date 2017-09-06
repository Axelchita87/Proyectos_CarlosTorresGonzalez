


-- =============================================
-- Author:		Marcos Q. Ramirez
-- Create date: 22-04-2010
-- Description:	Procedure that set images files
-- =============================================
CREATE Procedure [dbo].[SetBannerImage]
 @Content image,
 @Name varchar(100),
 @Extension varchar(150),
 @Url varchar(150),
 @Activate varchar(3)
AS
Begin
	insert into dbo.BannerImages
	([Content]
	,[Name]
	,Extension
	,Url
	,Activate
	)
    values
	(@Content
	,@Name
	,@Extension
	,@Url
	,@Activate
	)
End