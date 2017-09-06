
-- =============================================
-- Author:	Eduardo Vázquez Orozco
-- Modify:	
-- Creation date: 14-02-2013
-- Modify date: 
-- Description:	Search Credit Card Number in MyCTS
---             POR DK, TIPO, ORGID
-- =============================================
CREATE PROCEDURE [dbo].[GetCreditCardNumberMyCTS2] 
	@DK VARCHAR(30),
	@TIPO VARCHAR(30)

AS
BEGIN
	SET NOCOUNT ON;
	SELECT *  FROM dbo.TC_ClientsOracle  WHERE DK=@DK AND TIPO=@TIPO
END
-- =================================================================
-- EXEC [GetCreditCardNumberMyCTS2] @DK=ACS100, @TIPO=AIR
-- =================================================================
