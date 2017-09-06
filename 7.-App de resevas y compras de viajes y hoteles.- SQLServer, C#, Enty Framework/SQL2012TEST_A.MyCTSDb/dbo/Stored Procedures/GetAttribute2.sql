-- =============================================
-- Author:		Pedro Tomas Solis
-- Modify:		Luis Felipe Segura Velasco
-- Create date: 13-01-2010
-- Modify date: 17 de Mayo de 2012
-- Description:	Procedure that gets an Attribute1 from INTEGRA
-- =============================================
CREATE Procedure [dbo].[GetAttribute2]
 @Location VARCHAR(6),
 @OrgId INT
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE 
		@ATTRIBUTE1 VARCHAR(50),
		@fcOrgId VARCHAR(10),
		@fcConsulta NVARCHAR(MAX)

	SET @fcOrgId = CAST(@OrgId AS VARCHAR(10))

select * from CTS_CLIENTES_V
WHERE LOCATION=  @Location
AND (STATUS='A' AND STATUS_SITE='A') 
AND ORG_ID=@fcOrgId 

END
-- =============================================
-- exec GetAttribute2 N'CFE101',85
-- =============================================
