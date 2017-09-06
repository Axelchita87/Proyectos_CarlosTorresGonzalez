-- =============================================
-- Autor:         Luis Felipe Segura Velasco
-- Fecha creacion: 18 de Abril de 2012
-- Modifico:            Luis Felipe Segura Velasco
-- Fecha modificacion: 18 de Abril de 2012
-- Descripcion:   PA que marca como completada la accion de actualizar a la nueva version de MyCTS
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateCompleteStatusUpgrade]
@UserId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE dbo.Users
	SET UpgradeStatus = 2 
	WHERE UserId = @UserId

	begin try
		UPDATE [200.52.81.200\SQL2005DEV].[MyCTSSecurityDb].dbo.Users
		SET UpgradeStatus = 2 
		WHERE UserId = @UserId
	end try
	begin catch
	end catch
END
-- =============================================
-- EXEC spUpdateCompleteStatusUpgrade '1E212723-412E-4DF9-8D22-F3D731CF6C3B'
-- =============================================