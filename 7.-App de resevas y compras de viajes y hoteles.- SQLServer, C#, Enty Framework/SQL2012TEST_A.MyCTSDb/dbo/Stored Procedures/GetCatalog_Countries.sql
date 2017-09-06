
-- =============================================
-- Author:		Eduardo Sánchez Almazán
-- Create date: Jun-2009
-- =============================================
CREATE Procedure [dbo].[GetCatalog_Countries]
 AS 
Begin
select CatCouId [Value], 
(CatCouId + ' ' + CatCouName) [Text],
CatCouName [Text2], '' [Text3],'' [Text5],'' [Text6],'' [Text7],'' [Text8]
from 
(
Select Distinct rtrim(CatCouId) CatCouId, rtrim(CatCouName) CatCouName
		From CatCountries
) as Countries
 End

