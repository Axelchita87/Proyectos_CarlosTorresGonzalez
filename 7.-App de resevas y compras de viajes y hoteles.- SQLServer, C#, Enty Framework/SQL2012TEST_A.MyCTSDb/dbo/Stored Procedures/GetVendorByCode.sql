-- =============================================
-- Author:		José Ricardo Brito Ortega
-- Create date: 13/11/2014
-- Description:	Obtiene el nombre de la arrendadora de autos a partir de su codigo.
-- =============================================
CREATE PROCEDURE GetVendorByCode 
	-- Add the parameters for the stored procedure here
	@code nchar(2)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ISNULL((SELECT Vendor FROM CatVendorCar WHERE code = @code), @code) AS Vendor;


END
