-- =============================================
-- Author:		<Ivan Martínez Guerrero>
-- Creation date: 17-01-2011
-- Description:	Search Credit Card Number in INTEGRA
-- Modify by: */
-- =============================================
CREATE PROCEDURE [dbo].[GetClientCreditCardNumber] 

@CreditCardNumber varchar(30),
@ClientNum varchar (30)

AS
BEGIN
	SELECT CUENTA,NUM_CLIENTE,TIPO FROM CORPP..APPS.CTS_ARCTESAMXAIR_V
	WHERE CUENTA = @CreditCardNumber and NUM_CLIENTE=@ClientNum
END