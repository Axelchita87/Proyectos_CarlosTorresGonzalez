
-- =============================================
-- Author:		Eduardo Sánchez Almazán
-- Create date: 30-06-2009
-- Description:	Procedure that gets an Airport,Cities, Country collection
-- =============================================
CREATE Procedure [dbo].[GetAirPortCityCountry_Predictive]
 @StrToSearch as varchar(10)
AS
 Declare @LenStrToSearch int
 set @LenStrToSearch = len(@StrToSearch)
Begin
  If (@LenStrToSearch < 4)
	  --Searching by AirPort Code
	  Begin
		Select Distinct  City.CatCitId, City.CatCitName, Country.CatCouId, Country.CatCouName 
		from dbo.CatCities City 
		inner join dbo.CatCountries Country On Country.CatCouId = City.CatCitCouId
		where City.CatCitId like @StrToSearch + '%'
		Order By City.CatCitName
	  End
 else if(@LenStrToSearch >= 4)
	  --Searching by City Name and country, five or more chars
		Select Distinct  City.CatCitId, City.CatCitName, Country.CatCouId, Country.CatCouName 
		from dbo.CatCities City 
		inner join dbo.CatCountries Country On Country.CatCouId = City.CatCitCouId
		where City.CatCitName like @StrToSearch + '%' or Country.CatCouName like @StrToSearch+'%'
		Order By City.CatCitName
End





