-- =============================================
-- Author:		Pedro Tomas Solis
-- Modify:		Luis Felipe Segura Velasco
-- Create date: Sep-2009, 
-- Modify date: 17 de Mayo 2012
-- =============================================
CREATE PROCEDURE [dbo].[GetCatalog_ClientsCatalogs]
	@Attribute1 VARCHAR(6),
	@RemarkLabelID VARCHAR(5)
AS 
BEGIN
	IF (@RemarkLabelID <> '')
	BEGIN
		SELECT	
				DISTINCT RTRIM(Code) AS [Value],
				(RTRIM(Code) + ' - ' + RTRIM(DescriptionCode)) AS [Text],
				RTRIM(DescriptionCode) AS [Text2],
				'' AS [Text3]
		FROM		dbo.ClientsCatalogs
		WHERE	Attribute1 = @Attribute1
		AND		RemarkLabelID = @RemarkLabelID
	END 
	ELSE 
	BEGIN
		SELECT 
				DISTINCT RTRIM(Code) [Value],
				(RTRIM(Code)+' - '+RTRIM(DescriptionCode)) [Text],
				RTRIM(DescriptionCode) [Text2],
				RTRIM(RemarkLabelID) [Text3]
		FROM
				dbo.ClientsCatalogs
		WHERE
				Attribute1=@Attribute1
	END	
END
-- =============================================
-- EXEC GetCatalog_ClientsCatalogs @Attribute1=N'SCB100',@RemarkLabelID=N''
-- =============================================
