
CREATE PROCEDURE [dbo].[spRolesDelete] (
	@RoleId uniqueidentifier
)
AS

SET NOCOUNT ON

DELETE FROM
	[Roles]
WHERE
	[RoleId] = @RoleId
