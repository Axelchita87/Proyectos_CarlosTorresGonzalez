


-- =============================================
-- Author:		Marcos Q. Ramirez
-- Create date: 07-may-2012
-- Description:	 update error Message of pnr lines
-- =============================================
create PROCEDURE [dbo].[SetPNRHotelError]
@PNR varchar(10),
@ErrorMsg varchar(500)
AS
BEGIN
update [dbo].[DetailsPNRHotel]
set GeaErrorMsg = @ErrorMsg
where record = @PNR           
END







