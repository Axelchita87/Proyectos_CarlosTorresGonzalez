




-- =============================================
-- Author:		<Jessica Gutierrez Becerril>
-- Creation date: 03-06-2010
-- Description:	Search AirPort
-- Modify by: */
-- =============================================
CREATE PROCEDURE [dbo].[GetAirPort] 

@CatAirPorCode varchar(3)

AS
BEGIN
	Select Ci.CatCitId,Ci.CatCitName,Co.CatCouId,Co.CatCouName
	from dbo.CatCities Ci ,dbo.CatCountries Co
	where  Ci.CatCitId=@CatAirPorCode and
		Ci.CatCitCouId=Co.CatCouId
END


