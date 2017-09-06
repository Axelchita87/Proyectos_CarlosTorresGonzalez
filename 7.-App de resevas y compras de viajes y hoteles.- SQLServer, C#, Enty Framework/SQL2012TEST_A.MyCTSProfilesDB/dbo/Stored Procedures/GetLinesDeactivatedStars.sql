
-- =============================================
-- Author:		<Ivan Martínez Guerrero>
-- Create date: <22 Octubre 2011>
-- Description:	<Procedure that gets the star information for the historic data>
-- =============================================
CREATE PROCEDURE [dbo].[GetLinesDeactivatedStars] 
	@level1 as varchar(40),
	@pcc as varchar (6)	   
    
	
AS
BEGIN
	
	Select [Text] From dbo.Star1
	Where Level1=@level1 and Pccid =@pcc

END