-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 16-04-2009
-- Description:	Procedure that gets an AirLineClasses collection
-- =============================================
CREATE Procedure [dbo].[GetAirLinesClasses]
 @StrToSearch as varchar(10)
AS
 Declare @LenStrToSearch int
 set @LenStrToSearch = len(@StrToSearch)
Begin
-- If (@StrToSearch = 'All')
--	Begin
--		Select Distinct CatAirLinClaId, CatAirLinClaName
--		From dbo.CatAirLinesClass
--		Order By CatAirLinClaName
--	End
 if(@LenStrToSearch = 1)
	  --Searching by Id, one char
	  Begin
		Select Distinct CatAirLinClaId, CatAirLinClaName
		From dbo.CatAirLinesClass
		Where CatAirLinClaId = @StrToSearch
	  End
 else --if(@LenStrToSearch > 1 and @StrToSearch <> 'All')
	  -- Searching By Name, > one char
	  Begin
		Select Distinct CatAirLinClaId, CatAirLinClaName
		From dbo.CatAirLinesClass
		Where CatAirLinClaName like @StrToSearch + '%'
		Order By CatAirLinClaName
	  End
 End



