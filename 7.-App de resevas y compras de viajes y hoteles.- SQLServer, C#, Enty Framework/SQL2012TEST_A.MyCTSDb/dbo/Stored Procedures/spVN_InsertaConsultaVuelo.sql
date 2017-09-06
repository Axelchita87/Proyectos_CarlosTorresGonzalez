-- =============================================
-- Author:		Luis Felipe Segura Velasco
-- Create date: 27 de marzo de 2012
-- Description:	PA que inserta en la tabla los destinos de respuesta del servicio de viajanet
-- =============================================
CREATE PROCEDURE spVN_InsertaConsultaVuelo
@IdRegistro varchar(50)
,@AeropuertoDestino varchar(50)
,@AeropuertoOrigen varchar(50)
,@Categoria varchar(50)
,@Destino varchar(50)
,@Origen varchar(50)
,@Prioridad varchar(50)
,@Precio varchar(50)
,@Aerolinea varchar(50)
,@Url varchar(50)
,@FechaViaje varchar(50)
,@NombreDestino varchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [dbo].[tblViajanetTempDestinos]
			   ([IdRegistro]
			   ,[AeropuertoDestino]
			   ,[AeropuertoOrigen]
			   ,[Categoria]
			   ,[Destino]
			   ,[Origen]
			   ,[Prioridad]
			   ,[Precio]
			   ,[Aerolinea]
			   ,[Url]
			   ,[FechaViaje]
			   ,[NombreDestino])
		 VALUES
			   (@IdRegistro
				,@AeropuertoDestino
				,@AeropuertoOrigen
				,@Categoria
				,@Destino
				,@Origen
				,@Prioridad
				,@Precio
				,@Aerolinea
				,@Url
				,@FechaViaje
				,@NombreDestino)
END
