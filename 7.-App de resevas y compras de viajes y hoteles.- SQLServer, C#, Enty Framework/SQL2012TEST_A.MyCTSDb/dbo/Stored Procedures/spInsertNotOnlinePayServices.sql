-- =============================================
-- Author:		Luis Felipe Segura Velasco
-- Create date: 07 de Febrero de 2013
-- Description:	PA que inserta en la tabla los destinos de respuesta del servicio de viajanet
-- =============================================
CREATE PROCEDURE [dbo].[spInsertNotOnlinePayServices]
	 @fcFormTypeCodeFOP nvarchar(10)
	,@fiPaxNumber int
	,@fcPNR varchar(10)
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
	DECLARE @fdFolioInterno varchar(10)

	IF @fcFormTypeCodeFOP = 'CCTC'
		SELECT @fcTarjetaModificada = SUBSTRING(@fcTarjeta, 1, 4) + REPLICATE('X', DATALENGTH(@fcTarjeta)-8) + SUBSTRING(@fcTarjeta, DATALENGTH(@fcTarjeta)-3,4)
	ELSE
		SELECT @fcTarjetaModificada = @fcTarjeta

	SELECT @fdFolioInterno = (count(fcPNR) + 1) FROM [dbo].[LogOnlinePayServices] WHERE fcFormTypeCodeFOP = @fcFormTypeCodeFOP 

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
				   ,''
				   ,@fdFolioInterno
				   ,ISNULL(@fcTarjetaModificada,'')
				   ,@fdMonto
				   ,@fcBoleto
				   ,@fcRemark)

	SELECT @fdFolioInterno AS fdFolioInterno

END
-- =============================================
-- EXEC spInsertNotOnlinePayServices 'CCAC','1','AAAAAA','5454545454545454','50.00'
-- =============================================
