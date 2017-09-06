


-- =============================================
-- Author:		Jessica Gutierrez Becerril
-- Create date: 18-06-2010
-- Description:	Procedure that gets an QCbyAttribute1
-- =============================================
create Procedure [dbo].[GetQCbyAttribute1]
 @Attribute1 as varchar(50)
AS
Begin

	Create Table #TempQC(ident int IDENTITY , IdCtrl varchar(50), ValueCtrl varchar(3))
	Insert Into #TempQC(IdCtrl,ValueCtrl) 
	--Unpivotting the Quality Control Row in order to add it in #TempQC
	Select CtrlId,CtrlValue		
	From 
	(Select DeleteAccountingLines,DeleteAccountingRemarks,CuotingActualFare,
			ComparativeMoreEconomicFareNotAvailable,ComparativeMoreEconomicFareAvailable,ComparativeStandardFare,
			ComparativeSpecificFare,ComparativeBusinessFare,ComparativeSoldFareVSMoreEconomicFareNotAvailable,
			FareJustification,ApplyComparativeMoreEconomicFare,ChargePerService,RemarksAvailableClasses,
			RemarkContableAuthorization,QCAuthorized,LabelQC,Cancellation,FareRemark,VerifyTicketEmission,
			ReservationSendQCClient,EmissionSendQCClient,
			C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,C11,C12,C13,C14,C15,C16,C17,C18,C19,C20,
			C21,C22,C23,C24,C25,C26,C27,C28,C29,C30,C31,C32,C33,C34,C35,C36,C37,C38,C39,C40,
			C41,C42,C43,C44,C45,C46,C47,C48,C49,C50,C51,C52,C53,C54,C55,C56,C57,C58,C59,C60,
			C61,C62,C63,C64,C65,C66,C67,C68,C69,C70,C71,C72,C73,C74,C75,C76,C77,C78,C79,C80,
			C81,C82,C83,C84,C85,C86,C87,C88,C89,C90,C91,C92,C93,C94,C95,C96,C97,C98,C99,C100,
			CostCenters 
	From dbo.QualityControls where Attribute1 = @Attribute1)P
	UNPIVOT
	(CtrlValue for CtrlId in (DeleteAccountingLines,DeleteAccountingRemarks,CuotingActualFare,
			ComparativeMoreEconomicFareNotAvailable,ComparativeMoreEconomicFareAvailable,ComparativeStandardFare,
			ComparativeSpecificFare,ComparativeBusinessFare,ComparativeSoldFareVSMoreEconomicFareNotAvailable,
			FareJustification,ApplyComparativeMoreEconomicFare,ChargePerService,RemarksAvailableClasses,
			RemarkContableAuthorization,QCAuthorized,LabelQC,Cancellation,FareRemark,VerifyTicketEmission,
			ReservationSendQCClient,EmissionSendQCClient,
			C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,C11,C12,C13,C14,C15,C16,C17,C18,C19,C20,
			C21,C22,C23,C24,C25,C26,C27,C28,C29,C30,C31,C32,C33,C34,C35,C36,C37,C38,C39,C40,
			C41,C42,C43,C44,C45,C46,C47,C48,C49,C50,C51,C52,C53,C54,C55,C56,C57,C58,C59,C60,
			C61,C62,C63,C64,C65,C66,C67,C68,C69,C70,C71,C72,C73,C74,C75,C76,C77,C78,C79,C80,
			C81,C82,C83,C84,C85,C86,C87,C88,C89,C90,C91,C92,C93,C94,C95,C96,C97,C98,C99,C100,
			CostCenters )) as pvt

select QC.IdCtrl,LR.Description,QC.ValueCtrl
from #TempQC QC
LEFT JOIN dbo.LabelsRemarks LR on LR.IDRemarkLabel=QC.IdCtrl
order by QC.ident
End
