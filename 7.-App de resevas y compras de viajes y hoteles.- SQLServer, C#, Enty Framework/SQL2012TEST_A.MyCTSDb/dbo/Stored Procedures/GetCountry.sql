



-- =============================================
-- Author:		<Ivan Martínez Guerrero>
-- Creation date: 08-Julio-2011
-- Description:	Search Credit Card Number in INTEGRA
-- Modify by: */
-- =============================================
CREATE PROCEDURE [dbo].[GetCountry] 

@Country varchar(30)

AS
BEGIN
	SELECT CatCouName FROM dbo.CatCountries
	WHERE CatCouName = @Country
END
