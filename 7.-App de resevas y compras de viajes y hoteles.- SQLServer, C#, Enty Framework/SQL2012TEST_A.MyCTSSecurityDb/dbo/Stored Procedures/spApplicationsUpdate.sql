
CREATE PROCEDURE [dbo].[spApplicationsUpdate] (
	@ApplicationName nvarchar(256),
	@LoweredApplicationName nvarchar(256),
	@ApplicationId uniqueidentifier,
	@Description nvarchar(256)
)
AS

SET NOCOUNT ON

UPDATE
	[Applications]
SET
	[ApplicationName] = @ApplicationName,
	[LoweredApplicationName] = @LoweredApplicationName,
	[Description] = @Description
WHERE
	[ApplicationId] = @ApplicationId
