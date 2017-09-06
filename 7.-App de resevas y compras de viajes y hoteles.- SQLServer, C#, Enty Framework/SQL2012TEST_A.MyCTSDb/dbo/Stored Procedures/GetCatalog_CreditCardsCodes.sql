
-- =============================================
-- Author:		Eduardo Sánchez Almazán
-- Create date: Jun-2009
-- =============================================
CREATE Procedure [dbo].[GetCatalog_CreditCardsCodes]
 AS 
Begin
select CatCreCarCodCode [Value], 
(CatCreCarCodCode + ' ' + CatCreCarCodName) [Text],
CatCreCarCodName [Text2], '' [Text3],'' [Text5],'' [Text6],'' [Text7],'' [Text8]
from 
(
Select Distinct rtrim(CatCreCarCodCode)CatCreCarCodCode, rtrim(CatCreCarCodName)CatCreCarCodName
		From CatCreditCardCodes
) as CreditCard
 End

