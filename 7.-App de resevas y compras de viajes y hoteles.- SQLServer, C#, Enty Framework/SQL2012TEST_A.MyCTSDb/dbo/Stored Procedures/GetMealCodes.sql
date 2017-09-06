-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 16-04-2009
-- Description:	Procedure that gets a MealCodes collection
-- =============================================
CREATE Procedure [dbo].[GetMealCodes]
 @StrToSearch as varchar(10)
AS
 Declare @LenStrToSearch int
 set @LenStrToSearch = len(@StrToSearch)
Begin
-- If (@StrToSearch = 'All')
--	--Returns all catalogue
--	Begin
--		Select Distinct CatMeaCodCode, CatMeaCodALCode, CatMeaCodDescription
--		From dbo.CatMealCodes
--		Order By CatMeaCodDescription
--	End
 if(@LenStrToSearch < 3)--@LenStrToSearch = 1 or @LenStrToSearch = 2)
	  --Searching by ALCode, two chars
	  Begin
		Select Distinct CatMeaCodCode, CatMeaCodALCode, CatMeaCodDescription
		From dbo.CatMealCodes
		Where CatMeaCodALCode like @StrToSearch + '%'
		Order By CatMeaCodDescription
	  End
 else if(@LenStrToSearch = 4)
	  -- Searching By Meal Code, four chars
	  Begin
		Select Distinct CatMeaCodCode, CatMeaCodALCode, CatMeaCodDescription
		From dbo.CatMealCodes 
		Where CatMeaCodCode like @StrToSearch + '%' or CatMeaCodDescription like @StrToSearch + '%'
		Order By CatMeaCodDescription
	  End
 else --if(@LenStrToSearch > 4)
	  -- Searching By Description, > four chars
	  Begin
		Select Distinct CatMeaCodCode, CatMeaCodALCode, CatMeaCodDescription
		From dbo.CatMealCodes 
		Where CatMeaCodDescription like @StrToSearch + '%' or CatMeaCodDescription like @StrToSearch + '%'
		Order By CatMeaCodDescription
	  End
 End





