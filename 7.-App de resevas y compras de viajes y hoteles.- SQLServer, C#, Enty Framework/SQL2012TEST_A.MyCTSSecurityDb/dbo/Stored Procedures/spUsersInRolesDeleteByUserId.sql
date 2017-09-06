
CREATE PROCEDURE [dbo].[spUsersInRolesDeleteByUserId] (
	@UserId uniqueidentifier
)
AS

SET NOCOUNT ON

DELETE FROM
	[UsersInRoles]
WHERE
	[UserId] = @UserId
