-- =============================================
-- Author:		Jessica Gutierrez Becerril
-- Create date: 07/01/14
-- Description:	Actualizar los tickets de Interjet
-- =============================================
CREATE PROCEDURE [dbo].[UpdateLogTicketsInterjet]
@PNR_Airline as varchar(10),
@PNR_Sabre as varchar(10)
AS
BEGIN
	update [dbo].[Log_Tickets_Interjet]
	set PNR_Sabre=@PNR_Sabre
	where PNR_Airline = @PNR_Airline
END