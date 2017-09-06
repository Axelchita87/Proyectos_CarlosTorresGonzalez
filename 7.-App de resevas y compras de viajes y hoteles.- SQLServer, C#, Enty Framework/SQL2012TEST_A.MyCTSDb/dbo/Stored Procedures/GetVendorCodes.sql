-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 15-06-2009
-- Description:	Procedure that gets a Vendor Codes collection
-- =============================================
CREATE Procedure [dbo].[GetVendorCodes]
 @StrToSearch as varchar(10)
AS
 Declare @LenStrToSearch int
 set @LenStrToSearch = len(@StrToSearch)
Begin
-- If (@StrToSearch = 'All')
--	Begin
--		Select Distinct [CatCarVenCodCode], [CatCarVenCodName]
--		From dbo.CatCarVendorsCodes
--		Order By [CatCarVenCodName]
--	End
 if(@LenStrToSearch < 3)--@LenStrToSearch >= 1 and @LenStrToSearch <= 2)
	  --Searching by Code, one and two chars
	  Begin
		Select Distinct [CatCarVenCodCode], [CatCarVenCodName]
		From dbo.CatCarVendorsCodes
		Where [CatCarVenCodCode] like @StrToSearch + '%' Or [CatCarVenCodName] like @StrToSearch + '%'
	  End
 else --if(@LenStrToSearch > 2 and @StrToSearch <> 'All')
	  -- Searching By Name, > two chars
	  Begin
		Select Distinct [CatCarVenCodCode], [CatCarVenCodName]
		From dbo.CatCarVendorsCodes
		Where [CatCarVenCodName] like @StrToSearch + '%'
	  End
 End
