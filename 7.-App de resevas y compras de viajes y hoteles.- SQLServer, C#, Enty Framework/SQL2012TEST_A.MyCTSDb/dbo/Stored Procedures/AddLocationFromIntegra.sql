-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 13-01-2009
-- Description:	Procedure that add a new location and attribute1 from integra
-- =============================================
CREATE Procedure [dbo].[AddLocationFromIntegra]
@DK AS VARCHAR(6)
AS
Begin
 	-----------------------------------------------------------------
	DECLARE @ATTRIBUTE1 VARCHAR(50),@LOCATION VARCHAR(6),@CUSTOMER_NAME VARCHAR(150)
--	DECLARE @DK AS VARCHAR(6)
--	SET @DK='JRA990'
--	DECLARE 
--	Select LOCATION,ATTRIBUTE1,CUSTOMER_NAME,CUSTOMER_NUMBER 
--	From CORPP..APPS.CTS_CLIENTES_V Where location=@DK
--	SELECT * FROM dbo.Corporatives WHERE Location_DK=@DK
--	SELECT * FROM dbo.DK WHERE IDDK=@DK
--	SELECT * FROM dbo.QualityControls WHERE Location_DK=@DK
	SELECT DISTINCT @LOCATION=Ltrim(LOCATION),@ATTRIBUTE1=Ltrim(ATTRIBUTE1),@CUSTOMER_NAME=Ltrim(CUSTOMER_NAME) FROM CORPP..APPS.CTS_CLIENTES_V 
	WHERE LOCATION = @DK

	INSERT INTO MyCTSDb.dbo.CORPORATIVES(CORPORATIVEIDICAAV,IDCORPORATIVE,LOCATION_DK,[NAME],StatID,Reservation,Emision)
	VALUES ('SIN_CORP',@ATTRIBUTE1,@LOCATION,@ATTRIBUTE1,1,1,1)

	INSERT INTO MyCTSDb.dbo.dk(IDDK,CORPORATIVEID,[NAME])
	VALUES (@LOCATION,@ATTRIBUTE1,@CUSTOMER_NAME)

	INSERT INTO MyCTSDb.dbo.QualityControls 
		(
	    --[CorporativeIDICAAV],
	    --[CorporativeID],
	    --[Location_DK],
		[DeleteAccountingLines],
		[DeleteAccountingRemarks],
		[CuotingActualFare],
		[ComparativeMoreEconomicFareNotAvailable],
		[ComparativeMoreEconomicFareAvailable],
		[ComparativeStandardFare],
		[ClassComparativeStandard],
		[ComparativeSpecificFare],
		[ClassComparativeSpecific],
		[ComparativeBusinessFare],
		[ClassComparativeBusiness1],
		[ClassComparativeBusiness2],
		[ClassComparativeBusiness3],
		[ClassComparativeBusiness4],
		[ComparativeSoldFareVSMoreEconomicFareNotAvailable],
		[FareJustification],
		[ApplyComparativeMoreEconomicFare],
		[ChargePerService],
		[RemarksAvailableClasses],
		[RemarkContableAuthorization],
		[QCAuthorized],
		[LabelQC],
		[Cancellation],
		[FareRemark],
 	    [VerifyTicketEmission],
		[C1],[C2],[C3],[C4],[C5],[C6],[C7],[C8],[C9],[C10],[C11],[C12],[C13],[C14],[C15],[C16],[C17],[C18],[C19],[C20],
		[C21],[C22],[C23],[C24],[C25],[C26],[C27],[C28],[C29],[C30],[C31],[C32],[C33],[C34],[C35],[C36],[C37],[C38],[C39],[C40],
		[C41],[C42],[C43],[C44],[C45],[C46],[C47],[C48],[C49],[C50],[C51],[C52],[C53],[C54],[C55],[C56],[C57],[C58],[C59],[C60],
		[C61],[C62],[C63],[C64],[C65],[C66],[C67],[C68],[C69],[C70],[C71],[C72],[C73],[C74],[C75],[C76],[C77],[C78],[C79],[C80],
		[C81],[C82],[C83],[C84],[C85],[C86],[C87],[C88],[C89],[C90],[C91],[C92],[C93],[C94],[C95],[C96],[C97],[C98],[C99],[C100],
		[CostCenters],
		[Status]		
		)
	 --SELECT * FROM dbo.QualityControls ORDER BY IDQualityControl
		VALUES(
			--'SIN_CORP', --CorporativeIDICAAV 
			--@ATTRIBUTE1, --CorporativeID
			--@LOCATION, --IDDK
			'I', --DeleteAccountingLines
			'A', --DeleteAccountingRemarks
			'A', --CuotingActualFare
			'A', --ComparativeMoreEconomicFareNotAvailable
			'A', --ComparativeMoreEconomicFareAvailable
			'A', --ComparativeStandardFare
			'Y', --ClassComparativeStandard
			'A', --ComparativeSpecificFare
			'K', --ClassComparativeSpecific
			'A', --ComparativeBusinessFare
			'J', --ClassComparativeBusiness1
			'A', --ClassComparativeBusiness2
			'C', --ClassComparativeBusiness3
			'D', --ClassComparativeBusiness4
			'A', --ComparativeSoldFareVSMoreEconomicFareNotAvailable
			'A', --FareJustification
			'I', --ApplyComparativeMoreEconomicFare
			'A', --ChargePerService
			'A', --RemarksAvailableClasses
			'I', --RemarkContableAuthorization
			'I', --QCAuthorized
			'I', --LabelQC
			'A', --Cancellation
			'I', --FareRemark
			'I', --VerifyTicketEmision
			'I','I','I','I','I','I','I','I','I','A2',   --C1-C10
			'A','A','A','A','A','A','A','A','A','A',    --C11-C20
			'A2','A2','A1','I','I','I','I','I','A','A', --C21-C30
			'I','I','I','I','I','I','I','I','I','I',    --C31-C40 
			'I','I','I','I','I','I','I','I','I','I',    --C41-C50
			'I','I','I','I','I','I','I','I','I','I',    --C51-C60
		    'I','I','I','I','I','I','I','I','I','I',    --C61-C70
		    'I','I','I','I','I','I','I','I','I','I',    --C71-C80
		    'I','I','I','I','I','I','I','I','I','I',    --C81-C90
		    'I','I','I','I','I','I','I','I','I','I',    --C91-C100
		    'I', --CostCenters
		    '3'  --Status
		    )			
End			
