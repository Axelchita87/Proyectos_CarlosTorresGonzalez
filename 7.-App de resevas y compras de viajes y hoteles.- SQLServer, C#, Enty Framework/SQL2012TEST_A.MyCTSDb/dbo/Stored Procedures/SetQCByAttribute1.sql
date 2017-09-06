-- =============================================
-- Author:	Pedro Tomas Solis/Marcos Q. Ramirez
-- Modify:	Luis Felipe Segura Velasco
-- Create date: 19-03-2010, 
-- Modify date: 29 de Agosto de 2012
-- Description:	Procedure that set new quality controls or set default values
--              for the attribute1 received
-- =============================================
CREATE PROCEDURE [dbo].[SetQCByAttribute1]
 @Attribute1 VARCHAR(50),
 @Status VARCHAR(1),
 @Status_Site VARCHAR(1)
AS
	IF (@ATTRIBUTE1 IS NULL OR LTRIM(@ATTRIBUTE1)='')
	BEGIN
		SET @ATTRIBUTE1='SIN_CORP'
	END 
	
	IF(SELECT COUNT(id) FROM dbo.Attributes WITH(NOLOCK) WHERE Attribute1=LTrim(@ATTRIBUTE1) ) = 0
	BEGIN
		INSERT INTO dbo.Attributes
		  (
			Attribute1,
			NameMyCTS,
			StatID,
			Reservation,
			Emision
		  )
		  VALUES
		  (
			@ATTRIBUTE1,
			@ATTRIBUTE1,
			1,1,1
		  )

		INSERT INTO dbo.QualityControls 
		(
	    [Attribute1],
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
		VALUES(
			@ATTRIBUTE1, --CorporativeID
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
		    '2'  --Status
		)
    END		

SELECT @ATTRIBUTE1 as ATTRIBUTE1

-- =============================================
-- 
-- =============================================