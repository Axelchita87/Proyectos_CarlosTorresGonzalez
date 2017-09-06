
-- =============================================
-- Author:		Marcos Q. Ramírez Luna
-- Create date: Ene-2010
-- =============================================
CREATE Procedure [dbo].[GetCatalog_FareTypesCodes]
 AS 
Begin
select Code [Value], 
(Code + ' ' + Description) [Text],
 Description [Text2], '' [Text3],'' [Text5],'' [Text6],'' [Text7],'' [Text8]
from 
(
Select Distinct rtrim(Code) Code, rtrim(Description) Description
		From dbo.FareTypes
) as FareTypesCodes
End




