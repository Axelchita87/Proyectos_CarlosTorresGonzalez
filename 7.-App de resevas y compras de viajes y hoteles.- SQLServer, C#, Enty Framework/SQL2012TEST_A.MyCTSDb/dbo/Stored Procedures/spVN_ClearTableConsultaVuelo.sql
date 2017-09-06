-- =============================================
-- Author:		Luis Felipe Segura Velasco
-- Create date: 28 de marzo de 2012
-- Description:	PA que limpia la tabla del servicio de viajanet
-- =============================================
CREATE PROCEDURE spVN_ClearTableConsultaVuelo
AS
BEGIN
	SET NOCOUNT ON;

	TRUNCATE TABLE tblViajanetTempDestinos
END
