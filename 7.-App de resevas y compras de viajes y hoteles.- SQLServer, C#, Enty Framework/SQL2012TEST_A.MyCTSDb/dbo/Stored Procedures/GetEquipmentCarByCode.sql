-- =============================================
-- Author:		José Ricardo Brito Ortega
-- Create date: 13/11/2014
-- Description:	Obtiene la descripcion del equipo adicional de un auto de acuerdo a su codigo
-- =============================================
CREATE PROCEDURE GetEquipmentCarByCode 
	-- Add the parameters for the stored procedure here
	@code nchar(3)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ISNULL((SELECT [Description] FROM CatEquipmentCar WHERE code = @code), 'No encontrado') AS Equipment;
END
