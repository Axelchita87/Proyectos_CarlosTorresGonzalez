-- =============================================
-- Author:		<Ivan Martínez Guerrero>
-- Creation date: 17-01-2011
-- Description:	Search Credit Card Number in INTEGRA
-- Modify by: */
-- =============================================
CREATE PROCEDURE [dbo].[GetClientCreditCardByNumber] 
	@CreditCardNumber varchar(30)
AS
BEGIN
	SELECT CUENTA FROM CORPP..APPS.CTS_ARCTESAMXAIR_V
	WHERE CUENTA = @CreditCardNumber
END