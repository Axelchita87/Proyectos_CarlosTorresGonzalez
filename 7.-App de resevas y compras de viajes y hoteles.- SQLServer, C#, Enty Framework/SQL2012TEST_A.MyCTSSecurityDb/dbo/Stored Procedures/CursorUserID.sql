
-- =============================================
-- Author:		Ivan Martinez
-- Create date: 22 Agosto 2011
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[CursorUserID] 

AS
BEGIN
	declare @m_userid uniqueidentifier

                  DECLARE userid_cursor CURSOR FAST_FORWARD FOR
                  select userid from dbo.Users where UserID not in (select UserId from dbo.UsersInRoles)

   open userid_cursor
                  fetch next from userid_cursor into @m_userid
	
	while @@FETCH_STATUS = 0
	begin         
        insert into dbo.UsersInRoles (UserID, RoleId)
		values (@m_userid,'C2EC3C21-4865-4699-8150-3A1557B0DF3F')
        
		fetch next from userid_cursor into @m_userid
	end
                  
    close userid_cursor
    deallocate userid_cursor


END

