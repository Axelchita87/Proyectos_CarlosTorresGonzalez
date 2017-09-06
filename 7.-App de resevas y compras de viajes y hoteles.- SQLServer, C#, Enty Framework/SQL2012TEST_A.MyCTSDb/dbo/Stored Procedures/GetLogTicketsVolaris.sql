-- =============================================
-- Author:		Jessica Gutierrez Becerril
-- Create date: 06/01/14
-- Description:	Extraer los tickets de Volaris
-- =============================================
CREATE PROCEDURE [dbo].[GetLogTicketsVolaris]
@TicketNumber as varchar(50)
AS
BEGIN
	Select [TicketNumber]
	from [dbo].[Log_Tickets_Volaris]
	where [TicketNumber]=@TicketNumber
END