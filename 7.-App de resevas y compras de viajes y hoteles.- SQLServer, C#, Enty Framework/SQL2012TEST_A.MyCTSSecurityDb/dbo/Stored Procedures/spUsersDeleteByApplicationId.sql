
CREATE PROCEDURE [dbo].[spUsersDeleteByApplicationId] (
	@ApplicationId uniqueidentifier
)
AS

SET NOCOUNT ON

DELETE FROM
	[Users]
WHERE
	[ApplicationId] = @ApplicationId
