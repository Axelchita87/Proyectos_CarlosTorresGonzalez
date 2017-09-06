
-- =============================================
-- Author:	Ivan Martínez Guerrero
-- Creation date: 17/01/2011, Modified: *
-- Description:	Procedure that set the active users
-- =============================================
CREATE PROCEDURE [dbo].[GetActiveUsers] 
	
AS
BEGIN
	SELECT DISTINCT
	FamilyName,UserMail,Agent 
	FROM dbo.Users
	WHERE ProductivityMail='True'
END


