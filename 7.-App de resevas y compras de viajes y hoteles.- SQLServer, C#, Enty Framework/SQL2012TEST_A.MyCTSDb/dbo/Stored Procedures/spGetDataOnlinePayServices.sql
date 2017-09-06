-- =============================================
-- Author:		Luis Felipe Segura Velasco
-- Create date: 24 de Septiembre de 2012
-- Description: Procedimiento que inserta pagos pendientes de generar boletos
-- =============================================
CREATE PROCEDURE [dbo].[spGetDataOnlinePayServices]
	 @fcAutorization varchar(10)
	 ,@fcOperation varchar(10)
AS
BEGIN

	SELECT 
		[fcFormTypeCodeFOP]
	   ,[fiPaxNumber]
	   ,[fcPNR]
	   ,[fcTarjeta]
	   ,[fdMonto]
	FROM [dbo].[LogOnlinePayServices]			
	WHERE [fcAutorization] = @fcAutorization
	   AND [fcOperation] = @fcOperation
END
-- =============================================
-- EXECUTE spGetDataOnlinePayServices '405158', '000239221'
-- =============================================
