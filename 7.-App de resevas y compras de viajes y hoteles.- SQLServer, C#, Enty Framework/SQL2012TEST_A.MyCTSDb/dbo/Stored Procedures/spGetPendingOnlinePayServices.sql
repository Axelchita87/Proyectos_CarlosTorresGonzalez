-- =============================================
-- Author:		Luis Felipe Segura Velasco
-- Create date: 24 de Septiembre de 2012
-- Description: Procedimiento que obtiens lo pagos pendientes de generar boletos
-- =============================================
CREATE PROCEDURE [dbo].[spGetPendingOnlinePayServices]
	@fcPNR varchar(10)
AS
BEGIN

	SELECT 
		[fcFormTypeCodeFOP]
	   ,[fiPaxNumber]
	   ,[fcPNR]
	   ,[fcAutorization]
	   ,[fcOperation]
	   ,[fcTarjeta]
	   ,[fdMonto]
	FROM [dbo].[LogOnlinePayServices]			
	WHERE [fcPNR] = @fcPNR	 
	    AND (fcBoleto = '' or fcBoleto is null)
	ORDER BY [fiPaxNumber]
END
-- =============================================
-- EXECUTE spGetPendingOnlinePayServices 'LNBWWJ'
-- =============================================
