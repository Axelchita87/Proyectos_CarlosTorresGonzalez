-- =============================================
-- Author:		Eduardo Sánchez Almazán
-- =============================================
CREATE Procedure [dbo].[GetCatalog_AirPortCityCountry_MAJ]
AS
select CatCitId [Value] , 
(CatCitId + ' ' + CatCitName + ' ' + CatCouId + ' ' + CatCouName) [Text],
CatCitName [Text2], CatCouName [Text3],'' [Text5],'' [Text6],'' [Text7],'' [Text8]  from
(
Select Distinct  City.CatCitId, RTRIM(City.CatCitName) CatCitName, 
				 RTRIM(Country.CatCouId) CatCouId, RTRIM(Country.CatCouName) CatCouName
		from dbo.CatCities City 
		inner join dbo.CatCountries Country On Country.CatCouId = City.CatCitCouId				
) as AirPortCityCountry	
Order By CatCitName
