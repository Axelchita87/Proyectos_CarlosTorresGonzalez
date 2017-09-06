



-- =============================================
-- Author:		<Jessica Gutierrez Becerril>
-- Creation date: <02-06-2010>
-- Description:	<Insert a AirLine in CatAirLinesFare>
-- =============================================
CREATE PROCEDURE [dbo].[SetAirPorts] 
	-- Input variables
	@CatAirPorCode varchar(3), 
	@CatAirPorName varchar(150),
	@CatAirPorCountryId varchar(2),
	@CatAirPorCountryName varchar(150)
AS
BEGIN
    -- Insert statements for procedure 
		INSERT INTO dbo.CatCities(CatCitId,CatCitName,CatCitCouId)
		VALUES(@CatAirPorCode,@CatAirPorName,@CatAirPorCountryId)

		INSERT INTO dbo.CatCountries(CatCouId,CatCouName)
		VALUES(@CatAirPorCountryId,@CatAirPorCountryName)
END

