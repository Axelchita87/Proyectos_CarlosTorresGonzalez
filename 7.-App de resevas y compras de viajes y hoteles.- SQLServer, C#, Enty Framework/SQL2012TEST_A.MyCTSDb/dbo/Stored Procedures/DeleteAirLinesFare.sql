

-- =============================================
-- Author:		<Jessica Gutierrez Becerril>
-- Creation date: 01-06-2010
-- Description:	Delete AirLinesFare 
-- Modify by: */
-- =============================================
create PROCEDURE [dbo].[DeleteAirLinesFare] 

@CatAirLinFarId varchar(5)

AS
BEGIN
	delete dbo.CatAirLinesFare
	where CatAirLinFarId=@CatAirLinFarId 

END