
CREATE PROCEDURE [dbo].[spGetConsultingFirmRole] 
	@Firm as varchar(50),
	@Pcc as varchar(50)

AS

BEGIN
	SELECT
		U.UserName, R.RoleName, R.Description
	FROM
		dbo.Roles R

	INNER JOIN
	(dbo.UsersInRoles UR INNER JOIN dbo.Users U ON U.UserID=UR.UserId)

	ON R.RoleId=UR.RoleId
	WHERE
		Firm = @Firm and PCC = @Pcc
END 