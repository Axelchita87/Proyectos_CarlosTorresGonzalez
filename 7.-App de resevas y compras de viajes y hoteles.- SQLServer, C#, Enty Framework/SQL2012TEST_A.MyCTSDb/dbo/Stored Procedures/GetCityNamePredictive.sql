-- =============================================
-- Author:		José Ricardo Brito Ortega
-- Create date: 23/07/2014
-- Description:	Obtiene un resultado para los campos predictivos de ciudad
-- =============================================
CREATE PROCEDURE GetCityNamePredictive
	-- Add the parameters for the stored procedure here
	@cityCode NVARCHAR(3)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT CatCitId, CatCitName, CatCitCouId FROM CatCities WHERE CatCitId LIKE @CityCode + '%'
END
