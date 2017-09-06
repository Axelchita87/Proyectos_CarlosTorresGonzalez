-- =============================================
-- Author:		<Jessica Gutierrez>
-- Create date: <08/05/14>
-- Description:	<borra la información de la estrella de segundo nivel por linea>
-- =============================================
create PROCEDURE [dbo].[DeleteStarLevel2byLevel2] 
	-- Add the parameters for the stored procedure here
	@Pccid varchar(10), 
	@Level1 nvarchar(50), 
    @Level2 nvarchar(50)
  
AS
BEGIN
    -- Insert statements for procedure here
	DELETE from dbo.Star2
	WHERE Pccid = @Pccid and Level1 = @Level1 and Level2 = @Level2 
END