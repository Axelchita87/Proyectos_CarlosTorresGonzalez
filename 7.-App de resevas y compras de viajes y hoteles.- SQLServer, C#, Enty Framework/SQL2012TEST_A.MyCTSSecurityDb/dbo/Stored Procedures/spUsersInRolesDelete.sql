
CREATE PROCEDURE [dbo].[spUsersInRolesDelete] (
	@UserId uniqueidentifier,
	@RoleId uniqueidentifier
)
AS

SET NOCOUNT ON

DELETE FROM
	[UsersInRoles]
WHERE
	[UserId] = @UserId
	AND [RoleId] = @RoleId
