



-- =============================================
-- Author:		<Ivan Martínez Guerrero>
-- Creation date: 08-Julio-2011
-- Description:	Search Credit Card Number in INTEGRA
-- Modify by: */
-- =============================================
CREATE PROCEDURE [dbo].[GetCountryByCity] 

@city varchar(30)

AS
BEGIN
	SELECT CatCitCouId FROM dbo.CatCities
	WHERE CatCitId = @city
END