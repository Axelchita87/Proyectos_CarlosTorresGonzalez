-- =============================================
-- Author:		Eduardo Vázquez Orozco
-- Creation date: 17-01-2011
-- Description:	Search Credit Card Number in MyCTS
-- Modify by: */
-- =============================================
CREATE PROCEDURE [dbo].[GetClientCreditCardByClientMyCTS]

@ClientNum varchar(30)

AS
BEGIN
	SELECT CUENTA,DK AS NUM_CLIENTE,TIPO FROM dbo.TC_ClientsOracle
	WHERE DK=@ClientNum
END
-- ===============================================
-- exec GetClientCreditCardByClientMyCTS 'CFE101'
-- ===============================================
