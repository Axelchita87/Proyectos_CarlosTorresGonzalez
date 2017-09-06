-- =============================================
-- Author:		Luis Felipe Segura Velasco
-- Author:		Luis Felipe Segura Velasco
-- Create date: 15 de Noviembre de 2013
-- Create date: 15 de Noviembre de 2013
-- Description:	PA que regresa los valores de un PNR ingresado
-- Author:		José Ricardo Brito Ortega
-- Create date: 11 de Diciembre de 2013
-- Description:	Se extendio la longitud del campo @fcPNR
-- =============================================
CREATE PROCEDURE [dbo].[GetCxSHoteles] 	
	@fcPNR varchar(15)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [fdtFechaRegistro]
      ,[fcTransaccionId]
      ,ISNULL([fcReservacion],'0') fcReservacion
	  ,ISNULL([fcFactura],'') fcFactura
	  ,ISNULL([fcSerie],'') fcSerie
	  ,ISNULL([fcFacturaCargo],'') fcFacturaCargo
	  ,ISNULL([fcSerieCargo],'') fcSerieCargo      
      ,[fiOrgId]
      ,[Id]
      ,[fcAutorization]
      ,[fcOperation]
	  ,[fcNumeroTarjeta]
	  ,[fcFormaDePago]
	  ,[fdMonto]
  FROM [MyCTSDb].[dbo].[tblCXSHoteles]
  WHERE fcPNR = @fcPNR
END
-- =============================================
-- EXEC GetCxSHoteles 
-- =============================================

