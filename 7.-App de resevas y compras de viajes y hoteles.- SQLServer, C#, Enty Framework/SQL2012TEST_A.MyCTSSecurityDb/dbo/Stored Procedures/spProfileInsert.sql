
CREATE PROCEDURE [dbo].[spProfileInsert] (
	@UserId uniqueidentifier,
	@PropertyNames ntext,
	@PropertyValuesString ntext,
	@PropertyValuesBinary image,
	@LastUpdatedDate datetime
)
AS

SET NOCOUNT ON

INSERT INTO [Profile] (
	[UserId],
	[PropertyNames],
	[PropertyValuesString],
	[PropertyValuesBinary],
	[LastUpdatedDate]
) VALUES (
	@UserId,
	@PropertyNames,
	@PropertyValuesString,
	@PropertyValuesBinary,
	@LastUpdatedDate
)
