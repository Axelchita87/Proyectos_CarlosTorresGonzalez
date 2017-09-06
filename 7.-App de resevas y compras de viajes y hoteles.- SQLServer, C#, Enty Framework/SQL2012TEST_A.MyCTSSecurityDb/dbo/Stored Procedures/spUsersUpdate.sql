

CREATE PROCEDURE [dbo].[spUsersUpdate] (
	@ApplicationId uniqueidentifier,
	@UserId uniqueidentifier,
	@UserName nvarchar(256),
	@LoweredUserName nvarchar(256),
	@UserMail nvarchar(50),
	@LastActivityDate datetime,
	@Firm nvarchar(50),
	@Password nvarchar(50),
	@FamilyName nvarchar(50),
	@Agent nvarchar(50),
	@Queue nvarchar(50),
	@PCC nvarchar(50),
	@TA nvarchar(50)
)
AS

SET NOCOUNT ON

UPDATE
	[Users]
SET
	[LastActivityDate] = @LastActivityDate,
	[Firm] = @Firm,
	[Password] = @Password,
	[Agent] = @Agent,
	[Queue] = @Queue,
	[PCC] = @PCC,
	[TA] = @TA
WHERE
	[UserId] = @UserId

--UPDATE
--	[Users]
--SET
--	[ApplicationId] = @ApplicationId,
--	[UserName] = @UserName,
--	[LoweredUserName] = @LoweredUserName,
--	[UserMail] = @UserMail,
--	[LastActivityDate] = @LastActivityDate,
--	[Firm] = @Firm,
--	[Password] = @Password,
--	[FamilyName] = @FamilyName,
--	[Agent] = @Agent,
--	[Queue] = @Queue,
--	[PCC] = @PCC,
--	[TA] = @TA
--WHERE
--	[UserId] = @UserId

