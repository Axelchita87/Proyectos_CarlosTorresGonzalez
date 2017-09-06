


create PROCEDURE [dbo].[spRolesSelectByUsuario] (
	@Firma nvarchar(50), 
	@PCC nvarchar(50)
)
AS

SET NOCOUNT ON

SELECT
	A.[ApplicationId],
	A.[RoleId],
	[RoleName],
	[LoweredRoleName],
	[Description]
FROM
	[Roles] A, UsersInRoles B, Users C
WHERE A.RoleId = B.RoleId 
AND B.UserId = C.UserId 
AND [Firm] = @Firma
AND [PCC] = @PCC



