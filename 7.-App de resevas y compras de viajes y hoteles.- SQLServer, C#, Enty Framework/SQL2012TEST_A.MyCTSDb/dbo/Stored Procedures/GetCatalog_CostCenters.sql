

-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: Jul-2009
-- =============================================
CREATE  Procedure [dbo].[GetCatalog_CostCenters]
 AS 
Begin
select IDCC [Value], 
(IDCC + ' ' + CCName) [Text],
 CCName [Text2], '' [Text3],'' [Text5],'' [Text6],'' [Text7],'' [Text8]
from 
(
Select Distinct rtrim(IDCC) IDCC, rtrim(CCName) CCName
		From dbo.CostCenters
) as CostCenters
End
