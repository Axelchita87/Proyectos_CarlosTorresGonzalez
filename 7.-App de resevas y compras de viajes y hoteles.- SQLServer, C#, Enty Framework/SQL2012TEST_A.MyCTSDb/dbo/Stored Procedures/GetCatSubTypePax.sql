-- =============================================
-- Author:		José Ricardo Brito Ortega
-- Create date: 22/07/2014
-- Description:	Obtiene todos los tipos de pasajeros dentro de la base de datos.
-- =============================================
CREATE PROCEDURE GetCatSubTypePax
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select CatTypPaxAutonumeric, CatTypPaxId, CatSubTypPaxId, CatSubTypPaxName from CatSubTypePax
END
