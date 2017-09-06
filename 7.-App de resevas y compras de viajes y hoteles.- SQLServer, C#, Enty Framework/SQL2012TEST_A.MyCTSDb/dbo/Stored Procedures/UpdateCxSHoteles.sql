-- =============================================
-- Author:		Luis Felipe Segura Velasco
-- Author:		Luis Felipe Segura Velasco
-- Create date: 25 de Noviembre de 2013
-- Create date: 25 de Noviembre de 2013
-- Description:	PA que actualiza los campos provenientes desde el robot de facturacion
-- =============================================
CREATE PROCEDURE dbo.UpdateCxSHoteles 
	@fcPNR varchar(10),
	@fcReservacion varchar(20),
	@fcFactura varchar(20),
	@fcSerie varchar(20),
	@fcFacturaCargo varchar(20),
	@fcSerieCargo varchar(20),
	@fiOrgId int
AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE [dbo].[tblCXSHoteles]
	   SET [fcReservacion] = @fcReservacion
		  ,[fcFactura] = @fcFactura
		  ,[fcSerie] = @fcSerie
		  ,[fcFacturaCargo] = @fcFacturaCargo
		  ,[fcSerieCargo] = @fcSerieCargo
	  WHERE fcPNR = @fcPNR
	  AND fiOrgId = @fiOrgId
END
-- =============================================
-- EXEC UpdateCxSHoteles 
-- =============================================
