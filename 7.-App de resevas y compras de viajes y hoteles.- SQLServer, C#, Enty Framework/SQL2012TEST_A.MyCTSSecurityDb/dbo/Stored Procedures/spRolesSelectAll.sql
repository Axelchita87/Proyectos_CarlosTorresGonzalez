
CREATE PROCEDURE [dbo].[spRolesSelectAll] AS

SET NOCOUNT ON

SELECT
	[ApplicationId],
	[RoleId],
	[RoleName],
	[LoweredRoleName],
	[Description]
FROM
	[Roles]
