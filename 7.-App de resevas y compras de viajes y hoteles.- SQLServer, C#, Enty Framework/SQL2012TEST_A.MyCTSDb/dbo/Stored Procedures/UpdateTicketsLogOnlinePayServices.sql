-- =============================================
-- Author:		Luis Felipe Segura Velasco
-- Create date: 3 de Octubre de 2012
-- Description: Store procedure que actualiza el numero del boleto
-- =============================================
CREATE PROCEDURE [dbo].[UpdateTicketsLogOnlinePayServices]
	@fcFormTypeCodeFOP nvarchar(10),
	@fiPaxNumber int,
	@fcPNR varchar(10),
	@fcAutorization varchar(10),
	@fcOperation varchar(10),
	@fcBoleto varchar(50),
	@fcRemark varchar(100)
AS
BEGIN
	IF (@fcFormTypeCodeFOP = 'CCAC' OR @fcFormTypeCodeFOP = 'CCPV')
	BEGIN
		UPDATE [dbo].[LogOnlinePayServices]
		   SET [fcBoleto] = @fcBoleto,
			   [fcRemark] = @fcRemark
		 WHERE [fcFormTypeCodeFOP] = @fcFormTypeCodeFOP
			  AND [fiPaxNumber] = @fiPaxNumber
			  AND [fcPNR] = @fcPNR
			  AND [fcAutorization] = @fcAutorization
			  AND [fcOperation] = @fcOperation
	END
	ELSE
	BEGIN
		UPDATE [dbo].[LogOnlinePayServices]
		   SET [fcRemark] = @fcRemark
		 WHERE [fcFormTypeCodeFOP] = @fcFormTypeCodeFOP
			  AND [fiPaxNumber] = @fiPaxNumber
			  AND [fcPNR] = @fcPNR
			  AND [fcOperation] = @fcOperation
			  AND [fcBoleto] = @fcBoleto
	END
END
-- =============================================
-- EXEC UpdateTicketsLogOnlinePayServices 'CCAC',1,'IRHVFJ','558516','000266232','7685386551', '5.</C23-01*12.34-CCAC-5454545454545454-000266232-558516-7685386551/>'
-- =============================================