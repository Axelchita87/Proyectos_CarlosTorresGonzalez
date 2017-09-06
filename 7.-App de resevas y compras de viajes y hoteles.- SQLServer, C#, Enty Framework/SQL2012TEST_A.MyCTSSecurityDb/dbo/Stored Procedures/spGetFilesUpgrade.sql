-- =============================================
-- Autor:         Luis Felipe Segura Velasco
-- Fecha creacion: 18 de Abril de 2012
-- Modifico:            Luis Felipe Segura Velasco
-- Fecha modificacion: 18 de Abril de 2012
-- Descripcion:   PA que regresa la lista de archivos a descargar para el upgrade
-- =============================================
CREATE PROCEDURE [dbo].[spGetFilesUpgrade]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT NombreDoc, Extension 
	FROM dbo.DocsBinarios 
	WHERE NombreDoc LIKE 'SabreRed.z%'
END
-- =============================================
-- EXEC spGetFilesUpgrade
-- =============================================

