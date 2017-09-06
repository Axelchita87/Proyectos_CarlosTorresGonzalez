
-- =============================================
-- Author:		Eduardo Sánchez Almazán
-- Create date: 30-06-2009
-- Description:	Procedure that gets an AirLines collection
-- =============================================
CREATE Procedure [dbo].[GetAirLines_Predictive]
 @StrToSearch as varchar(10)
AS
 Declare @LenStrToSearch int
 set @LenStrToSearch = len(@StrToSearch)
Begin
 If (@StrToSearch = '*')
	Begin
		Select Distinct top 150 CatAirLinAlfaId, CatAirLinName
		From  dbo.CatAirLines
		Order By CatAirLinName
	End
 Else if(@LenStrToSearch = 1 or @LenStrToSearch = 2)
	  --Searching by AirLineAlfaId, two chars
	  Begin
		Select Distinct CatAirLinAlfaId, CatAirLinName
		From  dbo.CatAirLines
		Where CatAirLinAlfaId like @StrToSearch + '%'
	  End
 else 
	  -- Searching By AirLineName, > two chars
	  Begin
		Select Distinct CatAirLinAlfaId, CatAirLinName
		From  dbo.CatAirLines
		Where CatAirLinName like @StrToSearch + '%' 
		Order By CatAirLinName
	  End
 End



