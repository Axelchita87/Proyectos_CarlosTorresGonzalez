CREATE PROCEDURE AddNewUserIn 
	-- Add the parameters for the stored procedure here
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

Declare @ApplicationId uniqueidentifier,
		@UserId uniqueidentifier,
		@RoleId uniqueidentifier,
		@PropertyNames varchar(8000),
		@PropertyValuesString varchar(8000),
		@ProfileAllAccess varchar(3)
BEGIN
	--MyCTS Application - Admin 
	Select @ApplicationId=ApplicationId , @RoleId=RoleId From dbo.Roles
	Where RoleName = '[users]'
	--Add a new user
	--Set @UserId = NewId()
	Set @ProfileAllAccess='I'
	Exec dbo.spUsersInsert @ApplicationId, @UserName,@LoweredUserName,@UserMail,@AgentMail,@LastActivityDate,@Firm,@Password,@FamilyName,@Agent,@Queue,@PCC,@TA,@GDS,@ProfileAllAccess
	--Add a new UsersInRoles
	Select @UserId=UserId From Users Where Firm=@Firm
	Exec dbo.spUsersInRolesInsert @UserId,@RoleId
	--Add a new Profile for the new User created
	Set @PropertyNames='BANNER|*|BANNER_FONT_COLOR|*|BANNER_FONT_SIZE'
	Set	@PropertyValuesString='Bienvenido a MyCTS|*|red|*|12'
	--declare @ActualDate varchar(10)
	--Set @ActualDate= SELECT CONVERT(VARCHAR(10),GETDATE(),120) AS [YYYY/DD/MM]
	Exec dbo.spProfileInsert @UserId,@PropertyNames,@PropertyValuesString,Null,''
END
