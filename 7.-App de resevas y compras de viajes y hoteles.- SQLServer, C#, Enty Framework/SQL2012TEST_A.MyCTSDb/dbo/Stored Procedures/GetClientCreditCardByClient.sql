-- =============================================
-- Author:		<Ivan Martínez Guerrero>
-- Creation date: 17-01-2011
-- Description:	Search Credit Card Number in INTEGRA
-- Modify by: */
-- =============================================
CREATE PROCEDURE [dbo].[GetClientCreditCardByClient] 
	@ClientNum varchar(30)
AS
BEGIN
	SELECT CUENTA,NUM_CLIENTE,TIPO FROM CORPP..APPS.CTS_ARCTESAMXAIR_V
	WHERE NUM_CLIENTE=@ClientNum
END
