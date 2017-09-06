
CREATE PROCEDURE [dbo].[spUsersSelect] (
	@UserId uniqueidentifier
)
AS

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
WHERE
	[UserId] = @UserId
