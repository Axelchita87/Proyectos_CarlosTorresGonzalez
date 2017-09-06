-- =============================================
-- Author:		<Angel Trejo Arizmendi>
-- Creation date: 23-12-09
-- Description:	Get Tickets By PNR
-- =============================================
CREATE PROCEDURE [dbo].[GetTicketsByPNR] 
	@PNR varchar(6)
AS
BEGIN
	select distinct(Ticket)
	from dbo.DetailsTktsLinks
	where PNR=@PNR
END
