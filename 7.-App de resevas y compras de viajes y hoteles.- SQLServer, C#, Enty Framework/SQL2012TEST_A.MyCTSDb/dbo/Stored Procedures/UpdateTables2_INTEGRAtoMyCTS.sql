
-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 07-01-2009, Modified: 12-01-2010, 15-01-2010
-- Description:	KRAKEN,Master Procedure that update tables values not duplicated from INTEGRA to MyCTS
--				Tables: Corporatives, DK, QualityControls
-- =============================================
CREATE Procedure [dbo].[UpdateTables2_INTEGRAtoMyCTS]
AS
Begin
DECLARE @RecordCount int,@RecordIndex int,@CORP_ID VARCHAR(10)
DECLARE @ATTRIBUTE1 VARCHAR(6),@LOCATION_IDDK VARCHAR(6),@CUSTOMER_NUMBER VARCHAR(50),@CUSTOMER_NAME VARCHAR(150)

--Create a temporary table with the Corporatives of Integra not null and unique
Declare @TempIntegra Table(RowID INT IDENTITY(1,1),ATTRIBUTE1 varchar(6),LOCATION VARCHAR(6),CUSTOMER_NUMBER VARCHAR(50),CUSTOMER_NAME varchar(150))
--Inserting Records from Integra
Insert Into @TempIntegra(ATTRIBUTE1,LOCATION,CUSTOMER_NUMBER,CUSTOMER_NAME) 
SELECT DISTINCT
	  ISNULL(ATTRIBUTE1,'SIN_CORP') ATTRIBUTE1,
	  LOCATION,CUSTOMER_NUMBER,CUSTOMER_NAME
FROM CORPP..APPS.CTS_CLIENTES_V 
WHERE ATTRIBUTE1 NOT IN (SELECT IDCorporative FROM dbo.Corporatives) And --Exclude those records that already exist in Corporatives
	  (STATUS_SITE='A' AND STATUS='A') AND
	  (len(ATTRIBUTE1)<=6 AND len(LOCATION)<=6) And --Exclude those records with lenght mayor than six
	  (LOCATION NOT IN		--Exclude those records with locations duplicated
	  (	SELECT LOCATION FROM CORPP..APPS.CTS_CLIENTES_V 
		GROUP BY LOCATION HAVING count(*) > 1
	  ))
--SELECT * FROM @TempIntegra
--***************************************************************
--INSERTING IN CORPORATIVES--Inserting corporatives from Integra to MyCTS
--------------------------------------------------------------
SELECT @RecordCount=count(RowID) FROM @TempIntegra
Set @RecordIndex=1
While @RecordIndex <= @RecordCount
BEGIN
 SELECT DISTINCT @ATTRIBUTE1=ATTRIBUTE1,@LOCATION_IDDK=LOCATION,@CUSTOMER_NUMBER=CUSTOMER_NUMBER,@CUSTOMER_NAME=CUSTOMER_NAME
 FROM @TempIntegra Where RowID=@RecordIndex
 IF NOT EXISTS(SELECT * FROM DBO.CORPORATIVES WHERE IDCORPORATIVE=@ATTRIBUTE1 AND LOCATION_DK=@LOCATION_IDDK)  
 BEGIN	
	Insert Into dbo.Corporatives
	(CorporativeIdICAAV,IDCorporative,Location_DK,[Name],StatID,Reservation,Emision)
	VALUES('SIN_CORP',@ATTRIBUTE1,@LOCATION_IDDK,@ATTRIBUTE1,1,1,1)
 END
 Set @RecordIndex = @RecordIndex + 1
