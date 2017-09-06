

-- =============================================
-- Author:		<Ivan Martínez Guerrero>
-- Create date: <22 Octubre 2011>
-- Description:	<Procedure that gets the star names for the historic data>
-- =============================================
CREATE PROCEDURE [dbo].[GetDeactivatedStars] 
	@dk as varchar(6)	   
    
	
AS
BEGIN

    /*Select Distinct Star1Name As 'Level1', CF.pccId As 'Pcc' From dbo.CatStarsFirstLevel CF
	Inner Join Star1 S1 On CF.Star1Name=S1.Level1
	Where S1.Level1=CF.Star1Name and S1.Metadata='Numero de Cliente' and Substring([Text],3,6)=@dk*/
    Select Distinct Star1Name As 'Level1', CF.pccId As 'Pcc' From dbo.CatStarsFirstLevel CF
    Where CF.DK = @dk
	--Inner Join Star1 S1 On CF.Star1Name=S1.Level1
	--Where S1.Level1=CF.Star1Name and S1.Metadata='Numero de Cliente' and Substring([Text],3,6)=@dk
    
END

----------------------------------------------------------------------------------------------

SET ANSI_NULLS ON
