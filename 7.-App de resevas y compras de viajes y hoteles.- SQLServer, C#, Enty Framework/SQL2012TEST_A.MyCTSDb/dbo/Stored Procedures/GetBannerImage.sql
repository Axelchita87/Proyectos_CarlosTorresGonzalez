


-- =============================================
-- Author:		Marcos Q. Ramirez
-- Create date: 22-04-2010
-- Description:	Procedure that get images files
-- =============================================
CREATE Procedure [dbo].[GetBannerImage]
@ControlIndex varchar(3)
AS
Begin
	select [Content], [Name], Extension, Url, Activate
	from dbo.BannerImages
	where Activate = @ControlIndex
	order by ImageID
End

