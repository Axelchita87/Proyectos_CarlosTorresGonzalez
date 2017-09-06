-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 16-04-2009
-- Description:	Procedure that gets a Cities collection
-- =============================================
CREATE Procedure [dbo].[GetCatCitiCouID]
 @StrToSearch as varchar(10)
AS
 Declare @LenStrToSearch int
 set @LenStrToSearch = len(@StrToSearch)
Begin
 if(@LenStrToSearch < 4)
	  Begin
		Select Distinct CatCitId CatCitCouId
		From dbo.CatCities
		Where CatCitId like @StrToSearch + '%'
	  End
 else
	  Begin
		Select Distinct CatCitId CatCitCouId
		From dbo.CatCities
		Where CatCitName like @StrToSearch + '%'
	  End
 End
