CREATE PROCEDURE [dbo].[GetUserProfile] (
	@Firma nvarchar(50), 
	@PCC nvarchar(50)
)
AS

SET NOCOUNT ON
declare @uid uniqueidentifier

SELECT top 1 
	@uid = [UserId]	
FROM
	[Users]
WHERE
	[Firm] = @Firma
AND [PCC] = @PCC
AND StatusFirm = 'A'

SELECT U.[ApplicationId],
	[UserId],
	[UserName],
	[LoweredUserName],
	[UserMail],
	[AgentMail],
	[StatusFirm],
	[LastActivityDate],
	[Firm],
	[Password],
	[FamilyName],
	[Agent],
	[Queue],
	[PCC],
	[StatusFirm],
	[TA],
	[IsMySabreBlocked],	
	[InstallFramework35],
	[IsFramework35Installed],
	[ProfileAllAccess],
	[ApplicationName],
	[OrgId],
	[Supervisor],
    [UpgradeStatus]
FROM
	[Users] U
INNER JOIN (MyCTSDB.dbo.CatPccs P INNER JOIN dbo.Applications A ON
P.ApplicationId = A.ApplicationId)ON U.PCC=P.CatPccId
WHERE [UserId] = @uid


SELECT
	[UserId],
	[PropertyNames],
	[PropertyValuesString],
	[PropertyValuesBinary],
	[LastUpdatedDate]
FROM
	[Profile]
WHERE
	[UserId] = @uid

