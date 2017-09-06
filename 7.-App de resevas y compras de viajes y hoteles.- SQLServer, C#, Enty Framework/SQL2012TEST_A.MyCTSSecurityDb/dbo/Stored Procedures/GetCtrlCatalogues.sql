-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 19-04-2010
-- Description:	Procedure that get a ctrl type catalogue
-- =============================================
CREATE PROCEDURE [dbo].[GetCtrlCatalogues]
	@ctrlType varchar(50)
AS
BEGIN
	SELECT ctrlName 
	FROM dbo.CtrlCatalogues
	WHERE ctrlType=rTrim(@ctrlType)
END