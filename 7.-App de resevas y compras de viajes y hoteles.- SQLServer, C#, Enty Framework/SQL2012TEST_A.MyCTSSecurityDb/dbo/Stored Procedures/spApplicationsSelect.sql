
CREATE PROCEDURE [dbo].[spApplicationsSelect] (
	@ApplicationId uniqueidentifier
)
AS

SET NOCOUNT ON

SELECT
	[ApplicationName],
	[LoweredApplicationName],
	[ApplicationId],
	[Description]
FROM
	[Applications]
WHERE
	[ApplicationId] = @ApplicationId
