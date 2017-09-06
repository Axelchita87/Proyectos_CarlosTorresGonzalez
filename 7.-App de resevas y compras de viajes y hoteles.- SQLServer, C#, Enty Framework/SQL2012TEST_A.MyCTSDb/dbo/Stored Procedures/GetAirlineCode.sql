-- =============================================
-- Author:		Luis Felipe Segura Velasco
-- Modify:		Luis Felipe Segura Velasco
-- Creation date: 26 de Agosto de 2013
-- Modify date: 26 de Agosto de 2013
-- Description:	Obtiene el numero de aerolinea en base 
-- =============================================
CREATE PROCEDURE [dbo].[GetAirlineCode] 
@CatAirLinFarId varchar(5)
AS
BEGIN 
	SET NOCOUNT ON;
	
	IF (SELECT COUNT(*) FROM CatAirLinesFare WHERE CatAirLinFarId = @CatAirLinFarId) > 0
	BEGIN
		SELECT 
			CatAirLinNumId
		FROM CatAirLines
		JOIN CatAirLinesFare
		ON CatAirLinFarId = CatAirLinAlfaId
		WHERE CatAirLinFarId = @CatAirLinFarId
	END
	ELSE
	BEGIN
		SELECT 'XXX' CatAirLinNumId
	END
END
-- =============================================
-- EXEC GetAirlineCode 'YO'
-- =============================================