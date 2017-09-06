-- =============================================
-- Author:		Marcos Q. Ramirez
-- Modify:	Segura Velasco Luis Felipe
-- Create date: 19-04-10, 
-- Modify Date: 14 de Junio de 1983
-- Description:	Procedure that gets the QualityControls and Features 
--              for the controls of client
-- =============================================
create PROCEDURE [dbo].[GetQCControlsClients_MYCTS]
	@Attribute1 as varchar(50),
	@Firm as varchar(50),
	@PCC as varchar(50),
	@Agent as varchar(50) = null
AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE dbo.QCControlsFeatures
	SET CtrlDescription = (
		SELECT TOP 1 UserMail 
		FROM MyCTSSecurityDb.dbo.Users 
		WHERE Firm = @Firm AND PCC = @PCC AND Agent=@Agent
	)
	WHERE IDCtrl = 'C29'
	
	SELECT CtrlId IdCtrl,
	  CtrlValue ValueCtrl
	INTO #TempQC
	FROM
	  (SELECT C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,
		C11,C12,C13,C14,C15,C16,C17,C18,C19,C20,
		C21,C22,C23,C24,C25,C26,C27,C28,C29,C30,
		C31,C32,C33,C34,C35,C36,C37,C38,C39,C40,
		C41,C42,C43,C44,C45,C46,C47,C48,C49,C50,
		C51,C52,C53,C54,C55,C56,C57,C58,C59,C60,
		C61,C62,C63,C64,C65,C66,C67,C68,C69,C70,
		C71,C72,C73,C74,C75,C76,C77,C78,C79,C80,
		C81,C82,C83,C84,C85,C86,C87,C88,C89,C90,
		C91,C92,C93,C94,C95,C96,C97,C98,C99,C100
	  FROM dbo.QualityControls
	  WHERE Attribute1 = @Attribute1
	  ) P UNPIVOT (CtrlValue FOR CtrlId IN (C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,C11,C12,C13,C14,C15,C16,C17,C18,C19,C20, C21,C22,C23,C24,C25,C26,C27,C28,C29,C30,C31,C32,C33,C34,C35,C36,C37,C38,C39,C40, C41,C42,C43,C44,C45,C46,C47,C48,C49,C50,C51,C52,C53,C54,C55,C56,C57,C58,C59,C60, C61,C62,C63,C64,C65,C66,C67,C68,C69,C70,C71,C72,C73,C74,C75,C76,C77,C78,C79,C80, C81,C82,C83,C84,C85,C86,C87,C88,C89,C90,C91,C92,C93,C94,C95,C96,C97,C98,C99,C100)) AS unpvt
	-----------------------------------------------------------------------------------------------------		
	SELECT CtrlId IdCtrl,
	  CtrlValue ActiveQCClient
	INTO #TempQCCLient
	FROM
	  (SELECT C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,
		C11,C12,C13,C14,C15,C16,C17,C18,C19,C20,
		C21,C22,C23,C24,C25,C26,C27,C28,C29,C30,
		C31,C32,C33,C34,C35,C36,C37,C38,C39,C40,
		C41,C42,C43,C44,C45,C46,C47,C48,C49,C50,
		C51,C52,C53,C54,C55,C56,C57,C58,C59,C60,
		C61,C62,C63,C64,C65,C66,C67,C68,C69,C70,
		C71,C72,C73,C74,C75,C76,C77,C78,C79,C80,
		C81,C82,C83,C84,C85,C86,C87,C88,C89,C90,
		C91,C92,C93,C94,C95,C96,C97,C98,C99,C100
	  FROM dbo.QualityControlsClients
	  WHERE Attribute1 = @Attribute1
	  ) P UNPIVOT (CtrlValue FOR CtrlId IN (C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,C11,C12,C13,C14,C15,C16,C17,C18,C19,C20, C21,C22,C23,C24,C25,C26,C27,C28,C29,C30,C31,C32,C33,C34,C35,C36,C37,C38,C39,C40, C41,C42,C43,C44,C45,C46,C47,C48,C49,C50,C51,C52,C53,C54,C55,C56,C57,C58,C59,C60, C61,C62,C63,C64,C65,C66,C67,C68,C69,C70,C71,C72,C73,C74,C75,C76,C77,C78,C79,C80, C81,C82,C83,C84,C85,C86,C87,C88,C89,C90,C91,C92,C93,C94,C95,C96,C97,C98,C99,C100)) AS unpvt
	-----------------------------------------------------------------------------------------------------
	IF((SELECT [IdCtrl] FROM #TempQCCLient WHERE IdCtrl = 'C1') IS NULL)
	BEGIN
		SELECT LR.IDRemarkLabel AS QCId,
		  TQC.ValueCtrl         AS QCValue,
		  LR.Description QCDescription,
		  QCF.CtrlType,
		  QCF.ReservationCtrlType,
		  QCF.CtrlName,
		  QCF.CtrlDescription,
		  QCF.CtrlLen,
		  QCF.CtrlCurrentCriteria,
		  QCF.AllowInsertValues,
		  QCF.CtrlCatalogues,
		  NULL AS ActiveQCClient
		INTO #VirtualQC
		FROM dbo.QCControlsFeatures QCF
		INNER JOIN dbo.LabelsRemarks LR
		ON LR.IDRemarkLabel=QCF.IDCtrl
		INNER JOIN #TempQC TQC
		ON TQC.IdCtrl=QCF.IDCtrl
		ORDER BY [ORDER] 

		UPDATE #VirtualQC 
		SET AllowInsertValues=1 
		WHERE QCId in
		(
			SELECT DISTINCT RemarkLabelID
			FROM dbo.ClientsCatalogs
			WHERE Attribute1 = @Attribute1
			AND AllowInsertValues = 1
		)

		SELECT * 
		FROM #VirtualQC

		DROP TABLE #VirtualQC

	END
	ELSE
	BEGIN
		SELECT LR.IDRemarkLabel AS QCId,
		  TQC.ValueCtrl         AS QCValue,
		  LR.Description QCDescription,
		  QCF.CtrlType,
		  QCF.ReservationCtrlType,
		  QCF.CtrlName,
		  QCF.CtrlDescription,
		  QCF.CtrlLen,
		  QCF.CtrlCurrentCriteria,
		  QCF.AllowInsertValues,
		  QCF.CtrlCatalogues,
		  AQCC.ActiveQCClient
		INTO #VirtualQC2
		FROM dbo.QCControlsFeatures QCF
		INNER JOIN dbo.LabelsRemarks LR
		ON LR.IDRemarkLabel=QCF.IDCtrl
		INNER JOIN #TempQC TQC
		ON TQC.IdCtrl=QCF.IDCtrl
		INNER JOIN #TempQCCLient AQCC
		ON AQCC.IdCtrl=QCF.IDCtrl

		UPDATE #VirtualQC2
		SET AllowInsertValues=1 
		WHERE QCId in
		(
			SELECT DISTINCT RemarkLabelID
			FROM dbo.ClientsCatalogs
			WHERE Attribute1 = @Attribute1
			AND AllowInsertValues = 1
		)

		SELECT * 
		FROM #VirtualQC2

		DROP TABLE #VirtualQC2

	END

	DROP TABLE #TempQC
	DROP TABLE #TempQCCLient

END
-- =============================================
-- EXEC GetQCControlsClients @Attribute1=N'QSM100',@Firm=N'1788',@PCC=N'3L64', @Agent='OC'
-- =============================================


