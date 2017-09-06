


-- =============================================
-- Author:		Angel Trejo
-- Create date: 05-05-2010
-- Description:	Procedure that get logo by Airline code
-- =============================================
CREATE Procedure [dbo].[GetLogoAirline]
@IDAirline varchar(2)
AS
Begin
	select LogoAirLine
	from dbo.CatAirLinesFare
	where CatAirLinFarId=@IDAirline
End