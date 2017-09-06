




-- =============================================
-- Author:		<Jessica Gutierrez Becerril>
-- Creation date: 03-06-2010
-- Description:	Update AirPort
-- Modify by: */
-- =============================================
CREATE PROCEDURE [dbo].[UpdateAirPort] 

	@CatAirPorCode varchar(3), 
	@CatAirPorName varchar(150),
	@CatAirPorCountryId varchar(2),
	@CatAirPorCountryName varchar(150)

AS
BEGIN
	update  dbo.CatCities
	set CatCitName=@CatAirPorName,CatCitCouId=@CatAirPorCountryId
	where CatCitId=@CatAirPorCode 

	update dbo.CatCountries
	set CatCouName=@CatAirPorCountryName
	where CatCouId=@CatAirPorCountryId
END

