


-- =============================================
-- Author:		Angel Trejo
-- Create date: 05-05-2010
-- Description:	Procedure that set logo's airlines
-- =============================================
CREATE Procedure [dbo].[SetLogoAirline]
 @LogoAirline image,
 @IDAirline varchar(2)

AS
Begin
	update dbo.CatAirLinesFare
	set LogoAirLine=@LogoAirline
	where CatAirLinFarId=@IDAirline
End
