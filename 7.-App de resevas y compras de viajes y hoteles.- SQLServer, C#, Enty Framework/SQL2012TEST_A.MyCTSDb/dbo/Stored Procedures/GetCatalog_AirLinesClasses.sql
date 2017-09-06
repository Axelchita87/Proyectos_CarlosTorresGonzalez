

-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: Jul-2009
-- =============================================
CREATE Procedure [dbo].[GetCatalog_AirLinesClasses]
 AS 
Begin
select CatAirLinClaId [Value], 
(CatAirLinClaId + ' ' + CatAirLinClaName) [Text],
CatAirLinClaName [Text2], '' [Text3],'' [Text5],'' [Text6],'' [Text7],'' [Text8]
from 
(
Select Distinct rtrim(CatAirLinClaId) CatAirLinClaId, rtrim(CatAirLinClaName) CatAirLinClaName
		From dbo.CatAirLinesClass
) as AirLinesClasses
End

