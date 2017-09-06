
-- =============================================
-- Author:		Eduardo Vázquez Orozco
-- Creation date: 14-02-2013
-- Description:	Search Credit Card Number in MyCTS
-- Modify by: */
-- =============================================
CREATE PROCEDURE [dbo].[GetClientCreditCardByNumberMyCTS]

@CreditCardNumber varchar(30)

AS
BEGIN
	SELECT CUENTA as CreditCardNumber  FROM dbo.TC_ClientsOracle
	WHERE CUENTA = @CreditCardNumber
END

-- =======================================================
-- exec GetClientCreditCardByNumberMyCTS '376704305571005'
-- =======================================================
