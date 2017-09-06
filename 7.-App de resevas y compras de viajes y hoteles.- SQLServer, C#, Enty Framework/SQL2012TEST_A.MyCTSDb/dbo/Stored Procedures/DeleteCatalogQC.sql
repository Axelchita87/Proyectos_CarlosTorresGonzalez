
CREATE PROCEDURE [dbo].[DeleteCatalogQC] 
	@Attribute1 as varchar(50),
	@RemarkLabelId as varchar(50)

AS

BEGIN
	DELETE
	FROM
		dbo.ClientsCatalogs
	WHERE
		Attribute1 = @Attribute1 and RemarkLabelId = @RemarkLabelId
END 