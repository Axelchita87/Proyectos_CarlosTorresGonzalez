







-- =============================================
-- Author:		<Marcos Q. Ramirez Luna>
-- Create date: <18/Febrero/2010>
-- Description:	<inactiva la información del perfil de primer nivel>
-- =============================================
CREATE PROCEDURE [dbo].[ActiveStarLevel1] 
	-- Add the parameters for the stored procedure here
	@Pccid varchar(10), 
	@Level1 nvarchar(50)
   
    
	
AS
BEGIN
    -- Insert statements for procedure here

	UPDATE dbo.CatStarsFirstLevel
    SET	Active = 'False' , InactiveDate = getdate()
	WHERE Pccid = @Pccid and Star1Name = @Level1

	UPDATE dbo.CatStarsSecondLevel
    SET	Active = 'False' , InactiveDate = getdate()
	WHERE Pccid = @Pccid and Star1id = @Level1	
END








