-- =============================================

-- Author:		<Marcos Q. Ramirez Luna>
-- Create date: <10/Febrero/2010>
-- Description:	<Obtiene informacion de la estrella de primer nivel por Location>
-- Modifica: <Eduardo Vázquez>
-- =============================================

CREATE PROCEDURE [dbo].[Get1stStarInfoByLocationWS] 
	@Location varchar(50)
AS

BEGIN
	SELECT Location, Attribute1, CustomerName, Address, Address1, Address2, Address3, Address4, City, PostalCode, Municipality, State, RFC, MainPhone
    FROM  dbo.OracleProfiles WHERE Location = @Location 
END
--=============================================
-- execute Get1stStarInfoByLocationWS 'AFA100'
--=============================================
