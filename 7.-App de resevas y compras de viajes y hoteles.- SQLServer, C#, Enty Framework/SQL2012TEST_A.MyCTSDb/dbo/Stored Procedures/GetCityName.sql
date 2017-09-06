CREATE PROCEDURE [dbo].[GetCityName]
@cityCode as varchar(5)
AS
BEGIN

select * from CatCities
where CatCitId = @cityCode
END
