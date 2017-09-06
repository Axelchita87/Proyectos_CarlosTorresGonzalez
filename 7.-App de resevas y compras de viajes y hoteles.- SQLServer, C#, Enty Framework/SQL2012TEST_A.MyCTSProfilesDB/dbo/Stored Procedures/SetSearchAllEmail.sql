-- ===================================================
-- Author:		<Eduardo Vázquez Orozco>
-- Modify:	Luis Felipe Segura Velasco
-- Create date: <12/Agosto/2012>
-- Modify date: 23 de Agosto de 2012
-- Description:	<Obtiene Email de la tabla tblCorreos>
-- ===================================================
CREATE PROCEDURE [dbo].[SetSearchAllEmail]
	@Email as varchar(100)
AS
BEGIN
	SELECT Email
	FROM Star2 
	WHERE Email LIKE '%'+@Email+'%'
END
-- ===================================================
-- exec SetSearchAllEmail 'JOSED.HERNANDEZ@SOFTTEK.COM'
-- ===================================================

