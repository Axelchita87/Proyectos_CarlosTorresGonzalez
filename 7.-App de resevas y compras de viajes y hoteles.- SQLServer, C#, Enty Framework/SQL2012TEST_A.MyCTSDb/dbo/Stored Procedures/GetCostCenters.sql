-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 27-05-2009
-- Description:	Procedure that gets a DK-Corporative-CostCenters collection
-- =============================================
CREATE Procedure [dbo].[GetCostCenters]
 @DKToSearch as varchar(50),@StrToSearch as varchar(50)
AS
Declare
	@CorporateID as varchar(50)
	Select @CorporateID = CorporativeID from dbo.DK Where IDDK = @DKToSearch
	
Begin
	Select 
		IDCC, CCName
	From
		dbo.CostCenters
	Where ( IDCorporative = @CorporateID and (IDCC like @StrToSearch + '%' or CCName like @StrToSearch + '%'))
End
