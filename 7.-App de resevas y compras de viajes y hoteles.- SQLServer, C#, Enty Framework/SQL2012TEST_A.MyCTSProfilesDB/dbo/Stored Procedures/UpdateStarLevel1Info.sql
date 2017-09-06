









-- =============================================
-- Author:		<Marcos Q. Ramirez Luna>
-- Create date: <15/Febrero/2010>
-- Description:	<Actualiza la información de la estrella de primer nivel por linea>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateStarLevel1Info] 
	-- Add the parameters for the stored procedure here
	@Pccid nvarchar(10), 
	@Level1 nvarchar(50),
    @Type varchar(1),
    @Text varchar(100),
    @NewText varchar(100)
	
AS
BEGIN
    -- Insert statements for procedure here
	Update dbo.Star1
    set Text = @NewText
    where  Pccid = @Pccid and Level1 = @Level1 and [Type] = @Type and [Text] = @Text
END













