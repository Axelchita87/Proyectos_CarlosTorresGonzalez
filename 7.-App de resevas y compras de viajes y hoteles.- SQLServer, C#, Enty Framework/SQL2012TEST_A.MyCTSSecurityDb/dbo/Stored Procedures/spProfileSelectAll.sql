
CREATE PROCEDURE [dbo].[spProfileSelectAll] AS

SET NOCOUNT ON

SELECT
	[UserId],
	[PropertyNames],
	[PropertyValuesString],
	[PropertyValuesBinary],
	[LastUpdatedDate]
FROM
	[Profile]
