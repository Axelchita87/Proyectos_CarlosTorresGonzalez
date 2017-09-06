



-- =============================================
-- Author:		Jessica Gutierrez
-- Create date: 11-05-2010
-- Description:	Delete user by Firm
-- =============================================

create PROCEDURE [dbo].[DeleteUsers] 
(
	@Firm nvarchar (50),
	@PCC  nvarchar (50)
)
AS

--SET NOCOUNT ON

DELETE  FROM 
 dbo.UsersInRoles 
WHERE
	
	UserId=(Select UserId from dbo.Users where Firm like @Firm + '%'  and PCC = @PCC)

DELETE  FROM 
  [Profile]
WHERE
	
	UserId=(Select UserId from dbo.Users where Firm like @Firm + '%'  and PCC = @PCC )

DELETE  FROM 
 dbo.Users
WHERE
	Firm like @Firm +'%'  and PCC = @PCC 
