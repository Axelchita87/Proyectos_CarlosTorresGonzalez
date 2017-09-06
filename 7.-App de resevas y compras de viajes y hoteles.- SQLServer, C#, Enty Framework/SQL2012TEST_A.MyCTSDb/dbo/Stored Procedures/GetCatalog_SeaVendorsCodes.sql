

-- =============================================
-- Author:		Eduardo Sánchez Almazán
-- Create date: Jun-2009
-- =============================================
CREATE Procedure [dbo].[GetCatalog_SeaVendorsCodes]
 AS 
Begin
select CatSeaVenCodCode [Value], 
(CatSeaVenCodCode + ' ' + CatSeaVenCodName) [Text],
CatSeaVenCodName [Text2], '' [Text3],'' [Text5],'' [Text6],'' [Text7],'' [Text8]
from 
(
Select Distinct rtrim(CatSeaVenCodCode)CatSeaVenCodCode, rtrim(CatSeaVenCodName)CatSeaVenCodName
		From CatSeaVendorsCodes
) as SeaVendorsCodes
 End

