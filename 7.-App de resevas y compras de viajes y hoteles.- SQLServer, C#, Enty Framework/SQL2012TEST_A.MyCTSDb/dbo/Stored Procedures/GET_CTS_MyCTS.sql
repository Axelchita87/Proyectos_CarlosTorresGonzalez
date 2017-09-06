
-- =============================================
-- Autor:         Eduardo Vázquez Orozco
-- Fecha creacion: 14/02/2013
-- Modifico:      
-- Fecha modificacion: 
-- Descripcion:   PA para selección  de datos de 
--					la tabla dbo.TC_CTSOracle en MyCTSDb
-- =============================================
CREATE PROCEDURE [dbo].[GET_CTS_MyCTS]
@FLEX_VALUE VARCHAR(20)
as
BEGIN    
		SELECT * FROM TC_CTSOracle WHERE FLEX_VALUE = @FLEX_VALUE
END	
-- =============================================
-- execute GET_CTS_MyCTS 376681951921009
-- =============================================
