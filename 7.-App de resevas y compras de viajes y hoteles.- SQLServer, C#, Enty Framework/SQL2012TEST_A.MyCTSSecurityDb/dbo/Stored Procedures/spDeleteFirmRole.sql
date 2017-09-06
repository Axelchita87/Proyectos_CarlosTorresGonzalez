
CREATE PROCEDURE [dbo].[spDeleteFirmRole] 
	@UserName as varchar(50),
	@RoleName as varchar(50)
	

AS

BEGIN
DECLARE @UserID as uniqueidentifier, @RoleID as uniqueidentifier

SELECT @UserId=U.UserId
 
	FROM
		dbo.Roles R

	INNER JOIN
	(dbo.UsersInRoles UR INNER JOIN dbo.Users U ON U.UserID=UR.UserId)
	ON R.RoleId=UR.RoleId
	
	WHERE
	U.UserName = @UserName

	
SELECT @RoleId=R.RoleId 
	
	FROM
	dbo.Roles R
	
	WHERE
	R.RoleName = @RoleName



DELETE FROM dbo.UsersInRoles
WHERE UserId=@UserId and RoleId=@RoleId

END 