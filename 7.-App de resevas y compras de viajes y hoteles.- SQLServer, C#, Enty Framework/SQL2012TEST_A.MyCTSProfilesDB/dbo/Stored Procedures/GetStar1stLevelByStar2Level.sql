-- =============================================
-- Author:		Ivan Martinez Guerrero
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GetStar1stLevelByStar2Level]
@star1Name varchar(30),
@pccid varchar(4)
AS
BEGIN
	Select IsNew from dbo.CatStarsFirstLevel
	where Star1Name=@star1Name and Pccid=@pccid
END

----------------------------------------------------------------------------------------------



