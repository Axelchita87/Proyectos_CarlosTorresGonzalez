




-- =============================================
-- Author:		<Marcos Q. Ramirez Luna>
-- Create date: <22/Enero/2010>
-- Description:	<Inserta estrellas de primer nivel con su PCC respectivo>
-- =============================================
CREATE PROCEDURE [dbo].[SetStarsLevel1] 
	-- Add the parameters for the stored procedure here
	@Pccid nvarchar(10), 
	@Star1Name nvarchar(50),
    @StarL2Exist bit,
    @Active bit    
	
AS
BEGIN
    -- Insert statements for procedure here
	INSERT INTO  dbo.CatStarsFirstLevel(Pccid, Star1Name, StarL2Exist, Active, InactiveDate,IsNew, dk)
	VALUES(@Pccid, @Star1Name, @StarL2Exist, @Active, NULL,1, @Star1Name)
	
	INSERT INTO  dbo.Star1(Pccid, Level1, [Type], [Text], Date, Purged)
	VALUES(@Pccid, @Star1Name,'A' , null, null, 'False')

END

----------------------------------------------------------------------------------------------

SET ANSI_NULLS ON
