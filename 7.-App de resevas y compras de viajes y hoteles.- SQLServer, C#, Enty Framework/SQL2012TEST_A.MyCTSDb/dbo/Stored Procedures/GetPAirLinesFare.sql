-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 22-05-2009
-- Description:	Procedure that gets an AirLinesFare collection
-- =============================================
CREATE Procedure [dbo].[GetPAirLinesFare]
 @StrToSearch as varchar(50)
AS
 Declare @LenStrToSearch int
 set @LenStrToSearch = len(@StrToSearch)
Begin
 if(@LenStrToSearch < 3)--@LenStrToSearch = 1 or @LenStrToSearch = 2)
	  --Searching by Code, two chars
	  Begin
		Select Distinct CatAirLinFarId,CatAirLinFarName
		From dbo.CatAirLinesFare
		Where CatAirLinFarId like @StrToSearch + '%'
		Order By CatAirLinFarId
	  End
 else --if(@LenStrToSearch > 2)
	  -- Searching By Name, > two chars
	  Begin
		Select Distinct CatAirLinFarId,CatAirLinFarName
		From dbo.CatAirLinesFare
		Where CatAirLinFarName like @StrToSearch + '%'
		Order By CatAirLinFarName
	  End
 End
