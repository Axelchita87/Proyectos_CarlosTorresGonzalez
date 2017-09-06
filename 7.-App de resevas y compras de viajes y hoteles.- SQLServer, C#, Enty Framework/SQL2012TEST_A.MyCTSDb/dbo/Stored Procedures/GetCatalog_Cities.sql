

-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: Jul-2009
-- =============================================
CREATE Procedure [dbo].[GetCatalog_Cities]
 AS 
Begin
select CatCitId [Value], 
(CatCitId + ' ' + CatCitName) [Text],
CatCitName [Text2], '' [Text3],'' [Text5],'' [Text6],'' [Text7],'' [Text8]
from 
(
Select Distinct rtrim(CatCitId) CatCitId, rtrim(CatCitName) CatCitName
		From dbo.CatCities
) as Cities
End

