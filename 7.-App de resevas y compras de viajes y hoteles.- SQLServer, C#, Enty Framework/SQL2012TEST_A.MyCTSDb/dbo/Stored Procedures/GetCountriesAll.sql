-- =============================================
-- Author:		<Ivan Martínez Guerrero>
-- Creation date: 08-Julio-2011
-- Description:	Search Credit Card Number in INTEGRA
-- Modify by: */
-- =============================================
create PROCEDURE [dbo].[GetCountriesAll] 
AS
BEGIN
	SELECT CatCouName,CatCouId FROM dbo.CatCountries 
END