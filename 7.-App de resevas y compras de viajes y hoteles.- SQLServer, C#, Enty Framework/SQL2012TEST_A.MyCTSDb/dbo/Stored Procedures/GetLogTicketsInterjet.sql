-- =============================================
-- Author:		Jessica Gutierrez Becerril
-- Create date: 06/01/14
-- Description:	Extraer los tickets de Intejet
-- =============================================
CREATE PROCEDURE [dbo].[GetLogTicketsInterjet]
@TicketNumber as varchar(50)	
AS
BEGIN
	Select [TicketNumber]
	from [dbo].[Log_Tickets_Interjet]
	where [TicketNumber]=@TicketNumber
END