






-- =============================================
-- Author:		<Marcos Q. Ramirez Luna>
-- Create date: <10/Febrero/2010>
-- Description:	<Obtiene informacion de la estrella de primer nivel por Location>
-- =============================================
CREATE PROCEDURE [dbo].[Get1stStarInfoByLocation] 
	-- Add the parameters for the stored procedure here
	@Location varchar(50)

	
AS
BEGIN
    -- Select statements for procedure here
	SELECT Location, Attribute1, CustomerName, Address, Address1, Address2, Address3, Address4, City, PostalCode, Municipality, State, RFC, MainPhone
    FROM  dbo.OracleProfiles
	WHERE Location = @Location 

END














