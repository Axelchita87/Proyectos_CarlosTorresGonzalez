

-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: Jul-2009
-- =============================================
CREATE Procedure [dbo].[GetCatalog_TypesCodes]
 AS 
Begin
select CatCarTypCodCode [Value], 
(CatCarTypCodCode + ' ' + CatCarTypCodDescription) [Text],
 CatCarTypCodDescription [Text2], '' [Text3],'' [Text5],'' [Text6],'' [Text7],'' [Text8]
from 
(
Select Distinct rtrim(CatCarTypCodCode) CatCarTypCodCode, rtrim(CatCarTypCodDescription) CatCarTypCodDescription
		From dbo.CatCarTypesCodes
) as TypesCodes
End

