-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 17-04-2009
-- Description:	Procedure that gets a StatusCode collection
-- =============================================
CREATE Procedure [dbo].[GetStatusCodes]
 @StrToSearch as varchar(10)
AS
 Declare @LenStrToSearch int
 set @LenStrToSearch = len(@StrToSearch)
Begin
-- If (@StrToSearch = 'All')
--	Begin
--		Select Distinct CatStaCodCode, CatStaCodDescription
--		From dbo.CatStatusCodes
--		Order By CatStaCodDescription
--	End
 if(@LenStrToSearch < 3)--@LenStrToSearch = 1 or @LenStrToSearch = 2)
	  --Searching by Code, two chars
	  Begin
		Select Distinct CatStaCodCode, CatStaCodDescription
		From dbo.CatStatusCodes
		Where CatStaCodCode like @StrToSearch + '%'
	  End
 else --if(@LenStrToSearch > 2 and @StrToSearch <> 'All')
	  -- Searching By Description, > two chars
	  Begin
		Select Distinct CatStaCodCode, CatStaCodDescription
		From dbo.CatStatusCodes
		Where CatStaCodDescription like @StrToSearch + '%' 
		Order By CatStaCodDescription
	  End
 End

