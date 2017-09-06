-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 16-04-2009
-- Description:	Procedure that gets a Countries collection
-- =============================================
CREATE Procedure [dbo].[GetCountries]
 @StrToSearch as varchar(10)
AS
 Declare @LenStrToSearch int
 set @LenStrToSearch = len(@StrToSearch)
Begin
-- If (@StrToSearch = 'All')
--	Begin
--		Select Distinct CatCouId, CatCouName
--		From dbo.CatCountries
--		Order By CatCouName
--	End
 if(@LenStrToSearch < 3)--@LenStrToSearch = 1 or @LenStrToSearch = 2)
	  --Searching by Id, two chars
	  Begin
		Select Distinct CatCouId, CatCouName
		From dbo.CatCountries
		Where CatCouId like @StrToSearch + '%'
	  End
 else --if(@LenStrToSearch > 2 and @StrToSearch <> 'All')
	  -- Searching By Name, > two chars
	  Begin
		Select Distinct CatCouId, CatCouName
		From dbo.CatCountries
		Where CatCouName like @StrToSearch + '%'
		Order By CatCouName
	  End
 End



