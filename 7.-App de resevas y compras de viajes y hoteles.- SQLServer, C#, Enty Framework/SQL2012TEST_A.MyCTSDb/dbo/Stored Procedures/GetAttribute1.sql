-- =============================================
-- Author:		Pedro Tomas Solis
-- Modify:		Luis Felipe Segura Velasco
-- Create date: 13-01-2010
-- Modify date: 17 de Mayo de 2012
-- Description:	Procedure that gets an Attribute1 from INTEGRA
-- =============================================
CREATE Procedure [dbo].[GetAttribute1]
 @Location VARCHAR(6),
 @OrgId INT
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE 
		@ATTRIBUTE1 VARCHAR(50)

	SELECT 
		@ATTRIBUTE1 = ATTRIBUTE1
	FROM 
		Location_Attribute
	WHERE LOCATION=@Location
	AND (STATUS='A' AND STATUS_SITE='A') 

	--	@fcOrgId VARCHAR(10),
	--	@fcConsulta NVARCHAR(MAX)

	--SET @fcOrgId = CAST(@OrgId AS VARCHAR(10))

	--SELECT @fcConsulta = 'SELECT @ATTRIBUTE1 = ATTRIBUTE1 FROM OPENQUERY(CORPP,''SELECT ATTRIBUTE1 FROM APPS.CTS_CLIENTES_V WHERE LOCATION=''''' + @Location + ''''' AND (STATUS=''''A'''' AND STATUS_SITE=''''A'''') AND ORG_ID=' + @fcOrgId + ''')'
	
	--EXEC sp_executesql @fcConsulta, N'@ATTRIBUTE1 VARCHAR(50) OUTPUT', @ATTRIBUTE1 OUTPUT

	IF @ATTRIBUTE1 is null or @ATTRIBUTE1 = ''
		SELECT 'NO EXISTE' AS ATTRIBUTE1
	ELSE
		SELECT @ATTRIBUTE1 AS ATTRIBUTE1
END
-- =============================================
 --exec GetAttribute1 N'E97016',85
-- =============================================
