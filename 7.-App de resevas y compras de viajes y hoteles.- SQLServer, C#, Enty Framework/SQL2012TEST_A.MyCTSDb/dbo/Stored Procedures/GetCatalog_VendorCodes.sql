

-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: Jul-2009
-- =============================================
CREATE  Procedure [dbo].[GetCatalog_VendorCodes]
 AS 
Begin
select CatCarVenCodCode [Value], 
(CatCarVenCodCode + ' ' + CatCarVenCodName) [Text],
 CatCarVenCodName [Text2], '' [Text3],'' [Text5],'' [Text6],'' [Text7],'' [Text8]
from 
(
Select Distinct rtrim(CatCarVenCodCode) CatCarVenCodCode, rtrim(CatCarVenCodName) CatCarVenCodName
		From dbo.CatCarVendorsCodes
) as VendorsCodes
End

