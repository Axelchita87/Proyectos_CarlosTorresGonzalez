
CREATE PROCEDURE [dbo].[spProfileUpdate] (
	@UserId uniqueidentifier,
	@PropertyNames ntext,
	@PropertyValuesString ntext,
	@PropertyValuesBinary image,
	@LastUpdatedDate datetime
)
AS

SET NOCOUNT ON

UPDATE
	[Profile]
SET
	[PropertyNames] = @PropertyNames,
	[PropertyValuesString] = @PropertyValuesString,
	[PropertyValuesBinary] = @PropertyValuesBinary,
	[LastUpdatedDate] = @LastUpdatedDate
WHERE
	[UserId] = @UserId
