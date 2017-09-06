-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 16-04-2009
-- Description:	Procedure that gets a Hotels collection
-- =============================================
CREATE Procedure [dbo].[GetHotels]
 @StrToSearch as varchar(10)
AS
 Declare @LenStrToSearch int
 set @LenStrToSearch = len(@StrToSearch)
Begin
-- If (@StrToSearch = 'All')
--	Begin
--		Select Distinct CatHotCode, CatHotNameChain
--		From dbo.CatHotels
--		Order By CatHotNameChain
--	End
 if(@LenStrToSearch < 3)--@LenStrToSearch = 1 or @LenStrToSearch = 2)
	  --Searching by Code, two chars
	  Begin
		Select Distinct CatHotCode, CatHotNameChain
		From dbo.CatHotels
		Where CatHotCode like @StrToSearch + '%'
	  End
 else --if(@LenStrToSearch > 2 and @StrToSearch <> 'All')
	  -- Searching By Name, > two chars
	  Begin
		Select Distinct CatHotCode, CatHotNameChain
		From dbo.CatHotels
		Where CatHotNameChain like @StrToSearch + '%'
		Order By CatHotNameChain
	  End
 End