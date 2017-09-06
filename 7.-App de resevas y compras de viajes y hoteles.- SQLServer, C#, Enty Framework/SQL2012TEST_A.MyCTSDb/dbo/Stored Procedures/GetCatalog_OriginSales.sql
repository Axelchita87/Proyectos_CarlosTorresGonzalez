

-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: Ago-2009
-- =============================================
CREATE Procedure [dbo].[GetCatalog_OriginSales]
 AS 
Begin
select IDSales [Value], 
(IDSales + ' ' + Description) [Text],
 Description [Text2], '' [Text3]
from 
(
Select Distinct rtrim(IDSales) IDSales, rtrim(Description) Description
		From dbo.OriginSales
) as OriginSales
End

