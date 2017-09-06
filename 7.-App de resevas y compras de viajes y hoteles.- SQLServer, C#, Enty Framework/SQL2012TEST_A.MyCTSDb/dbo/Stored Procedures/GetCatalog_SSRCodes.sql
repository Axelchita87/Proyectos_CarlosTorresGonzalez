-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: Ene-2010
-- =============================================
CREATE Procedure [dbo].[GetCatalog_SSRCodes]
 AS 
Begin
select Code [Value], 
(Code + ' ' + Descripcion) [Text],
 Descripcion [Text2], '' [Text3],'' [Text5],'' [Text6],'' [Text7],'' [Text8]
from 
(
Select Distinct rtrim(Code) Code, rtrim(Descripcion) Descripcion
		From dbo.SSR
) as OSICodes
End



