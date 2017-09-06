-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 16-04-2009
-- Description:	Procedure that gets a Currencies-Countries collection
-- =============================================
CREATE Procedure [dbo].[GetCurrenciesCountries]
 @StrToSearch as varchar(10)
AS
 Declare @LenStrToSearch int
 set @LenStrToSearch = len(@StrToSearch)
Begin
-- If (@StrToSearch = 'All')
--	Begin
--		Select Distinct CCC.CatCurCouCode, CCC.CatCurCouName, CC.CatCouName, CC.CatCouId
--		From dbo.CatCurrencyCountry CCC
--		Inner Join dbo.CatCountries CC On CC.CatCouId = CCC.CatCurCouId
--		Order By CCC.CatCurCouName
--	End
 if(@LenStrToSearch < 3)--@LenStrToSearch = 1 or @LenStrToSearch = 2)
	  --Searching by Country Code, two chars
	  Begin
		Select Distinct CCC.CatCurCouCode, CCC.CatCurCouName, CC.CatCouName, CC.CatCouId
		From dbo.CatCurrencyCountry CCC
		Inner Join dbo.CatCountries CC On CC.CatCouId = CCC.CatCurCouId
		Where CCC.CatCurCouCode like @StrToSearch + '%' --CatCurCouId
	  End
 else if(@LenStrToSearch = 3)-- and @StrToSearch <> 'All')
	  -- Searching By Currency Code and Currency Name, > three chars
	  Begin
		Select Distinct CCC.CatCurCouCode, CCC.CatCurCouName, CC.CatCouName, CC.CatCouId
		From dbo.CatCurrencyCountry CCC
		Inner Join dbo.CatCountries CC On CC.CatCouId = CCC.CatCurCouId
		Where CCC.CatCurCouCode = @StrToSearch or CCC.CatCurCouName like @StrToSearch + '%'
	  End
 else --if(@LenStrToSearch > 3)
	  -- Searching By AirLine Name, > three chars
	  Begin
		Select Distinct CCC.CatCurCouCode, CCC.CatCurCouName, CC.CatCouName, CC.CatCouId
		From dbo.CatCurrencyCountry CCC
		Inner Join dbo.CatCountries CC On CC.CatCouId = CCC.CatCurCouId
		Where CCC.CatCurCouName like @StrToSearch + '%' or CC.CatCouName like @StrToSearch + '%'
		Order By CCC.CatCurCouName
	  End
 End


