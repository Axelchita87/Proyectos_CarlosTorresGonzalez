

-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: Jul-2009
-- =============================================
CREATE  Procedure [dbo].[GetCatalog_PAirLinesFare]
 AS 
Begin
select CatAirLinFarId [Value], 
(CatAirLinFarId + ' ' + CatAirLinFarName) [Text],
 CatAirLinFarName [Text2], '' [Text3],'' [Text5],'' [Text6],'' [Text7],'' [Text8]
from 
(
Select Distinct rtrim(CatAirLinFarId) CatAirLinFarId, rtrim(CatAirLinFarName) CatAirLinFarName
		From dbo.CatAirLinesFare
) as PAirLinesFare
End
