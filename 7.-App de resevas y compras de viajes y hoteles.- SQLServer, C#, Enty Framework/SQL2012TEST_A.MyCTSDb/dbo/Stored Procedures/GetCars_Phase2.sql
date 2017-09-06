-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 16-04-2009
-- Description:	Procedure that gets a Cars collection
-- =============================================
CREATE Procedure [dbo].[GetCars_Phase2]
 @StrToSearch as varchar(10)
AS
 Declare @LenStrToSearch int
 set @LenStrToSearch = len(@StrToSearch)
Begin
 if(@LenStrToSearch >= 1 and @LenStrToSearch <= 4)
	  --Searching by Code, two,three and four chars
	  Begin
		Select Distinct Code, Description
		From dbo.CatCars
		Where Code like @StrToSearch + '%'
	  End
 else if(@LenStrToSearch > 4)
	  -- Searching By Description, > four chars
	  Begin
		Select Distinct Code, Description
		From dbo.CatCars
		Where [Description] like @StrToSearch + '%' 
		Order By Description
	  End
 End




