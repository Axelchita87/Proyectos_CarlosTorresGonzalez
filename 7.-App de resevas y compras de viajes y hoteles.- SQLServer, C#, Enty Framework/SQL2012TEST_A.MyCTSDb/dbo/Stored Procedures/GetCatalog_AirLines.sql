

-- =============================================
-- Author:		Eduardo Sánchez Almazán
-- Create date: Jun-2009
-- =============================================
CREATE Procedure [dbo].[GetCatalog_AirLines]
 AS 
Begin
select CatAirLinAlfaId [Value], 
(CatAirLinAlfaId + ' ' + CatAirLinName) [Text],
CatAirLinName [Text2],'' [Text3],'' [Text5],'' [Text6],'' [Text7],'' [Text8]
from 
(
Select Distinct rtrim(CatAirLinAlfaId) CatAirLinAlfaId, rtrim(CatAirLinName) CatAirLinName
		From  dbo.CatAirLines
) as AirLines
 End


