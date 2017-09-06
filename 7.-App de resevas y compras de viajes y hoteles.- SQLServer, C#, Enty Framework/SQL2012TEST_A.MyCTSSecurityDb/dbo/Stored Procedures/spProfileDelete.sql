
CREATE PROCEDURE [dbo].[spProfileDelete] (
	@UserId uniqueidentifier
)
AS

SET NOCOUNT ON

DELETE FROM
	[Profile]
WHERE
	[UserId] = @UserId
