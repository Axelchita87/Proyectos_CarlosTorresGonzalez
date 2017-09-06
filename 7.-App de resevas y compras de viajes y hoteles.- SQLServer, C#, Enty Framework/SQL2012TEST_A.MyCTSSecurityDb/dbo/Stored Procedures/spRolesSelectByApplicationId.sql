
CREATE PROCEDURE [dbo].[spRolesSelectByApplicationId] (
	@ApplicationId uniqueidentifier
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
	[ApplicationId] = @ApplicationId
