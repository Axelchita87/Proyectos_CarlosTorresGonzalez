-- =============================================
-- Author:		<Jessica Gutierrez>
-- Create date: <02/04/14>
-- Description:	<Verificar si los vuelos son nacionales>
-- =============================================
CREATE PROCEDURE GetNationalRoutes
@Route as char(5)
AS
BEGIN
	SELECT [CatCitCouId]
	from [dbo].[CatCities]
	where [CatCitId]=@Route
END
