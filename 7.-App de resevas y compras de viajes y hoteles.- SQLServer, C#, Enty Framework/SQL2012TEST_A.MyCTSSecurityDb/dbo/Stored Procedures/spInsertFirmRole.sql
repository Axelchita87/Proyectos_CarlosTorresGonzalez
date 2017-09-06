
CREATE PROCEDURE [dbo].[spInsertFirmRole] 
@Firm as varchar(50),	
@Pcc as varchar(50),
@RoleName as varchar(50)
	
AS

BEGIN

DECLARE @UserId as uniqueidentifier, @RoleId as uniqueidentifier	
SELECT @UserId=U.UserId

	FROM
		dbo.Roles R

	INNER JOIN
	(dbo.UsersInRoles UR INNER JOIN dbo.Users U ON U.UserID=UR.UserId)

	ON R.RoleId=UR.RoleId
	WHERE
		Firm = @Firm and PCC = @Pcc


SELECT  @RoleId=R.RoleId 

	FROM
		dbo.Roles R

	WHERE
		 RoleName=@RoleName

	INSERT INTO dbo.UsersInRoles (UserId,RoleId)
	VALUES (@UserId,@RoleId)
END
