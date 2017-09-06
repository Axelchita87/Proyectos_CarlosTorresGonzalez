-- =============================================
-- Author:		Luis Felipe Segura Velasco
-- Create date: 17 de Septiembre de 2012
-- Description: Procedimiento que inserta pagos pendientes de generar boletos
-- =============================================
CREATE PROCEDURE [dbo].[spGetOnlinePayServices]
	 @fcFormTypeCodeFOP nvarchar(10)
	,@fcPNR varchar(10)
	,@fcTarjeta varchar(16)
	,@fiPaxNumber int
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
	WHERE
	    [fcFormTypeCodeFOP] = @fcFormTypeCodeFOP
	    AND @fcPNR = @fcPNR
	    AND [fcTarjeta] = @fcTarjeta
		AND [fiPaxNumber] = @fiPaxNumber
END
-- =============================================
-- EXECUTE spGetOnlinePayServices 'CCAC','DHFCRD','2131231231231231'
-- =============================================
