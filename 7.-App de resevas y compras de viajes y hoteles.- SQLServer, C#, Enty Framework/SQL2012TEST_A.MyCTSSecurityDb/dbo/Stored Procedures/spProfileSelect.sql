
CREATE PROCEDURE [dbo].[spProfileSelect] (
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
