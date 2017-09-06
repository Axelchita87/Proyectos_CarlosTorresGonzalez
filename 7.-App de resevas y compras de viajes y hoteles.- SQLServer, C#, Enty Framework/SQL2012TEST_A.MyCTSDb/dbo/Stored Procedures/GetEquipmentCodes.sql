-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 15-06-2009
-- Description:	Procedure that gets an Equipment Codes collection
-- =============================================
CREATE Procedure [dbo].[GetEquipmentCodes]
 @StrToSearch as varchar(10)
AS
 Declare @LenStrToSearch int
 set @LenStrToSearch = len(@StrToSearch)
Begin
-- If (@StrToSearch = 'All')
--	Begin
--		Select Distinct [CatCarEquCodCode], [CatCarEquCodName]
--		From dbo.CatCarEquipmentCodes
--		Order By [CatCarEquCodName]
--	End
 if(@LenStrToSearch < 4)--@LenStrToSearch >= 1 and @LenStrToSearch <= 3 and @StrToSearch <> 'All')
	  --Searching by Code, one to three chars
	  Begin
		Select Distinct [CatCarEquCodCode], [CatCarEquCodName]
		From dbo.CatCarEquipmentCodes
		Where [CatCarEquCodCode] like @StrToSearch + '%' Or [CatCarEquCodName] like @StrToSearch + '%'
	  End
 else --if(@LenStrToSearch > 3)
	  -- Searching By Description, > three chars
	  Begin
		Select Distinct [CatCarEquCodCode], [CatCarEquCodName]
		From dbo.CatCarEquipmentCodes
		Where [CatCarEquCodName] like @StrToSearch + '%'
	  End
 End
