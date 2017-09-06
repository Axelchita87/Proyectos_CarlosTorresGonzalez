
CREATE PROCEDURE [dbo].[spRolesSelect] (
	@RoleId uniqueidentifier
)
AS

SET NOCOUNT ON

SELECT
	[ApplicationId],
	[RoleId],
	[RoleName],
	[LoweredRoleName],
	[Description]
FROM
	[Roles]
WHERE
	[RoleId] = @RoleId
