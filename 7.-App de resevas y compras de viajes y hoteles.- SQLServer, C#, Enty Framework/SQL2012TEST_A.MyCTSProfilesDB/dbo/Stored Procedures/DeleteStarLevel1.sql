


-- =============================================
-- Author:		<Marcos Q. Ramirez Luna>
-- Create date: <18/Febrero/2010>
-- Description:	<borra la información del perfil de primer nivel>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteStarLevel1] 
	-- Add the parameters for the stored procedure here
	@Pccid varchar(10), 
	@Level1 nvarchar(50)
    
	
AS
BEGIN
    -- Insert statements for procedure here

	DELETE from dbo.CatStarsFirstLevel
	WHERE Pccid = @Pccid and Star1Name = @Level1

	DELETE from dbo.Star1
	WHERE Pccid = @Pccid and Level1 = @Level1

	DELETE from dbo.Star2
	WHERE Pccid = @Pccid and Level1 = @Level1
END



