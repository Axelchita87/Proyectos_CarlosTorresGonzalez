







-- =============================================
-- Author:		<Marcos Q. Ramirez Luna>
-- Create date: <15/Febrero/2010>
-- Description:	<Actualiza la información de la estrella de segundo nivel por linea>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateStarLevel2Info] 
	-- Add the parameters for the stored procedure here
	@Pccid varchar(10), 
	@Level1 nvarchar(50),
    @Level2 nvarchar(50),
    @Type varchar(1),
    @Text varchar(100),
    @NewText varchar(100) 
	
AS
BEGIN
    -- Insert statements for procedure here
	Update dbo.Star2
    set Text = @NewText
    where  Pccid = @Pccid and Level1 = @Level1 and Level2 = @Level2 and [Type] = @Type and [Text] = @Text 
END











