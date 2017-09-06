


create  PROCEDURE [dbo].[spUsersSelectByFirmPCC] (
	@Firma nvarchar(50), 
	@PCC nvarchar(50)
)
AS

SET NOCOUNT ON

SELECT
	[ApplicationId],
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
	[TA]
FROM
	[Users]
WHERE
	[Firm] = @Firma
AND [PCC] = @PCC




