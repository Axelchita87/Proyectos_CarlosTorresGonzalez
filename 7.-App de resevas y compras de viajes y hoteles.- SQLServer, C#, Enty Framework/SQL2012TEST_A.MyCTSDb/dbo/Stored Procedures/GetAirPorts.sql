




-- =============================================
-- Author:		<Jessica Gutierrez Becerril>
-- Creation date: <03-06-2010>
-- Description:	<Extract information AirPort 
-- by Code AirPort or Code Country>
-- =============================================
CREATE PROCEDURE [dbo].[GetAirPorts] 
	@StrToSearch as varchar(3)
AS
 Declare @LenStrToSearch int
 set @LenStrToSearch = len(@StrToSearch)
Begin
 If (@LenStrToSearch = 3)
	Begin
		Select Distinct  City.CatCitId, City.CatCitName, Country.CatCouId, Country.CatCouName 
		from dbo.CatCities City 
		inner join dbo.CatCountries Country On Country.CatCouId = City.CatCitCouId
		where City.CatCitId=@StrToSearch
	End
 Else if(@LenStrToSearch = 2)
	  Begin
		Select Distinct  City.CatCitId, City.CatCitName, Country.CatCouId, Country.CatCouName 
		from dbo.CatCities City 
		inner join dbo.CatCountries Country On Country.CatCouId = City.CatCitCouId
		where Country.CatCouId = @StrToSearch 
	  End
End



