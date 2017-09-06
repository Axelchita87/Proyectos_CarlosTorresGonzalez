



-- =============================================
-- Author:		<Marcos Q. Ramirez Luna>
-- Create date: <18/Febrero/2010>
-- Description:	<borra la información del perfil de segundo nivel>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteStarLevel2] 
	-- Add the parameters for the stored procedure here
	@Pccid varchar(10), 
	@Level1 nvarchar(50),
	@Level2 nvarchar(50)
    
	
AS
BEGIN
    -- Insert statements for procedure here

	DELETE from dbo.CatStarsSecondLevel
	WHERE Pccid = @Pccid and Star1id = @Level1 and Star2Name = @Level2

	DELETE from dbo.Star2
	WHERE Pccid = @Pccid and Level1 = @Level1 and Level2 = @Level2

END




