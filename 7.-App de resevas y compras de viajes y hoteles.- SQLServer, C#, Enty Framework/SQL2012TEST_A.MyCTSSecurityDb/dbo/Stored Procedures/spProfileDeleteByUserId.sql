
CREATE PROCEDURE [dbo].[spProfileDeleteByUserId] (
	@UserId uniqueidentifier
)
AS

SET NOCOUNT ON

DELETE FROM
	[Profile]
WHERE
	[UserId] = @UserId
