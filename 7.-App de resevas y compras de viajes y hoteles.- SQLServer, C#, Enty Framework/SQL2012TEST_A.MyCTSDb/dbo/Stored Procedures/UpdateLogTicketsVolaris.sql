-- =============================================
-- Author:		Jessica Gutierrez Becerril
-- Create date: 07/01/14
-- Description:	Actualizar los tickets de Volaris
-- =============================================
CREATE PROCEDURE [dbo].[UpdateLogTicketsVolaris]
@PNR_Airline as varchar(10),
@PNR_Sabre as varchar(10)
AS
BEGIN
	update [dbo].[Log_Tickets_Volaris]
	set PNR_Sabre=@PNR_Sabre
	where PNR_Airline = @PNR_Airline
END