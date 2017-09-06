-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 16-04-2009
-- Description:	Procedure that gets a StatesUSA collection
-- =============================================
CREATE Procedure [dbo].[GetStatesUSA]
 @StrToSearch as varchar(10)
AS
 Declare @LenStrToSearch int
 set @LenStrToSearch = len(@StrToSearch)
Begin
-- If (@StrToSearch = 'All')
--	Begin
--		Select Distinct CatStaUSACode, CatStaUSAName
--		From dbo.CatStatesUSA
--		Order By CatStaUSAName
--	End
 if(@LenStrToSearch < 3)--@LenStrToSearch = 1 or @LenStrToSearch = 2)
	  --Searching by Code, two chars
	  Begin
		Select Distinct CatStaUSACode, CatStaUSAName 
		From dbo.CatStatesUSA
		Where CatStaUSACode like @StrToSearch + '%'
	  End
 else --if(@LenStrToSearch > 2 and @StrToSearch <> 'All')
	  -- Searching By Name, > two chars
	  Begin
		Select Distinct CatStaUSACode, CatStaUSAName 
		From dbo.CatStatesUSA
		Where CatStaUSAName like @StrToSearch + '%'
		Order By CatStaUSAName
	  End
 End





