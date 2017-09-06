


-- =============================================
-- Author:		<Marcos Q. Ramirez Luna>
-- Creation date: 18-06-2012
-- Description:	Get form payment CTS Catalog
-- Modify by: */
-- =============================================
CREATE PROCEDURE [dbo].[GetCatFormPaymentCTS] 

AS
BEGIN
	select FormTypeCode, FormTypeDescription, FormTypeSabreCode
    from CatFormPaymentCTS
END







