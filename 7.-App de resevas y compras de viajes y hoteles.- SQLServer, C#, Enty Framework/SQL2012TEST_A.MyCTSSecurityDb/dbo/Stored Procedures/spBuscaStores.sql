-- =============================================
-- Autor:         Luis Felipe Segura Velasco
-- Fecha creacion: 25 de Enero
-- Modifico:            Luis Felipe Segura Velasco
-- Fecha modificacion: 25 de Enero
-- Descripcion:   PA para busqueda de Procedimientos almacenados
-- =============================================
CREATE PROCEDURE [dbo].[spBuscaStores]
      @fcNombrePA VARCHAR(200) = ''
AS
BEGIN
      SET NOCOUNT ON;

      SELECT ROUTINE_TYPE AS Tipo,
            ROUTINE_NAME AS Nombre_Store_Procedure
      FROM INFORMATION_SCHEMA.ROUTINES
      WHERE ROUTINE_DEFINITION LIKE '%' + @fcNombrePA + '%'
END
-- =============================================