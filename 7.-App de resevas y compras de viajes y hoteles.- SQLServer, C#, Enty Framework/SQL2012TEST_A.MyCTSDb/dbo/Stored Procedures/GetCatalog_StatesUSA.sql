

-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: Jul-2009
-- =============================================
CREATE Procedure [dbo].[GetCatalog_StatesUSA]
 AS 
Begin
select CatStaUSACode [Value], 
(CatStaUSACode + ' ' + CatStaUSAName) [Text],
 CatStaUSAName [Text2], '' [Text3],'' [Text5],'' [Text6],'' [Text7],'' [Text8]
from 
(
Select Distinct rtrim(CatStaUSACode) CatStaUSACode, rtrim(CatStaUSAName) CatStaUSAName
		From dbo.CatStatesUSA
) as StatesUSA
End

