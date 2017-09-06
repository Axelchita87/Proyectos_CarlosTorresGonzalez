
-- =============================================
-- Author:		Eduardo Vázquez Orozco
-- Creation date: 14-02-2013
-- Description:	Search Credit Card Number in MyCTS
-- Modify by: */
-- =============================================
CREATE PROCEDURE [dbo].[GetClientCreditCardNumberMyCTS]
	@CreditCardNumber varchar(30), 
	@ClientNum varchar (30) = null
AS
BEGIN
	SELECT CUENTA, DK NUM_CLIENTE ,TIPO FROM dbo.TC_ClientsOracle
	WHERE CUENTA = @CreditCardNumber-- and DK=@ClientNum
END

-- ================================================================
-- exec GetClientCreditCardNumberMyCTS  '192000002054912','ACS100'
-- ================================================================	
