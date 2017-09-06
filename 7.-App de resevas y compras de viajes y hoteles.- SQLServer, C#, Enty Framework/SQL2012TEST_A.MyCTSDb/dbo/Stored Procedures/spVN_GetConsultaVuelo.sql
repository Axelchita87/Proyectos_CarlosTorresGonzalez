
-- =============================================
-- Author:		Luis Felipe Segura Velasco
-- Create date: 28 de marzo de 2012
-- Description:	PA que obtine la tabla del servicio de viajanet
-- =============================================
CREATE PROCEDURE spVN_GetConsultaVuelo
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [AeropuertoDestino]
		  ,[AeropuertoOrigen]
		  ,[Categoria]
		  ,[Destino]
		  ,[Origen]
		  ,[Precio]
		  ,[Aerolinea]
		  ,[Url]
		  ,[FechaViaje]
		  ,[NombreDestino]
  FROM [dbo].[tblViajanetTempDestinos]
	ORDER BY IdRegistro,FechaViaje
END