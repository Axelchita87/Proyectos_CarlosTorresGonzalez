
CREATE PROCEDURE [dbo].[spUsersInRolesDeleteByRoleId] (
	@RoleId uniqueidentifier
)
AS

SET NOCOUNT ON

DELETE FROM
	[UsersInRoles]
WHERE
	[RoleId] = @RoleId
