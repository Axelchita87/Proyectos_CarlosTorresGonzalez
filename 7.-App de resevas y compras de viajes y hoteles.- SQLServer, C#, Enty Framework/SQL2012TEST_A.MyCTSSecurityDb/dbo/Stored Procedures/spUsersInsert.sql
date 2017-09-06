-- =============================================
-- Author:		Denisse Cestelos R.
-- Modify:		Denisse Cestelos R.
-- Create date: 26 de abril de 2013
-- Modify date: 26 de abril de 2013
-- Description:	Inserta el nuevo usuario
-- =============================================
CREATE PROCEDURE spUsersInsert
	@ApplicationId uniqueidentifier,
	@UserName nvarchar(256),
	@LoweredUserName nvarchar(256),
	@UserMail nvarchar(50),
	@AgentMail nvarchar(50),
	@LastActivityDate datetime,
	@Firm nvarchar(50),
	@Password nvarchar(50),
	@FamilyName nvarchar(50),
	@Agent nvarchar(50),
	@Queue nvarchar(50),
	@PCC nvarchar(50),
	@TA nvarchar(50),
	@GDS NVARCHAR(10),
	@ProfileAllAccess nvarchar(3),
	@StatusFirm varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	
	INSERT INTO [Users] 
	(
		[ApplicationId],
		[UserName],
		[LoweredUserName],
		[UserMail],
		[AgentMail],
		[LastActivityDate],
		[Firm],
		[Password],
		[FamilyName],
		[Agent],
		[Queue],
		[PCC],
		[TA],
		[GDS],
		[ProfileAllAccess],
		[StatusFirm],
		[Supervisor]
	) 	
	VALUES 
	(
		@ApplicationId,
		@UserName,
		@LoweredUserName,
		@UserMail,
		@AgentMail,
		@LastActivityDate,
		@Firm,
		@Password,
		@FamilyName,
		@Agent,
		@Queue,
		@PCC,
		@TA,
		@GDS,
		@ProfileAllAccess,
		@StatusFirm,
		'False'
	)
END
-- =============================================
-- EXEC spUsersInsert '08F51017-BDBD-479E-9DC6-252E7DB11F1E','','','','','','','','','','','','','','',''
-- =============================================
