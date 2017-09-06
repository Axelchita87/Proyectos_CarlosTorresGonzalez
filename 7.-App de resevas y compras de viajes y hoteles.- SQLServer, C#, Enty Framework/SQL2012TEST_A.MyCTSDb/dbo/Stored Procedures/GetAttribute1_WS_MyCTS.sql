-- =============================================
-- Author:		Eduardo Vazquez Orozco
-- Create date: 13 de Febrero de 2013
-- Description: Store procedure que obtiene Attribute
-- =============================================
CREATE PROCEDURE [dbo].[GetAttribute1_WS_MyCTS]
	 @Location VARCHAR(6),
	 @Status VARCHAR(2),
	 @Status_Site VARCHAR(2)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE 
		@ATTRIBUTE1 VARCHAR(50)
IF EXISTS
(
	SELECT Location,Attribute1,[Status],Status_Site 
	FROM Location_Attribute 
	WHERE Location = @Location AND 
	STATUS = 'A' and Status_Site='I' OR Location = @Location AND STATUS = 'I' AND Status_Site = 'A'  
	or Location = @Location AND STATUS ='I' and Status_Site='I'
)
		BEGIN
			SELECT 'INACTIVO'AS Location, 'INACTIVO' AS Attribute1, 'INACTIVO' AS [Status], 'INACTIVO' AS Status_Site 
		END
ELSE
	BEGIN
		IF EXISTS
		(
			SELECT Location,Attribute1,[Status],Status_Site 
			FROM Location_Attribute 
			WHERE Location = @Location AND 
			STATUS <>'I' AND Status_Site='A' or Location = @Location AND STATUS = 'A' and Status_Site<>'I' 
			or Location = @Location AND STATUS <>'I' and Status_Site<>'I'
		)
			BEGIN
				SELECT Location,Attribute1,[Status],Status_Site 
				FROM Location_Attribute 
				WHERE Location = @Location AND 
				STATUS <>'I' AND Status_Site='A' or Location = @Location AND STATUS = 'A' and Status_Site<>'I' 
				or Location = @Location AND STATUS <>'I' and Status_Site<>'I'
			END
ELSE
			BEGIN
				IF NOT EXISTS
				(
					SELECT Location FROM Location_Attribute WHERE Location = @Location
				)
			BEGIN
					SELECT 'NO EXISTE LOCATION'AS Location, 'NO EXISTE LOCATION' AS Attribute1, 'NO EXISTE LOCATION' AS [Status], 'NO EXISTE LOCATION' AS Status_Site 
			END
		END
	END
END
-- =====================================================
-- exec GetAttribute1_WS N'BIB100',85 Existe Location
-- =====================================================
-- =====================================================
-- exec GetAttribute1_WS N'CCC500',85 No existe location
-- =====================================================
-- =====================================================
-- exec GetAttribute1_WS N'AMB100',85 Location inactivo
-- =====================================================