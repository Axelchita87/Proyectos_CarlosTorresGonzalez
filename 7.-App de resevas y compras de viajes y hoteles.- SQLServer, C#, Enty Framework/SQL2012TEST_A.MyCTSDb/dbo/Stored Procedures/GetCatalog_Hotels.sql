
-- =============================================
-- Author:		Eduardo Sánchez Almazán
-- Create date: Jun-2009
-- =============================================
CREATE Procedure [dbo].[GetCatalog_Hotels]
 AS 
Begin
select CatHotCode [Value], 
(CatHotCode + ' ' + CatHotNameChain) [Text],
CatHotNameChain [Text2], '' [Text3],'' [Text5],'' [Text6],'' [Text7],'' [Text8]
from 
(
Select Distinct rtrim(CatHotCode)CatHotCode, rtrim(CatHotNameChain)CatHotNameChain
		From CatHotels
) as Hotels
 End

