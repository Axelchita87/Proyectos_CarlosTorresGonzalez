-- =============================================
-- Author:		José Ricardo Brito Ortega
-- Create date: 10/07/2014
-- Description:	Procedimiento que devuelve datos para los predictivos de los codigos de moneda.
-- =============================================
CREATE PROCEDURE [dbo].[GetCurrencyCountry_Predictive]
	-- Add the parameters for the stored procedure here
	@StrToSearch VARCHAR(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT CatCurCouAutoId, CatCurCouId, CatCurCouCode, CatCurCouName from CatCurrencyCountry WHERE CatCurCouCode LIKE @StrToSearch + '%';
END