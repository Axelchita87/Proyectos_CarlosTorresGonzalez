


-- =============================================
-- Author:		<Marcos Q. Ramirez Luna>
-- Create date: <18/Febrero/2010>
-- Description:	<Obtiene el catalogo de tipo de linea de perfiles>
-- =============================================
CREATE PROCEDURE [dbo].[GetCatProfileLines] 
	
AS
BEGIN
    SELECT [Type] [Value], 
(   [Type] + ' ' + LineDescription) [Text],
    LineDescription [Text2],'' [Text3]
    FROM dbo.CatProfileLines
   
END
















