-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 13-08-2009
-- Modifico:            Luis Felipe Segura Velasco
-- Fecha modificacion: 1 de Junio de 2012
-- Description:	Procedure that set the version of mycts
-- =============================================
CREATE PROCEDURE [dbo].[SetMyCTSVersion]
	@Firm AS NVARCHAR(50),
	@PCC AS NVARCHAR(50),
	@MyCTSVersion as varchar(10)=null
AS
BEGIN
	IF EXISTS(SELECT * FROM dbo.Users WHERE Firm=@Firm AND PCC=@PCC)
	BEGIN
		--UPDATE dbo.Users 
		--SET MyCTSVersion = @MyCTSVersion
		--WHERE Firm=@Firm AND PCC=@PCC
	print 'se comenta para que pase en desarrollo'

--		BEGIN TRY
--			UPDATE [200.52.81.200\SQL2005DEV].[MyCTSSecurityDb].dbo.Users
--			SET MyCTSVersion = @MyCTSVersion
--			WHERE Firm=@Firm AND PCC=@PCC
--		END TRY
--		BEGIN CATCH
--		END CATCH
	END
END

