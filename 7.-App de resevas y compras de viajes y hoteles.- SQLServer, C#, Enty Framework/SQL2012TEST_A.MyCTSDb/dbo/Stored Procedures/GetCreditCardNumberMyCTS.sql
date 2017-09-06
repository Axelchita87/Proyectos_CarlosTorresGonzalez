
-- =============================================
-- Author:	Eduardo Vázquez Orozco
-- Modify:	
-- Creation date: 14-02-2013
-- Modify date: 
-- Description:	Search Credit Card Number in MyCTS
-- =============================================
CREATE PROCEDURE [dbo].[GetCreditCardNumberMyCTS] 
	@CreditCardNumber varchar(30)
AS
BEGIN
	SELECT FLEX_VALUE AS CreditCardNumber  FROM dbo.TC_CTSOracle  WHERE FLEX_VALUE =  @CreditCardNumber
END
-- ================================================
-- EXEC GetCreditCardNumberMyCTS '376689166301008'
-- ================================================

