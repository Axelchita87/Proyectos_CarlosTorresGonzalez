
CREATE PROCEDURE [dbo].[spRolesDeleteByApplicationId] (
	@ApplicationId uniqueidentifier
)
AS

SET NOCOUNT ON

DELETE FROM
	[Roles]
WHERE
	[ApplicationId] = @ApplicationId
