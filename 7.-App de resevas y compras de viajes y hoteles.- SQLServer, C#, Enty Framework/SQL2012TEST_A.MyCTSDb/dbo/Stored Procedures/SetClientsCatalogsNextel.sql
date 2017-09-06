
-- =============================================
-- Author:		<Pedro Tomas Solis>
-- Creation date: <17/Sep/2009>
-- Description:	<Insert a Nextel record in ClientsCatalogs>
-- =============================================
CREATE PROCEDURE [dbo].[SetClientsCatalogsNextel] 
	-- Input variables
	@CorporativeID varchar(6), 
	@RemarkLabelID varchar(5), 
	@Code varchar(50), 	
	@DescriptionCode varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON preventing extra result sets from interfering with SELECT statements
	SET NOCOUNT ON;

    -- Insert statements for procedure 
    INSERT INTO dbo.ClientsCatalogs(Attribute1,RemarkLabelID,Code,DescriptionCode)
	VALUES(@CorporativeID,@RemarkLabelID,@Code,@DescriptionCode)
END





