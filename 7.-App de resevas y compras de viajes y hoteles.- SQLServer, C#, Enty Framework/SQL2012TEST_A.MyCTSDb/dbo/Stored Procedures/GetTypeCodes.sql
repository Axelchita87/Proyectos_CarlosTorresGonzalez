-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 15-06-2009
-- Description:	Procedure that gets a Type Codes collection
-- =============================================
CREATE Procedure [dbo].[GetTypeCodes]
 @StrToSearch as varchar(10)
AS
 Declare @LenStrToSearch int
 set @LenStrToSearch = len(@StrToSearch)
Begin
-- If (@StrToSearch = 'All')
--	Begin
--		Select Distinct [CatCarTypCodCode], [CatCarTypCodDescription]
--		From dbo.CatCarTypesCodes
--		Order By [CatCarTypCodDescription]
--	End
 if(@LenStrToSearch <5)--@LenStrToSearch >= 1 and @LenStrToSearch <= 4 and @StrToSearch <> 'All')
	  --Searching by Code, one to four chars
	  Begin
		Select Distinct [CatCarTypCodCode], [CatCarTypCodDescription]
		From dbo.CatCarTypesCodes
		Where [CatCarTypCodCode] like @StrToSearch + '%' Or [CatCarTypCodDescription] like @StrToSearch + '%'
	  End
 else --if(@LenStrToSearch > 4)
	  -- Searching By Description, > two chars
	  Begin
		Select Distinct [CatCarTypCodCode], [CatCarTypCodDescription]
		From dbo.CatCarTypesCodes
		Where [CatCarTypCodDescription] like @StrToSearch + '%'
	  End
 End
