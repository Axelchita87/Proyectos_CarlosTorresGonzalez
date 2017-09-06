-- =============================================
-- Author:		<Angel Trejo Arizmendi>
-- Creation date: 18-02-2010
-- Description:	Search Attribute1
-- Modify by: 
-- =============================================
CREATE PROCEDURE [dbo].[GetOnlyAttribute1] 
@Attribute1 as varchar(6),
@OrgId int
AS
BEGIN
	if not exists(	select * 
				from CORPP..APPS.CTS_CLIENTES_V
				WHERE ATTRIBUTE1=@Attribute1)
	begin
		select 'NO EXISTE ATRIBUTO' AS ATTRIBUTE1
	end
	ELSE
	BEGIN
		SELECT @Attribute1 AS ATTRIBUTE1
	END
END
-- =============================================
-- EXEC GetOnlyAttribute1 'CFE100',85
-- =============================================
