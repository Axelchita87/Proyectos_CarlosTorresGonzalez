
CREATE PROCEDURE [dbo].[spUsersInRolesSelectByUserId] (
	@UserId uniqueidentifier
)
AS

SET NOCOUNT ON

SELECT
	[UserId],
	[RoleId]
FROM
	[UsersInRoles]
WHERE
	[UserId] = @UserId
