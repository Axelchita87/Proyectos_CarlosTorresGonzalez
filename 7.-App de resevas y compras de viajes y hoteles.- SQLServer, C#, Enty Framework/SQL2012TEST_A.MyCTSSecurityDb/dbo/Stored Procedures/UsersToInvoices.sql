

-- =============================================
-- Author:		<Angel Trejo Arizmendi>
-- Creation date: 18-06-2010
-- Description:	Get Information By user
-- Modify by: Marcos Ramirez*/
-- =============================================
CREATE PROCEDURE [dbo].[UsersToInvoices]
@Firm nvarchar(50),
@Password nvarchar(50),
@PCC nvarchar(50)
AS
BEGIN
    if @Firm like '%@%'
	begin
	select  FamilyName, UserMail, OrgId, '0' as adminUser from UserInvoices
	where UserMail=@Firm and [Password]=@Password
	end
	else
	select FamilyName,UserMail, OrgId, case when (select  r.rolename from 
usersinroles ur, 
roles r,
users u
where 
u.UserId = ur.UserId
and r.RoleId = ur.RoleId
and r.rolename = '[mycts]'
and firm = us.Firm

) is null then '0' else '1' end as adminuser from dbo.Users Us
	inner join MyCTSDb.dbo.CatPccs CP on Us.PCC = CP.CatPccId
	inner join MyCTSSecurityDb.dbo.Applications A on CP.ApplicationId=A.ApplicationId
	where Firm=@Firm and PCC=@PCC --and [Password]=@Password
	
END