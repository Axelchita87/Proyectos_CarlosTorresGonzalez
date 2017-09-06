
-- =============================================
-- Author:		José Ricardo Brito Ortega
-- Create date: 09/05/2014
-- Description:	Procedimiento para buscar directorio de Logotipo
-- =============================================
CREATE PROCEDURE [dbo].[GetLogoAirlinePath]
	-- Add the parameters for the stored procedure here
	@catAirlinAlfaId VARCHAR(3)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ImageFile FROM CatAirLinLogo where CatAirlinAlfaId = @catAirlinAlfaId
END

