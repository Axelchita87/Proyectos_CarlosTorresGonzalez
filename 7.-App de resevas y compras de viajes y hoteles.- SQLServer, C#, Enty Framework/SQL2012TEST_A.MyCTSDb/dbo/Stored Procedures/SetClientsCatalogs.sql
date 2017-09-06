

-- =============================================
-- Author:		<Pedro Tomas Solis>
-- Creation date: <17/Sep/2009>
-- Description:	<Insert a Nextel record in ClientsCatalogs>
-- =============================================
CREATE PROCEDURE [dbo].[SetClientsCatalogs] 
	-- Input variables
	@Client varchar(6), 
	@RemarkLabelID varchar(5),
	@Code varchar(50),
	@DescriptionCode varchar(100)
AS
BEGIN
	set @DescriptionCode = upper(@DescriptionCode)
    -- Insert statements for procedure 
    INSERT INTO dbo.ClientsCatalogs(Attribute1,RemarkLabelID,Code,DescriptionCode)
	VALUES(@Client,@RemarkLabelID,@Code,@DescriptionCode)
END





