-- =============================================
-- Author:Jessica Gutierrez
-- Create date: 26/02/2015
-- Description:	Se inserta los errores de cargos por servicio
-- =============================================
CREATE PROCEDURE InsertErrorLogServiceCharge 
@StatusTransaccion as nvarchar(50),
@MensajeAmistoso as nvarchar(50),
@NumeroAutorizacion as varchar(50),
@NumeroOperacion as varchar(50)
AS
BEGIN
INSERT INTO [dbo].[Error_log_ServiceCharge]
            ([StatusTransaccion],
			 [MensajeAmistoso],
             [NumeroAutorizacion],
             [NumeroOperacion],
             [Fecha_creacion]
             )
       VALUES
       (@StatusTransaccion,
        @MensajeAmistoso,
        @NumeroAutorizacion,
        @NumeroOperacion,
        GETDATE()
        )
	
END
