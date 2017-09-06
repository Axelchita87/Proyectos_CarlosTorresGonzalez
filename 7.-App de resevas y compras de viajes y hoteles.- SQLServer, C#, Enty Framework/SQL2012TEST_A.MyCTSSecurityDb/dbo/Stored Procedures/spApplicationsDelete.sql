
CREATE PROCEDURE [dbo].[spApplicationsDelete] (
	@ApplicationId uniqueidentifier
)
AS

SET NOCOUNT ON

DELETE FROM
	[Applications]
WHERE
	[ApplicationId] = @ApplicationId
