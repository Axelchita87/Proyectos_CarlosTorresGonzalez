
CREATE PROCEDURE [dbo].[IsUserInRole]
    @userID         uniqueidentifier,
    @roleName         nvarchar(256)
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = ApplicationId FROM Applications WHERE LoweredApplicationName = 'mycts'

    DECLARE @RoleId uniqueidentifier
    SELECT  @RoleId = NULL

    SELECT  @RoleId = RoleId
    FROM    Roles
    WHERE   LoweredRoleName = LOWER(@roleName) AND ApplicationId = @ApplicationId

   SELECT * FROM dbo.UsersInRoles WHERE  UserId = @UserId AND RoleId = @RoleId

END