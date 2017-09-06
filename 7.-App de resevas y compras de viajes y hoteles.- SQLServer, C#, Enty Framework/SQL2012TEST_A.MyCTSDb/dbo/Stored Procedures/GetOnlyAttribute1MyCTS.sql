-- ================================
-- CREADO: EDUARDO VAZQUEZ OROZCO	
-- FECHA: 30/04/2013
-- ================================

CREATE PROCEDURE GetOnlyAttribute1MyCTS
@Location VARCHAR(50)
AS
BEGIN
	SELECT LOCATION FROM Location_Attribute WHERE Location = @Location
END

--========================================
-- EXECUTE GetOnlyAttribute1MyCTS 'AAA800'
--========================================
