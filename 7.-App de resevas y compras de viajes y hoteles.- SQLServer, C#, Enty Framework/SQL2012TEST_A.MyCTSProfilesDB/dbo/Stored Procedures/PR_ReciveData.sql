CREATE PROCEDURE PR_ReciveData
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
BEGIN
insert into UpdatedProfiles(Id_perfil, FieldKey, ChangedValue, Correo, PCC, Level1, Level2,fechaActualizacion, Intento,StatusActualizacion)
select
	RecvReqMsg.value('@Id', 'int'),
	RecvReqMsg.value('@FieldKey', 'smallint'),
	RecvReqMsg.value('@Value', 'varchar(30)'),
	s1.Value,
	s2.Value,
	s3.Value,
	s4.Value,
	getdate(),
	0,
	0	
	from @RecvReqMsg.nodes('/row') t(RecvReqMsg)
	LEFT JOIN Stars s1 on s1.Id=RecvReqMsg.value('@Id', 'int') and s1.FieldKey=37
	LEFT JOIN Stars s2 on s2.Id=RecvReqMsg.value('@Id', 'int') and s2.FieldKey=27
	LEFT JOIN Stars s3 on s3.Id=RecvReqMsg.value('@Id', 'int') and s3.FieldKey=28
	LEFT JOIN Stars s4 on s4.Id=RecvReqMsg.value('@Id', 'int') and s4.FieldKey=29	
	
END
COMMIT TRANSACTION;
END
END
