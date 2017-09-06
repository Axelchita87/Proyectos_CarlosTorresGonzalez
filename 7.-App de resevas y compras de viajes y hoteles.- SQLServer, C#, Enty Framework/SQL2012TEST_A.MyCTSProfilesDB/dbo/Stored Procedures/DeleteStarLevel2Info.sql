









-- =============================================
-- Author:		<Marcos Q. Ramirez Luna>
-- Create date: <17/Febrero/2010>
-- Description:	<borra la información de la estrella de segundo nivel por linea>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteStarLevel2Info] 
	-- Add the parameters for the stored procedure here
	@Pccid varchar(10), 
	@Level1 nvarchar(50), 
    @Level2 nvarchar(50),
    @Type varchar(100),
    @Text varchar(50)
	
AS
BEGIN
    -- Insert statements for procedure here
	DELETE from dbo.Star2
	WHERE Pccid = @Pccid and Level1 = @Level1 and Level2 = @Level2 and [Type] = @Type and [Text] = @Text
END













