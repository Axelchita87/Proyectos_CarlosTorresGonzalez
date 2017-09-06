
CREATE PROCEDURE [dbo].[spApplicationsSelectAll] AS

SET NOCOUNT ON

SELECT
	[ApplicationName],
	[LoweredApplicationName],
	[ApplicationId],
	[Description]
FROM
	[Applications]
