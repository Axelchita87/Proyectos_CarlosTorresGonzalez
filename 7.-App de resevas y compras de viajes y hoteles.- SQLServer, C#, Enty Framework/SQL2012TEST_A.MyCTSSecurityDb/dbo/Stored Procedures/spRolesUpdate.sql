
CREATE PROCEDURE [dbo].[spRolesUpdate] (
	@ApplicationId uniqueidentifier,
	@RoleId uniqueidentifier,
	@RoleName nvarchar(256),
	@LoweredRoleName nvarchar(256),
	@Description nvarchar(256)
)
AS

SET NOCOUNT ON

UPDATE
	[Roles]
SET
	[ApplicationId] = @ApplicationId,
	[RoleName] = @RoleName,
	[LoweredRoleName] = @LoweredRoleName,
	[Description] = @Description
WHERE
	[RoleId] = @RoleId
