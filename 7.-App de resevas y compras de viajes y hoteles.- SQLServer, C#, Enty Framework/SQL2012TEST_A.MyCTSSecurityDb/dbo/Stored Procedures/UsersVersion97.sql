
-- =============================================
-- Author:		<Angel Trejo Arizmendi>
-- Creation date: 07-05-2010
-- Description:	Update Users by Firm and PCC
-- Modify by: */
-- =============================================
CREATE PROCEDURE [dbo].[UsersVersion97] 

AS
BEGIN
	select FamilyName,UserMail
	from dbo.Users
	where MyCTSVersion='1.0.0.97'
END