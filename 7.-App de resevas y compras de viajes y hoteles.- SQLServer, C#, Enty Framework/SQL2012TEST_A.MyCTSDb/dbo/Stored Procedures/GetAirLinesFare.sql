

-- =============================================
-- Author:		<-->
-- Create date: <Create Date,, 02-06-2010>
-- Description:	<Description,,>
-- Modify: Jessica Gutierrez
-- =============================================
CREATE PROCEDURE [dbo].[GetAirLinesFare]
	-- Add the parameters for the stored procedure here
AS
BEGIN
  SELECT CatAirLinFarId,CatAirLinFarName,CCAut,CCMan,Cash,PMix,Misc
  FROM dbo.CatAirLinesFare 
  ORDER BY CatAirLinFarName
	
END

