-- =============================================
-- Author:		<Pedro Tomas Solis>
-- Creation date: 11-12-09
-- Description:	Get the name of the file that will be inserted in the Link
-- =============================================
CREATE PROCEDURE [dbo].[GetInvoiceFileName] 
	@TKT varchar(10)
AS
BEGIN
  DECLARE @InvoiceName nvarchar(20)
  Select @InvoiceName=[NAME]+[TRX_NUMBER] From CTS_INVOICES_V WHERE [ATTRIBUTE4]=@TKT
  SELECT RTRIM(@InvoiceName) InvoiceFileName
END


