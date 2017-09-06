-- =============================================
-- Author:		<Ivan Martínez Guerrero>
-- Creation date: 19-12-2010
-- Description:	Gets Id from SalesOrigin
-- Modify by: */
-- =============================================
CREATE PROCEDURE [dbo].[GetIdSalesOrigin] 

@description varchar(max)

AS
BEGIN
	Select IDSales from dbo.OriginSales
	where [Description]=@description	
END
