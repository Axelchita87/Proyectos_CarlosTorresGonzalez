
-- =============================================
-- Author:		<Angel Trejo>
-- Creation date: 01-07-2010
-- Description:	Search Airline Code By ID Number
-- Modify by: */
-- =============================================
CREATE PROCEDURE [dbo].[GetAirlineCodeByNumID] 

@NumID varchar(3)

AS
BEGIN
	if((Select count(*)
		from dbo.CatAirLines
		where  CatAirLinNumId=@NumID)>=1)
		begin
			Select CatAirLinAlfaId
			from dbo.CatAirLines
			where  CatAirLinNumId=@NumID
		end
	else
			select 'NOTHING' as CatAirLinAlfaId
END