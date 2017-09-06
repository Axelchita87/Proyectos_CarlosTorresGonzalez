



-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 11-05-2009, Modified: 21-04-10
-- Description:	Procedure that gets a Corporative Quality Controls collection and its and Remarks
-- Modify By:   Marcos Q. Ramirez 12-04-10
-- =============================================
CREATE Procedure [dbo].[GetCorporativeQualityControls]
 --@DKToSearch as varchar(10)
 @Attribute1 as varchar(50)
AS
Declare
	--Variables
	--@IDCorporative varchar(50),
	@ComparativeMoreEconomicFareNotAvailable varchar(50),
	@ComparativeMoreEconomicFareAvailable varchar(50),
	@ComparativeStandardFare varchar(50),
	@ComparativeSpecificFare varchar(50),
	@ComparativeBusinessFare varchar(50),
	@FareJustification varchar(50),
    @ConsolidRemark varchar(50),
    @FareRemark varchar(50),
	@Status int,
    @XMLSabreCommand varchar(18)

	--Searching an IDCorporative that corresponds to @DKToSearch
	--Select @IDCorporative = CorporativeID 
	--From dbo.DK
	--Where IDDK = @DKToSearch
	
	-- Selecting Values for Remarks Variables 
	Select 
		@ComparativeMoreEconomicFareNotAvailable = ComparativeMoreEconomicFareNotAvailable,
		@ComparativeMoreEconomicFareAvailable = ComparativeMoreEconomicFareAvailable,
		@ComparativeStandardFare = ComparativeStandardFare,
		@ComparativeSpecificFare = ComparativeSpecificFare,
		@ComparativeBusinessFare = ComparativeBusinessFare,
		@FareJustification = FareJustification,
        @FareRemark = FareRemark,
		@Status = [Status]
	From dbo.QualityControls
	Where ( Attribute1 = @Attribute1 )

	-- ComparativeMoreEconomicFareNotAvailable 
	If(@ComparativeMoreEconomicFareNotAvailable = 'A')
	Begin
		Select @ComparativeMoreEconomicFareNotAvailable = Command
		From dbo.LabelsRemarks
		Where ( IDRemarkLabel = 'ComparativeMoreEconomicFareNotAvailable' )
	End
	Else 
		Set @ComparativeMoreEconomicFareNotAvailable = Null

	-- ComparativeMoreEconomicFareAvailable 
	If(@ComparativeMoreEconomicFareAvailable = 'A')
	Begin
		Select @ComparativeMoreEconomicFareAvailable = Command
		From dbo.LabelsRemarks
		Where ( IDRemarkLabel = 'ComparativeMoreEconomicFareAvailable' )
	End
	Else
		Set @ComparativeMoreEconomicFareAvailable = Null

	-- ComparativeStandardFare 
	If(@ComparativeStandardFare = 'A')
	Begin
		Select @ComparativeStandardFare = Command
		From dbo.LabelsRemarks
		Where ( IDRemarkLabel = 'ComparativeStandardFare' )
	End
	Else
		Set @ComparativeStandardFare = Null

	-- ComparativeSpecificFare 
	If(@ComparativeSpecificFare = 'A')
	Begin
		Select @ComparativeSpecificFare = Command
		From dbo.LabelsRemarks
		Where ( IDRemarkLabel = 'ComparativeSpecificFare' )
	End
	Else
		Set @ComparativeSpecificFare = Null

	-- ComparativeBusinessFare 
	If(@ComparativeBusinessFare = 'A')
	Begin
		Select @ComparativeBusinessFare = Command
		From dbo.LabelsRemarks
		Where ( IDRemarkLabel = 'ComparativeBusinessFare' )
	End
	Else
		Set @ComparativeBusinessFare = Null

	-- FareJustification 
	If(@FareJustification = 'A')
	Begin
		Select @FareJustification = Command
		From dbo.LabelsRemarks
		Where ( IDRemarkLabel = 'FareJustification' )
	End
	Else
		Set @FareJustification = Null
--
--
--  ConsolidRemark
	If(@Attribute1 like 'CON%')
	Begin
		Select @ConsolidRemark = Command
		From dbo.LabelsRemarks
		Where ( IDRemarkLabel = 'ConsolidRobotRemark' )
	End
	Else
		Set @ConsolidRemark = Null


-- SabreCommand
	Select @XMLSabreCommand = [RmrkType] 
	From dbo.QCCustomRemarksClients
	Where ( Attribute1 = @Attribute1 )
    
    if (@XMLSabreCommand is null)
        set @XMLSabreCommand = '5.'

-- FareRemark
	If(@FareRemark = 'A')
	Begin
		Select @FareRemark = Command
		From dbo.LabelsRemarks
		Where ( IDRemarkLabel = 'FareRemark' )
	End
	Else
		Set @FareRemark = Null

-- Selecting Values for Remarks Variables 
	Select 
		@ComparativeMoreEconomicFareNotAvailable = ComparativeMoreEconomicFareNotAvailable
	From dbo.QualityControls
	Where ( Attribute1 = @Attribute1 )

	Select 
			QC.Attribute1,
            --QC.CorporativeIDICAAV,
			@Status as [Status],
			QC.DeleteAccountingLines,
			QC.DeleteAccountingRemarks,
			QC.CuotingActualFare,
			QC.ComparativeMoreEconomicFareNotAvailable, 
			@ComparativeMoreEconomicFareNotAvailable as RemarkCMEFNA,
			QC.ComparativeMoreEconomicFareAvailable, 
			@ComparativeMoreEconomicFareAvailable as RemarkCMEFA,
			QC.ComparativeStandardFare, 
			QC.ClassComparativeStandard,
			@ComparativeStandardFare as RemarkCStdF,
			QC.ComparativeSpecificFare,
			QC.ClassComparativeSpecific, 
			@ComparativeSpecificFare as RemarkCSpcF,
			QC.ComparativeBusinessFare,
			QC.ClassComparativeBusiness1,
			QC.ClassComparativeBusiness2,
			QC.ClassComparativeBusiness3,
			QC.ClassComparativeBusiness4,
			@ComparativeBusinessFare as RemarkCBnsF,
			QC.ComparativeSoldFareVSMoreEconomicFareNotAvailable,
			QC.FareJustification, 
			@FareJustification as RemarkFJ,
            @ConsolidRemark as RemarkRobot,
            @FareRemark as FareRemark,
            QC.GetThereQCValues,
            QC.ReservationSendQCClient,
            QC.EmissionSendQCClient,
			QC.VerifyTicketEmission,
			QC.ChargePerService,
			QC.RemarksAvailableClasses,
			QC.RemarkContableAuthorization,
			QC.QCAuthorized,
			QC.LabelQC,
			QC.ApplyComparativeMoreEconomicFare,
            @XMLSabreCommand as ClientRemarkType
	From
			dbo.QualityControls QC
	Where ( Attribute1 = @Attribute1 )



