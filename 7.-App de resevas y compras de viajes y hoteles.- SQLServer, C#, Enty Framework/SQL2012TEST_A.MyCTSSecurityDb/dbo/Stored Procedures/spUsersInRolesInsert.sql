
CREATE PROCEDURE [dbo].[spUsersInRolesInsert] (
	@UserId uniqueidentifier,
	@RoleId uniqueidentifier
)
AS

SET NOCOUNT ON

INSERT INTO [UsersInRoles] (
	[UserId],
	[RoleId]
) VALUES (
	@UserId,
	@RoleId
)
