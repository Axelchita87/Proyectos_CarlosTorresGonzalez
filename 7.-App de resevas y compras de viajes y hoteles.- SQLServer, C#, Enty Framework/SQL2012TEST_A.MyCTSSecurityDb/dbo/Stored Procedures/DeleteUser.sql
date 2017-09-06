-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 26-11-2009
-- Description:	Procedure that delete a user of Profile,UserinRoles and Users,
-- =============================================
Create Procedure [dbo].[DeleteUser]
	@Firm nvarchar(50),
	@PCC nvarchar(50)
AS
Declare @UserId uniqueidentifier

Begin
	If Exists(Select UserId From dbo.Users Where Firm=@Firm and PCC=@PCC)
	Begin
		--Getting the UserID for @Firm and @PCC 
		Select @UserID=UserId From dbo.Users Where Firm=@Firm and PCC=@PCC
		--Deleting @UserID from Profile
		Exec dbo.spProfileDeleteByUserId @UserID
		--Deleting @UserID from UsersInRoles
		Exec dbo.spUsersInRolesDeleteByUserId @UserID
		--Deleting @UserID from Users
		Exec dbo.spUsersDelete @UserID
	End
End
