
-- =============================================
-- Author:		Eduardo Sánchez Almazán
-- =============================================
CREATE Procedure [dbo].[GetCatalog_AirPortCityCountry_MIN]
AS
select CatCitId [Value] , 
(CatCitId + ' ' + RTRIM(CatCitName) + ' ' + RTRIM(CatCouId) + ' ' + RTRIM(CatCouName)) [Text],
'' [Text2], '' [Text3],'' [Text5],'' [Text6],'' [Text7],'' [Text8]  from
(
Select Distinct  City.CatCitId, City.CatCitName, Country.CatCouId, Country.CatCouName 
		from dbo.CatCities City 
		inner join dbo.CatCountries Country On Country.CatCouId = City.CatCitCouId				
) as AirPortCityCountry	
Order By CatCitName

