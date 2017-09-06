
CREATE PROCEDURE [dbo].[spApplicationsInsert] (
	@ApplicationName nvarchar(256),
	@LoweredApplicationName nvarchar(256),
	@ApplicationId uniqueidentifier,
	@Description nvarchar(256)
)
AS

SET NOCOUNT ON

INSERT INTO [Applications] (
	[ApplicationName],
	[LoweredApplicationName],
	[ApplicationId],
	[Description]
) VALUES (
	@ApplicationName,
	@LoweredApplicationName,
	@ApplicationId,
	@Description
)