END
--------------------------------------------------------------
--SELECT 'SIN_CORP' AS CorporativeIdICAAV,ATTRIBUTE1,LOCATION,ATTRIBUTE1 AS [NAME],1 AS  STATID,1 AS RESERVATION,1 AS EMISION 
--FROM @TempIntegra --Analizar si es con Distinct
--WHERE ATTRIBUTE1 NOT IN (SELECT IDCorporative FROM dbo.Corporatives)
--Order By LOCATION
--***************************************************************
--INSERTING IN DK--Inserting Corporatives and Dks in DK Table from Integra to MyCTS
--------------------------------------------------------------
SELECT @RecordCount=count(RowID) FROM @TempIntegra
Set @RecordIndex=1
While @RecordIndex <= @RecordCount
BEGIN
 SELECT DISTINCT @ATTRIBUTE1=ATTRIBUTE1,@LOCATION_IDDK=LOCATION,@CUSTOMER_NUMBER=CUSTOMER_NUMBER,@CUSTOMER_NAME=CUSTOMER_NAME
 FROM @TempIntegra Where RowID=@RecordIndex
 IF NOT EXISTS(SELECT * FROM DBO.DK WHERE CORPORATIVEID=@ATTRIBUTE1 AND IDDK=@LOCATION_IDDK)  
 BEGIN	
	INSERT INTO DBO.DK (IDDK,CorporativeID,[Name]) 
	VALUES(@LOCATION_IDDK,@ATTRIBUTE1,@CUSTOMER_NAME)
 END
 Set @RecordIndex = @RecordIndex + 1
END
--------------------------------------------------------------
--Selecting the corporatives from Integra that are not in produccion
--SELECT LOCATION,ATTRIBUTE1,CUSTOMER_NAME FROM @TempIntegra  --analizar el Distinct
--WHERE LOCATION NOT IN (SELECT IDDK FROM dbo.DK) 
--ORDER BY LOCATION
--***************************************************************
----INSERTING IN QUALITY CONTROLS
------Inserting records in QualityControls that match tween LOCATION and IDDK
----Create a temporary table with the LOCATION of Integra not null and unique
--	DECLARE @TempIntegra3 Table(RowID int IDENTITY(1,1),
--								ATT varchar(6),
--								LOCATION_IDDK VARCHAR(6)
--								);
--	--Create a CTE from @TempIntegra
--	With NewCorporatives(ATTRIBUTE1,LOCATION_IDDK) AS
--	(
--	SELECT ATTRIBUTE1,LOCATION AS LOCATION_IDDK
--	FROM @TempIntegra --DBTest.dbo.DK DK_New
--	WHERE LOCATION NOT IN (SELECT LOCATION_DK FROM dbo.QualityControls)
--	) 
--	Insert Into @TempIntegra3(ATT,LOCATION_IDDK) 
--	Select ATTRIBUTE1,LOCATION_IDDK From NewCorporatives --GROUP BY ATTRIBUTE1,LOCATION_IDDK
--
--	SELECT @RecordCount=count(ATT) FROM @TempIntegra3
--	Set @RecordIndex=1
--***************************************************************
	SELECT @RecordCount=count(RowID) FROM @TempIntegra
	Set @RecordIndex=1
	--Inserting records in QualityControls that not match tween LOCATION and IDDK
	While @RecordIndex <= @RecordCount
	BEGIN
	   SELECT DISTINCT @ATTRIBUTE1=ATTRIBUTE1,@LOCATION_IDDK=LOCATION From @TempIntegra Where RowID=@RecordIndex
	   IF NOT EXISTS(SELECT * FROM DBO.QUALITYCONTROLS WHERE CORPORATIVEID=@ATTRIBUTE1 AND LOCATION_DK=@LOCATION_IDDK)  
	   BEGIN	
		INSERT INTO dbo.QualityControls 
		(
	    [CorporativeIDICAAV],
	    [CorporativeID],
	    [Location_DK],
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
			'SIN_CORP', --CorporativeIDICAAV 
			@ATTRIBUTE1, --CorporativeID
			@LOCATION_IDDK, --IDDK
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
	   Set @RecordIndex = @RecordIndex + 1
	END
End







