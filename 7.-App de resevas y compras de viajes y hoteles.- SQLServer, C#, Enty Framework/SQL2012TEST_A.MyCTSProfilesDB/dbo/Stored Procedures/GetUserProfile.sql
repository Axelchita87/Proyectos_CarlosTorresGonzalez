


--Creado por Eduardo S. Almazán
--obtiene los datos del usuario y su perfil
--septiembre 2009
--Modificación: Ivan Martínez Guerrero, Obtener OrgId, 13/Abr/2011
CREATE  PROCEDURE [dbo].[GetUserProfile] (
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

SELECT U.[ApplicationId],
	[UserId],
	[UserName],
	[LoweredUserName],
	[UserMail],
	[LastActivityDate],
	[Firm],
	[Password],
	[FamilyName],
	[Agent],
	[Queue],
	[PCC],
	[TA],
	[IsMySabreBlocked],	
	[InstallFramework35],
	[IsFramework35Installed],
	[ProfileAllAccess],
	[ApplicationName],
	[OrgId],
	[Supervisor]
FROM
	[Users] U
INNER JOIN (MyCTSDB_Dev.dbo.CatPccs P INNER JOIN dbo.Applications A ON
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

