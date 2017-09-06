
-- =============================================
-- Autor:         Eduardo Vázquez Orozco
-- Fecha creacion: 14/02/2013
-- Modifico:      
-- Fecha modificacion: 
-- Descripcion:   PA para selección  de datos de 
--					la tabla dbo.TC_CTSOracle en MyCTSDb
-- =============================================
CREATE PROCEDURE [dbo].[GETCTS_CLIENTES_MyCTS] 
@creditCardNumber VARCHAR(20) 
as
BEGIN    
		SELECT FLEX_VALUE AS creditCardNumber  FROM TC_CTSOracle WHERE FLEX_VALUE= @creditCardNumber
END	
-- =============================================
-- execute GETCTS_CLIENTES_MyCTS '376698723191000'
-- =============================================
