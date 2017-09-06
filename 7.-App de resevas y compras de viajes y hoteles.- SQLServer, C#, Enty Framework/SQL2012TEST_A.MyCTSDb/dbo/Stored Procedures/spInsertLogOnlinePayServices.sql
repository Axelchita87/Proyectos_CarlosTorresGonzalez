-- =============================================
-- Author:		Luis Felipe Segura Velasco
-- Create date: 07 de Febrero de 2013
-- Description: Procedimiento que inserta pagos pendientes de generar boletos
-- =============================================
CREATE PROCEDURE [dbo].[spInsertLogOnlinePayServices]
	 @fcFormTypeCodeFOP nvarchar(10)
	,@fiPaxNumber int
	,@fcPNR varchar(10)
	,@fcAutorization varchar(10)
	,@fcOperation varchar(10)
	,@fcTarjeta varchar(16)
	,@fdMonto decimal(18,2)
	,@fcBoleto varchar(50)
	,@fcRemark varchar(100)
AS
BEGIN

	SET NOCOUNT ON;

	IF @fcTarjeta IS NULL
		SELECT @fcTarjeta = ''

	DECLARE @fcTarjetaModificada varchar(16)	

	SELECT @fcTarjetaModificada = SUBSTRING(@fcTarjeta, 1, 4) + REPLICATE('X', DATALENGTH(@fcTarjeta)-8) + SUBSTRING(@fcTarjeta, DATALENGTH(@fcTarjeta)-3,4)

	IF (@fcAutorization <> '' AND @fcAutorization IS NOT NULL AND @fcOperation <> '' AND @fcOperation IS NOT NULL)	
	BEGIN
		IF (SELECT COUNT(fcPNR) FROM [dbo].[LogOnlinePayServices] WHERE [fcPNR] = @fcPNR AND [fcAutorization] = @fcAutorization	AND [fcOperation] = @fcOperation) = 0
		BEGIN
			INSERT INTO [dbo].[LogOnlinePayServices]
					   ([fcFormTypeCodeFOP]
					   ,[fiPaxNumber]
					   ,[fcPNR]
					   ,[fcAutorization]
					   ,[fcOperation]
					   ,[fcTarjeta]
					   ,[fdMonto]
					   ,[fcBoleto]
					   ,[fcRemark])
				 VALUES
					   (@fcFormTypeCodeFOP
					   ,@fiPaxNumber
					   ,@fcPNR
					   ,@fcAutorization
					   ,@fcOperation
					   ,ISNULL(@fcTarjetaModificada,'')
					   ,@fdMonto
					   ,@fcBoleto
					   ,@fcRemark)
		END
	END
END
-- =============================================
-- EXEC spInsertLogOnlinePayServices 'CCAC','1','BBBBBB','227702','106080498','376698935991007','50.00' 
-- =============================================
