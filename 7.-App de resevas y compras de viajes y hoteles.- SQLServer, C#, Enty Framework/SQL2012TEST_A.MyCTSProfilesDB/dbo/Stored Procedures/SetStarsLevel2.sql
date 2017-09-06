


-- =============================================
-- Author:		<Marcos Q. Ramirez Luna>
-- Create date: <22/Enero/2010>
-- Description:	<Inserta estrellas de segundo nivel con su PCC y primer nivel respectivo>
-- =============================================
CREATE PROCEDURE [dbo].[SetStarsLevel2] 
	-- Add the parameters for the stored procedure here
	@Pccid nvarchar(10), 
	@Star1id nvarchar(50),
    @Star2Name nvarchar(50),
    @Active bit,
	@Email varchar(50)
	
AS
BEGIN
    -- Insert statements for procedure here
	INSERT INTO dbo.CatStarsSecondLevel(Pccid, Star1id, Star2Name, Active, InactiveDate,IsNew)
	VALUES(@PCCid, @Star1id, @Star2Name, @Active, NULL,1)

	INSERT INTO dbo.Star2 (Pccid, Level1, Level2, [Type], [Text], Email)
	VALUES (@PCCid, @Star1id, @Star2Name, 'A', 'PE‡'+@Email+'‡', @Email)

END

---------------------------------------------------------------------------------------------

SET ANSI_NULLS ON
