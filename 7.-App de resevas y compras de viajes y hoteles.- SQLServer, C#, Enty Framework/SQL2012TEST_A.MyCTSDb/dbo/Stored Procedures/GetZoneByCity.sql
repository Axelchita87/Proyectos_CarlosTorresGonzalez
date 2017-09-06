

-- =============================================
-- Author:		<Ivan Martínez Guerrero>
-- Creation date: 18-Agosto-2011
-- Description:	Get a Zone by the City
-- Modify by: */
-- =============================================
CREATE PROCEDURE [dbo].[GetZoneByCity] 

@City varchar(30)

AS
BEGIN
	Select Z.CatZoneId   From dbo.CatZones Z
	inner join dbo.CatCountries C on C.CatZoneId = Z.CatZoneId
	inner join dbo.CatCities Ci on C.CatCouId = CatCitCouId
	Where CatCitId=@City
END
