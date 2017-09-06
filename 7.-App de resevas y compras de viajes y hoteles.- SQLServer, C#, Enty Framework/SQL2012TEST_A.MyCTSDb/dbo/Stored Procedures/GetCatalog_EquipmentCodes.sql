

-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: Jul-2009
-- =============================================
CREATE Procedure [dbo].[GetCatalog_EquipmentCodes]
 AS 
Begin
select CatCarEquCodCode [Value], 
(CatCarEquCodCode + ' ' + CatCarEquCodName) [Text],
 CatCarEquCodName [Text2], '' [Text3],'' [Text5],'' [Text6],'' [Text7],'' [Text8]
from 
(
Select Distinct rtrim(CatCarEquCodCode) CatCarEquCodCode, rtrim(CatCarEquCodName) CatCarEquCodName
		From dbo.CatCarEquipmentCodes
) as EquipmentCodes
End

