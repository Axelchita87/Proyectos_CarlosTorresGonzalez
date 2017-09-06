-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 16-04-2009
-- Description:	Procedure that gets a SeaVendorsCodes collection
-- =============================================
CREATE Procedure [dbo].[GetSeaVendorsCodes]
 @StrToSearch as varchar(10)
AS
 Declare @LenStrToSearch int
 set @LenStrToSearch = len(@StrToSearch)
Begin
-- If (@StrToSearch = 'All')
--	Begin
--		Select Distinct CatSeaVenCodCode, CatSeaVenCodName
--		From dbo.CatSeaVendorsCodes
--		Order By CatSeaVenCodName
--	End
 if(@LenStrToSearch < 3)--@LenStrToSearch = 1 or @LenStrToSearch = 2)
	  --Searching by Code, two chars
	  Begin
		Select Distinct CatSeaVenCodCode, CatSeaVenCodName
		From dbo.CatSeaVendorsCodes
		Where CatSeaVenCodCode like @StrToSearch + '%'
	  End
 else --if(@LenStrToSearch > 2 and @StrToSearch <> 'All')
	  -- Searching By Name, > two chars
	  Begin
		Select Distinct CatSeaVenCodCode, CatSeaVenCodName
		From dbo.CatSeaVendorsCodes
		Where CatSeaVenCodName like @StrToSearch + '%'
		Order By CatSeaVenCodName
	  End
 End





