
-- =============================================
-- Author:		<Ivan Martínez Guerrero>
-- Create date: <22 Octubre 2011>
-- Description:	<Procedure that gets the star information for the historic data>
-- =============================================
CREATE PROCEDURE [dbo].[GetDeactivatedStarSecondLevel] 
	@name as varchar(max),
	@level1 as varchar(max)
	
AS
BEGIN
	
	Select [Text] From dbo.Star2
	Where Level2=@name and Level1=@level1

END