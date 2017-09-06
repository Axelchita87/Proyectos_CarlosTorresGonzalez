-- =============================================
-- Author:		José Ricardo Brito Ortega
-- Create date: 29/07/2014
-- Description:	Obtiene Aeropuerto y ciudad a partir de la clave de aeropuerto.
-- =============================================
CREATE PROCEDURE GetAirporName
	-- Add the parameters for the stored procedure here
	@airportCode NVARCHAR(3)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT A.*, C.CatCouName FROM CatAirPorts A
	INNER JOIN CatCountries C ON C.CatCouId = A.CatAirPorCountryId
	WHERE CatAirPorCode = @airportCode
END
