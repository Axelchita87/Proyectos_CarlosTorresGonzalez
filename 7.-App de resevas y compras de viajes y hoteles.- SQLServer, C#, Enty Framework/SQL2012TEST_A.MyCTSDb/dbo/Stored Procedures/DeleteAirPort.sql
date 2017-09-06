



-- =============================================
-- Author:		<Jessica Gutierrez Becerril>
-- Creation date: 03-06-2010
-- Description:	Delete AirPort
-- Modify by: */
-- =============================================
CREATE PROCEDURE [dbo].[DeleteAirPort] 

@CatAirPorCode varchar(3)

AS
BEGIN
	delete dbo.CatCountries
	where CatCouId=(Select CatCitCouId from dbo.CatCities where CatCitId=@CatAirPorCode)

	delete dbo.CatCities
	where CatCitId=@CatAirPorCode 
	
END

