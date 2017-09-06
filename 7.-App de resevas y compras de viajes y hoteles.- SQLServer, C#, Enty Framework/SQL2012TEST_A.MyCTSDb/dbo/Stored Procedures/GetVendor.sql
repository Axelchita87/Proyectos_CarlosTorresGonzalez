-- =============================================
-- Author:		<Jessica Gutierrez Becerril>
-- Modify:		Luis Felipe Segura Velasco
-- Creation date: 19-10-2010
-- Modify date: 16 de mayo de 2012
-- Description:	Search VendorCode by Oracle
-- =============================================
CREATE PROCEDURE [dbo].[GetVendor] 
@IATANumber varchar(5)
AS
BEGIN 
	SET NOCOUNT ON;
	EXEC ('SELECT VENDOR_SITE_CODE FROM OPENQUERY(CORPP, ''SELECT VENDOR_SITE_CODE FROM APPS.CTS_PROVEEDORES_V WHERE VENDOR_NAME like ''''INTERNATIONAL AIR%'''''') WHERE SUBSTRING(VENDOR_SITE_CODE,1,5)=''' + @IATANumber + '''')
END
-- =============================================
-- exec GetVendor '50077'
-- =============================================
