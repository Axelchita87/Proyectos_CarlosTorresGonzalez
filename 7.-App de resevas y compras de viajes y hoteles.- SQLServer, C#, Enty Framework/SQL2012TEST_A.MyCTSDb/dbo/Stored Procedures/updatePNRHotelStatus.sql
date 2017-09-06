



-- =============================================
-- Author:		Marcos Q. Ramirez
-- Create date: 07-nov-2011
-- Description:	 update status of pnr lines
-- Author:		José Ricardo Brito Ortega
-- Create date: 01-dec-2011
-- Description:	 add lenght @PNR
-- =============================================
CREATE PROCEDURE [dbo].[updatePNRHotelStatus]
@PNR varchar(15),
@status int,
@cliente_pago_prov bit
AS
BEGIN
update [dbo].[DetailsPNRHotel]
set status = @status
where record = @PNR           
and provid_direc_pay = @cliente_pago_prov 
END




