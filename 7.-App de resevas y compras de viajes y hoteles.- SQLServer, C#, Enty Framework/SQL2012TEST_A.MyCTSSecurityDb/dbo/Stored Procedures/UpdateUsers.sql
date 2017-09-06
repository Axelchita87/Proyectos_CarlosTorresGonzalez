
-- =============================================
-- Author:		<Angel Trejo Arizmendi>
-- Creation date: 07-05-2010
-- Description:	Update Users by Firm and PCC
-- Modify by: */
-- =============================================
Create PROCEDURE [dbo].[UpdateUsers] 

@Firm as varchar(4),
@PCC as varchar(4),
@CodeAgent as varchar(2),
@UserName as varchar(50),
@LoweredUserName as varchar(50)

AS
BEGIN
	if(@CodeAgent is not null and @CodeAgent<>'')
	begin
		update dbo.Users
		Set Agent=@CodeAgent
		where Firm=@Firm and PCC=@PCC
	end
	if(@UserName is not null and @UserName<>'')
	begin
		update dbo.Users
		Set UserName=@UserName
		where Firm=@Firm and PCC=@PCC
	end
	if(@LoweredUserName is not null and @LoweredUserName<>'')
	begin
		update dbo.Users
		Set LoweredUserName=@LoweredUserName
		where Firm=@Firm and PCC=@PCC
	end
END