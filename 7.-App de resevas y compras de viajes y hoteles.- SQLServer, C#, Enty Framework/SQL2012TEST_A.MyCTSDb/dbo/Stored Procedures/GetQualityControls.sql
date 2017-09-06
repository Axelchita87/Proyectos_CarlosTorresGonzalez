-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 08-05-2009
-- Description:	Procedure that gets the QualityControls of a Corporative
-- =============================================
CREATE Procedure [dbo].[GetQualityControls]
 @DKToSearch as varchar(10)
AS
Declare
	@IDCorporative varchar(50)
	--Search for IDCorporative that corresponds to @DKToSearch
	Select @IDCorporative = CorporativeID 
	From dbo.DK
	Where IDDK = @DKToSearch
	if(@IDCorporative <> 'CONSOLID')
	Begin
		Select 
			CorporativeID,DeleteAccountingLines,DeleteAccountingRemarks,CuotingActualFare,
			ComparativeMoreEconomicFareNotAvailable, ComparativeMoreEconomicFareAvailable,
			ComparativeStandardFare,ComparativeSpecificFare,ComparativeBusinessFare,
			ComparativeSoldFareVSMoreEconomicFareNotAvailable,FareJustification,ChargePerService,
			RemarksAvailableClasses,RemarkContableAuthorization
		From
			dbo.QualityControls
		Where ( CorporativeID = @IDCorporative )
	End




