-- =============================================
-- Author:		Pedro Tomas Solis Ver:2
-- Create date: 23-07-2009, modified:24-07-2009;25-07-2009
-- Description:	Procedure that gets the QualityControls and Features 
--              for the controls of a Corporative
-- =============================================
CREATE Procedure [dbo].[GetQCControls]
 --@DKToSearch as varchar(10),
 @Attribute1 as varchar(50),
 @Firm as varchar(50),
 @PCC as varchar(50)
AS
Begin
	Declare
	--Variables
	--@IDCorporative varchar(50),
	@UserMail varchar(50)

    --Search for IDCorporative that corresponds to @DKToSearch
	--Select @IDCorporative = CorporativeID 
	--From dbo.DK
	--Where IDDK = @DKToSearch

	--Searching the email that corresponds to @Firm and @PCC
	Select @UserMail = UserMail
	From MyCTSSecurityDb.dbo.Users
	Where ( Firm = @Firm and PCC = @PCC )

	--If temporary table exists,it is dropped
	If Object_Id ('tempdb..#TempQC') Is Not Null
		Drop Table #TempQC

	--Create a temporary table with the Quality Controls of the new Corporative
	Create Table #TempQC(IdCtrl varchar(50), ValueCtrl varchar(3))
	Insert Into #TempQC(IdCtrl,ValueCtrl) 
	--Unpivotting the Quality Control Row in order to add it in #TempQC
	Select CtrlId,CtrlValue
		From
		(Select C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,C11,C12,C13,C14,C15,C16,C17,C18,C19,C20,
				C21,C22,C23,C24,C25,C26,C27,C28,C29,C30,C31,C32,C33,C34,C35,C36,C37,C38,C39,C40,
				C41,C42,C43,C44,C45,C46,C47,C48,C49,C50,C51,C52,C53,C54,C55,C56,C57,C58,C59,C60,
				C61,C62,C63,C64,C65,C66,C67,C68,C69,C70,C71,C72,C73,C74,C75,C76,C77,C78,C79,C80,
				C81,C82,C83,C84,C85,C86,C87,C88,C89,C90,C91,C92,C93,C94,C95,C96,C97,C98,C99,C100
		From dbo.QualityControls where Attribute1 = @Attribute1) P--modificar esta linea
		UNPIVOT
		(CtrlValue FOR CtrlId IN (C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,C11,C12,C13,C14,C15,C16,C17,C18,C19,C20,
								  C21,C22,C23,C24,C25,C26,C27,C28,C29,C30,C31,C32,C33,C34,C35,C36,C37,C38,C39,C40,
								  C41,C42,C43,C44,C45,C46,C47,C48,C49,C50,C51,C52,C53,C54,C55,C56,C57,C58,C59,C60,
								  C61,C62,C63,C64,C65,C66,C67,C68,C69,C70,C71,C72,C73,C74,C75,C76,C77,C78,C79,C80,
								  C81,C82,C83,C84,C85,C86,C87,C88,C89,C90,C91,C92,C93,C94,C95,C96,C97,C98,C99,C100)) as unpvt
	--Updating mail
	Update dbo.QCControlsFeatures
	Set CtrlDescription=@UserMail
	Where IDCtrl='C29'
	--Temporary table for the construction of the new dynamic QCControls
	Declare @VirtualQC table(QCId varchar(50),QCValue varchar(3),QCDescription varchar(100),
			CtrlType varchar(50),CtrlName varchar(50),CtrlDescription varchar(50),
			CtrlLen int,CtrlCurrentCriteria varchar(50),AllowInsertValues bit,CtrlCatalogues varchar(150))
	Insert into @VirtualQC(QCId,QCValue,QCDescription,CtrlType,CtrlName,CtrlDescription,
						CtrlLen,CtrlCurrentCriteria,AllowInsertValues,CtrlCatalogues)
	--Mixing Controls Features, Quality Controls and Labels Remarks 	
	Select LR.IDRemarkLabel as QCId,TQC.ValueCtrl as QCValue,LR.Description QCDescription,QCF.CtrlType,QCF.CtrlName,QCF.CtrlDescription,QCF.CtrlLen,QCF.CtrlCurrentCriteria,QCF.AllowInsertValues, QCF.CtrlCatalogues
	From dbo.QCControlsFeatures QCF
	Inner join dbo.LabelsRemarks LR On LR.IDRemarkLabel=QCF.IDCtrl
	Inner join #TempQC TQC On TQC.IdCtrl=QCF.IDCtrl
	Order By [Order]
	
	Declare @ActualLabel varchar(50)
	Declare QCCursor Cursor For Select QCId from @VirtualQC
	Open QCCursor
	Fetch Next From QCCursor into @ActualLabel
	
	While @@FETCH_STATUS=0
	Begin
	--Verifying if the IDCtrl allows To Insert values
		Declare @IdCtrlAllowInsert bit
		Set @IdCtrlAllowInsert = 0
		If Exists ( Select AllowInsertValues 
					From dbo.ClientsCatalogs
					Where Attribute1=@Attribute1 and 
						RemarkLabelID=@ActualLabel and AllowInsertValues=1
		)
		Begin
			Update @VirtualQC 
				   Set AllowInsertValues=1
			Where QCId=@ActualLabel
		End
		Fetch Next From QCCursor into @ActualLabel
	End
	Close QCCursor
	Deallocate QCCursor

	Select * from @VirtualQC
End







