-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 16-04-2009
-- Description:	Procedure that gets a BusCodes collection
-- =============================================
CREATE Procedure [dbo].[GetBusCodes]
 @StrToSearch as varchar(10)
AS
 Declare @LenStrToSearch int
 set @LenStrToSearch = len(@StrToSearch)
Begin
-- If (@StrToSearch = 'All')
--	Begin
--		Select Distinct CatBusCodCode, CatBusCodName
--		From dbo.CatBusCodes
--		Order By CatBusCodName
--	End
if(@LenStrToSearch < 3)--@LenStrToSearch = 1 or @LenStrToSearch = 2)
	  --Searching by CatBusCodCode, two chars
	  Begin
		Select Distinct CatBusCodCode, CatBusCodName
		From dbo.CatBusCodes
		Where CatBusCodCode like @StrToSearch + '%'
	  End
 else --@LenStrToSearch > 2 and @StrToSearch <> 'All')
	  -- Searching By CatBusCodName, > two chars
	  Begin
		Select Distinct CatBusCodCode, CatBusCodName
		From dbo.CatBusCodes
		Where CatBusCodName like @StrToSearch + '%' 
		Order By CatBusCodName
	  End
 End



