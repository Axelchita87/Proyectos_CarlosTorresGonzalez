
CREATE PROCEDURE [dbo].[Location_Attribute1_Prueba1]
@Location VARCHAR(50)
AS
BEGIN
SELECT Location, Attribute1, [Status],Status_Site from dbo.Location_Attribute_Prueba
WHERE Location=@Location
END

-- =======================================
-- execute Location_Attribute1_Prueba1
-- =======================================
