
CREATE PROCEDURE [dbo].[spUsersDelete] (
	@UserId uniqueidentifier
)
AS

SET NOCOUNT ON

DELETE FROM
	[Users]
WHERE
	[UserId] = @UserId
