




-- =============================================
-- Author:		Angel Trejo Arizmendi
-- Create date: 14-07-2010
-- Description:	Procedure that update image to ticket printer
-- =============================================
CREATE Procedure [dbo].[UpdateBannerImageTicketPrinter]
@Content image
AS
Begin
	update dbo.BannerImages
	set [Content]=@Content
	where ImageId=7
End

