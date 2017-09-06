









-- =============================================
-- Author:		<Marcos Q. Ramirez Luna>
-- Create date: <17/Febrero/2010>
-- Description:	<borra la información de la estrella de primer nivel por linea>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteStarLevel1Info] 
	-- Add the parameters for the stored procedure here
	@Pccid varchar(10), 
	@Level1 nvarchar(50),
    @Type varchar(10),
    @Text varchar(50) 
	
AS
BEGIN
    -- Insert statements for procedure here
	DELETE from dbo.Star1
	WHERE Pccid = @Pccid and Level1 = @Level1 and [Type] = @Type and [Text] = @Text 
END













