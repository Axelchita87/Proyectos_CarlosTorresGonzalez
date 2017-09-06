
CREATE PROCEDURE [dbo].[spUsersSelectAll] AS

SET NOCOUNT ON

SELECT
	[ApplicationId],
	[UserId],
	[UserName],
	[LoweredUserName],
	[UserMail],
	[LastActivityDate],
	[Firm],
	[Password],
	[FamilyName],
	[Agent],
	[Queue],
	[PCC],
	[TA]
FROM
	[Users]
