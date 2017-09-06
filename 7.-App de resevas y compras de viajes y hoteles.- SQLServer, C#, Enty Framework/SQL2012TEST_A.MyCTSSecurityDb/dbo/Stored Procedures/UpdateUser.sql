


-- =============================================
-- Author:		<Jessica Gutierrez>
-- Creation date: 19-05-2010
-- Description:	Update User
-- Modify by: */
-- =============================================
create PROCEDURE [dbo].[UpdateUser] 

@UserId as varchar(50),
@Firm as varchar(4),
@PCC as varchar(4),
@CodeAgent as varchar(2),
@UserName as varchar(50),
@LoweredUserName as varchar(50),
@UserMail as varchar (50),
@TA as varchar(50),
@Queue as varchar (50)


AS
BEGIN
	
		update dbo.Users
		Set Agent=@CodeAgent,UserName=@UserName,LoweredUserName=@LoweredUserName,
			UserMail=@UserMail,TA=@TA,[Queue]=@Queue
		where Firm=@Firm and UserId=@UserId
	
END