


-- =============================================
-- Author:		<Marcos Q. Ramirez Luna>
-- Create date: <18/Febrero/2010>
-- Update by:      <Emanuel Flores>
-- Update date  <08/Junio/2010>
-- Description:	<Actualiza la información de la estrella de segundo nivel>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateStarLevel2] 
	-- Add the parameters for the stored procedure here
	@Pccid nvarchar(10), 
    @Level1 nvarchar(50),
	@Level2 nvarchar(50),
    @NewLevel2 nvarchar(50),
	@Email nvarchar(50)
    
AS
BEGIN
    -- Insert statements for procedure here

	DELETE FROM CatStarsSecondLevel
    WHERE Pccid = @Pccid and Star1id = @Level1 and Star2Name = @Level2
      
    INSERT INTO dbo.CatStarsSecondLevel(Pccid, Star1id, Star2Name, Active, InactiveDate,IsNew)
	VALUES(@PCCid, @level1, @NewLevel2, 1, NULL ,1)
	
	UPDATE dbo.Star2
	SET Level2=@NewLevel2
	WHERE Pccid = @Pccid and Level1 = @Level1 and Level2 = @Level2

	DELETE FROM dbo.Star2
	WHERE Pccid = @Pccid and Level1 = @Level1 and Level2 = @NewLevel2 and Metadata='Mail' 

	INSERT INTO dbo.Star2 (Pccid, Level1, Level2, [Type], [Text], Email)
	VALUES (@Pccid, @Level1, @NewLevel2, 'A', 'PE‡'+@Email+'‡', @Email)
	
      
	
	--Update dbo.Star2
	--set Level2 = @NewLevel2, Purged = 1
	--where  Pccid = @Pccid and Level1 = @Level1 and Level2 = @Level2
END
