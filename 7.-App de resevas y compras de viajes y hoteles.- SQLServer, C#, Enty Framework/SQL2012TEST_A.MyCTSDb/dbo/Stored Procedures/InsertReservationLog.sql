-- =============================================
-- Author:		<Julio Cesar Huerta Mondragón>
-- Create date: <08/Julio/2009>
-- Description:	<Inserta la clave de la reserva hecha por el agente.>
-- =============================================
CREATE PROCEDURE [dbo].[InsertReservationLog] 
	-- Add the parameters for the stored procedure here
	@strAgent nvarchar(10), 
	@strPCC nvarchar(10), 
	@strReservation nvarchar(20),
	@Status int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.ReservationLog (IdAgent, PCC, LogDate, CveReservation, [Status])
	VALUES(@strAgent, @strPCC, getdate(), @strReservation, @Status)

END



