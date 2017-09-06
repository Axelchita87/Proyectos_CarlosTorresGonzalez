-- =============================================
-- Author:		<Angel Trejo Arizmendi>
-- Creation date: 26-03-2010
-- Description:	Get Cat Car Vendor Code Name
-- Modify by: */
-- =============================================
CREATE PROCEDURE [dbo].[GetCatCarVenCodName] 

@Code varchar(2)

AS
BEGIN
	select CatCarVenCodName 
	from dbo.CatCarVendorsCodes
	where CatCarVenCodCode=@Code 
END