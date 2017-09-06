-- =============================================
-- Author:		<Angel Trejo Arizmendi>
-- Creation date: 05-03-2010
-- Description:	Get Mail by User
-- Modify by: */
-- =============================================
CREATE PROCEDURE [dbo].[GetMailByUser] 

@Agent as varchar(2)
AS
BEGIN
	select UserMail,FamilyName
	from dbo.Users
	where Agent=@Agent
END