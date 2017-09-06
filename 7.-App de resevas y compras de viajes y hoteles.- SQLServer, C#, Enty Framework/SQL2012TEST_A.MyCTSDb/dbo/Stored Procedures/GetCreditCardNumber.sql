-- =============================================
-- Author:	<Ivan Martínez Guerrero>
-- Modify:	Luis Felipe Segura Velasco
-- Creation date: 17-01-2011
-- Modify date: 10 de Julio de 2012
-- Description:	Search Credit Card Number in INTEGRA
-- =============================================
CREATE PROCEDURE [dbo].[GetCreditCardNumber] 
	@CreditCardNumber varchar(30)
AS
BEGIN
	SET NOCOUNT ON;
	EXEC('SELECT FLEX_VALUE FROM OPENQUERY(CORPP,''SELECT FLEX_VALUE FROM CTS.CTS_VALIDA_TARJETA_V WHERE FLEX_VALUE = ''''' + @CreditCardNumber + ''''''')')
END
-- =============================================
-- EXEC GetCreditCardNumber @CreditCardNumber='5491380091827494'
-- =============================================
