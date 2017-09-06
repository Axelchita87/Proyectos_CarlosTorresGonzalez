CREATE PROCEDURE SB_ReceiveData_UniversalProfilesDB
AS
BEGIN
SET NOCOUNT ON
DECLARE @RecvReqDlgHandle UNIQUEIDENTIFIER;
DECLARE @RecvReqMsg XML;
DECLARE @RecvReqMsgName sysname;


-- Creatig a loop to get the message one by one from queue
WHILE (1=1)

BEGIN

BEGIN TRANSACTION;
WAITFOR
( RECEIVE TOP(1)
@RecvReqDlgHandle = conversation_handle,
@RecvReqMsg =message_body,
@RecvReqMsgName = message_type_name
FROM ColaDestino
), TIMEOUT 1000;

IF (@@ROWCOUNT = 0)
BEGIN
ROLLBACK TRANSACTION;
BREAK;
END
else

-- Inserting records in history table
IF @RecvReqMsg IS NOT NULL
print 'xml:'+(cast(@RecvReqMsg as varchar(MAX)))
BEGIN
--insert into UniversalProfilesDB.dbo.tblChangedStars
--select
--	RecvReqMsg.value('@Id', 'int'),
	--RecvReqMsg.value('@FieldKey', 'smallint'),
	--RecvReqMsg.value('@Value', 'varchar(30)'),
	--s1.Value,--correo
	--getdate(),--fecha
	--0,--intento
--	0	--status
--	from @RecvReqMsg.nodes('/row') t(RecvReqMsg)
--	INNER JOIN Stars s1 on s1.Id=RecvReqMsg.value('@Id', 'int') and s1.FieldKey=37	
INSERT INTO [UniversalProfilesDB].[dbo].[tblChangedStars]
           ([fiIdPerfil]
           ,[fcFieldKey]
           ,[fcValue]
           ,[fcCorreo]
           ,[fdFechaActualizacion]
           ,[fiIntento]
           ,[fiStatus])
     VALUES
           (1
           ,'email'
           ,'prueba@prueba'
           ,'eamartinez@ctsmex.com.mx'
           ,getdate()
           ,0
           ,0)	
END
COMMIT TRANSACTION;
END
END
