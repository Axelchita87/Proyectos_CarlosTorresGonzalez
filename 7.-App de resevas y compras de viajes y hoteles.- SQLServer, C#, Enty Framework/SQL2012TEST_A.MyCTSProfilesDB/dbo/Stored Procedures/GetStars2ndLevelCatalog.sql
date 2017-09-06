





-- =============================================
-- Author:		<Marcos Q. Ramirez Luna>
-- Create date: <22/Enero/2010>
-- Description:	<Obtiene el catalogo de estrellas de segundo nivel>
-- =============================================
create PROCEDURE [dbo].[GetStars2ndLevelCatalog] 
	-- Add the parameters for the stored procedure here
--	@Pccid nvarchar(10)
	
AS
BEGIN
    -- Select statements for procedure here
	SELECT Pccid, Star1id, Star2Name from dbo.CatStarsSecondLevel
	--WHERE Pccid = @Pccid

END









