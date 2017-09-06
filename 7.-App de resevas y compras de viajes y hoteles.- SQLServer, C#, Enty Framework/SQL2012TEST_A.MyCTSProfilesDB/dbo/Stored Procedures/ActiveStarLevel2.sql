





-- =============================================
-- Author:		<Marcos Q. Ramirez Luna>
-- Create date: <18/Febrero/2010>
-- Description:	<inactiva la información del perfil de segundo nivel>
-- =============================================
CREATE PROCEDURE [dbo].[ActiveStarLevel2] 
	-- Add the parameters for the stored procedure here
	@Pccid varchar(10), 
	@Level1 nvarchar(50),
	@Level2 nvarchar(50)
   
    
	
AS
BEGIN
    -- Insert statements for procedure here

	UPDATE dbo.CatStarsSecondLevel
    SET	Active = 'False' , InactiveDate = getdate()
	WHERE Pccid = @Pccid and Star1id = @Level1 and Star2Name = @Level2

	
END






