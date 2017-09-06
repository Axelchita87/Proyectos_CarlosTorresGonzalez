
create procedure enviarSolicitudLista
	 @mensaje NVARCHAR (MAX)
as
set nocount on;
declare @MannejadorConversacion UNIQUEIDENTIFIER
BEGIN TRANSACTION
BEGIN DIALOG CONVERSATION @MannejadorConversacion
	FROM SERVICE [ServicioSource]
	TO SERVICE 'ServicioDestino'
	ON CONTRACT [DBContract]
WITH ENCRYPTION=OFF;
SEND ON CONVERSATION @MannejadorConversacion
	message type[RequestMessage](@Mensaje)
COMMIT TRANSACTION;