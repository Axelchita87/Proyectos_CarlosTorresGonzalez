-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 16-04-2009
-- Description:	Procedure that gets a Cities collection
-- =============================================
CREATE Procedure [dbo].[GetCities]
 @StrToSearch as varchar(10)
AS
 Declare @LenStrToSearch int
 set @LenStrToSearch = len(@StrToSearch)
Begin
-- If (@StrToSearch = 'All')
--	Begin
--		Select Distinct CatCitId, CatCitName
--		From dbo.CatCities
--		Order By CatCitName
--	End
 if(@LenStrToSearch < 4)--@LenStrToSearch >= 1 and @LenStrToSearch <= 3 and @StrToSearch <> 'All')
	  --Searching by City Code, three chars
	  Begin
		Select Distinct CatCitId, CatCitName
		From dbo.CatCities
		Where CatCitId like @StrToSearch + '%'
	  End
 else --if(@LenStrToSearch > 3)
	  -- Searching by CatCitName, > three chars
	  Begin
		Select Distinct CatCitId, CatCitName
		From dbo.CatCities
		Where CatCitName like @StrToSearch + '%'
		Order By CatCitName
	  End
 End
