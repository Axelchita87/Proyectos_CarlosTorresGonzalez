-- =============================================
-- Author:		Eduardo Sánchez Almazán
-- Create date: Jun-2009
-- =============================================
CREATE Procedure [dbo].[GetCatalog_CurrenciesCountries]
 
AS
begin

select CatCurCouCode [Value], 
(CatCurCouCode + ' ' + CatCurCouName + ' ' + CatCouName) [Text],
CatCurCouName [Text2], CatCouName [Text3],'' [Text5],'' [Text6],'' [Text7],'' [Text8]
from 
	(
	Select Distinct CCC.CatCurCouCode, CCC.CatCurCouName, CC.CatCouName, CC.CatCouId
		From CatCurrencyCountry CCC
		Inner Join CatCountries CC On CC.CatCouId = CCC.CatCurCouId
	) as CurrencyCountry

end
