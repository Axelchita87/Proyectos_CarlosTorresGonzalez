



create PROCEDURE [dbo].[spRolesSelectByUsuarioID] (
	@UsuarioId uniqueidentifier
)
AS

SET NOCOUNT ON

SELECT
	[ApplicationId],
	A.[RoleId],
	[RoleName],
	[LoweredRoleName],
	[Description]
FROM
	[Roles] A, UsersInRoles B
WHERE A.RoleId = B.RoleId 
AND [UserId] = @UsuarioId


