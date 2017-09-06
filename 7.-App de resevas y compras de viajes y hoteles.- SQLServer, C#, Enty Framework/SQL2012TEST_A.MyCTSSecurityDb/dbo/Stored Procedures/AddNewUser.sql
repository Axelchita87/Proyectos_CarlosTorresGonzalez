-- =============================================
-- Author:		Denisse Cestelos R.
-- Modify:		Denisse Cestelos R.
-- Create date: 26 de abril de 2013
-- Modify date: 26 de abril de 2013
-- Description:	agrega un nuevo usuario y asigna rol
-- =============================================
CREATE PROCEDURE AddNewUser
	@UserName nvarchar(256),
	@LoweredUserName nvarchar(256),
	@UserMail nvarchar(50),
	@AgentMail nvarchar(50),
	@LastActivityDate nvarchar(10),
	@Firm nvarchar(50),
	@Password nvarchar(50),
	@FamilyName nvarchar(50),
	@Agent nvarchar(50),
	@Queue nvarchar(50),
	@PCC nvarchar(50),
	@TA nvarchar(50),
	@GDS NVARCHAR(10)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE 
		@ApplicationId uniqueidentifier,
		@UserId uniqueidentifier,
		@RoleId uniqueidentifier,
		@PropertyNames varchar(8000),
		@PropertyValuesString varchar(8000),
		@ProfileAllAccess varchar(3),
		@StatusFirm varchar(1)
	
	SET @StatusFirm= 'A'
	SET @ProfileAllAccess='I'
	SET @PropertyNames='BANNER|*|BANNER_FONT_COLOR|*|BANNER_FONT_SIZE'
	SET	@PropertyValuesString='Bienvenido a MyCTS|*|red|*|12'

	SELECT 
		@ApplicationId=ApplicationId, 
		@RoleId=RoleId 
	FROM 
		dbo.Roles
	WHERE 
		RoleName = '[users]'


	EXEC dbo.spUsersInsert @ApplicationId, @UserName,@LoweredUserName,@UserMail,@AgentMail,@LastActivityDate,@Firm,@Password,@FamilyName,@Agent,@Queue,@PCC,@TA,@GDS,@ProfileAllAccess,@StatusFirm

	SELECT TOP 1
		@UserId=UserId 
	FROM 
		Users 
	WHERE 
		Firm=@Firm
	ORDER BY DATEIN DESC		

	-- Inserta usuarios en la tabla [UsersInRoles]
	EXEC dbo.spUsersInRolesInsert @UserId,@RoleId

	-- Inserta perfil de usuario
	EXEC dbo.spProfileInsert @UserId,@PropertyNames,@PropertyValuesString,Null,''
END
-- =============================================
-- EXEC AddNewUser @UserName=N'R ARREOLA',@LoweredUserName=N'r arreola',@UserMail=N'rarreola@ctsmex.com.mx',@LastActivityDate=N'10/09/2013',@Firm=N'1808',@Password=N'TMP1234',@FamilyName=N'rodrigo arreola estrello',@Agent=N'EF',@Queue=N'152',@PCC=N'1JLG',@TA=N'05CDF6',@GDS=N'SA',@AgentMail=N'rarreola1jlg@ctsmex.com.mx'
-- =============================================

