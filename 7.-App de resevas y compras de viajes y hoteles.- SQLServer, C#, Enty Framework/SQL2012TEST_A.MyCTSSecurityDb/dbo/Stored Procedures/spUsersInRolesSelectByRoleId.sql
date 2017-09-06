
CREATE PROCEDURE [dbo].[spUsersInRolesSelectByRoleId] (
	@RoleId uniqueidentifier
)
AS

SET NOCOUNT ON

SELECT
	[UserId],
	[RoleId]
FROM
	[UsersInRoles]
WHERE
	[RoleId] = @RoleId
