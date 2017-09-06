-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 16-04-2009
-- Description:	Procedure that gets an AirLines collection
-- =============================================
CREATE Procedure [dbo].[GetAirLines]
 @StrToSearch as varchar(10)
AS
 Declare @LenStrToSearch int
 set @LenStrToSearch = len(@StrToSearch)
Begin
-- If (@StrToSearch = 'All')
--	Begin
--		Select Distinct CatAirLinAlfaId, CatAirLinName
--		From  dbo.CatAirLines
--		Order By CatAirLinName
--	End
 if(@LenStrToSearch <= 2)
	  --Searching by AirLineAlfaId, two chars
	  Begin
		Select Distinct CatAirLinAlfaId, CatAirLinName
		From  dbo.CatAirLines
		Where CatAirLinAlfaId like @StrToSearch + '%'
	  End
 else if(@LenStrToSearch > 2)
	  -- Searching By AirLineName, > two chars
	  Begin
		Select Distinct CatAirLinAlfaId, CatAirLinName
		From  dbo.CatAirLines
		Where CatAirLinName like @StrToSearch + '%' 
		Order By CatAirLinName
	  End
 End


