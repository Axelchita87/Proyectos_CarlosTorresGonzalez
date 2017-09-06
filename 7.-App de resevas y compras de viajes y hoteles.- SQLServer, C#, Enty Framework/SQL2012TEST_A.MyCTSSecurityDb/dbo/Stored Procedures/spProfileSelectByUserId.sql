
CREATE PROCEDURE [dbo].[spProfileSelectByUserId] (
	@UserId uniqueidentifier
)
AS

SET NOCOUNT ON

SELECT
	[UserId],
	[PropertyNames],
	[PropertyValuesString],
	[PropertyValuesBinary],
	[LastUpdatedDate]
FROM
	[Profile]
WHERE
	[UserId] = @UserId
