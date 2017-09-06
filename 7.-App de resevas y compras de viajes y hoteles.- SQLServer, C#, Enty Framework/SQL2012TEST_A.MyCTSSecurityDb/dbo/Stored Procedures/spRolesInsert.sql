
CREATE PROCEDURE [dbo].[spRolesInsert] (
	@ApplicationId uniqueidentifier,
	@RoleId uniqueidentifier,
	@RoleName nvarchar(256),
	@LoweredRoleName nvarchar(256),
	@Description nvarchar(256)
)
AS

SET NOCOUNT ON

INSERT INTO [Roles] (
	[ApplicationId],
	[RoleId],
	[RoleName],
	[LoweredRoleName],
	[Description]
) VALUES (
	@ApplicationId,
	@RoleId,
	@RoleName,
	@LoweredRoleName,
	@Description
)
