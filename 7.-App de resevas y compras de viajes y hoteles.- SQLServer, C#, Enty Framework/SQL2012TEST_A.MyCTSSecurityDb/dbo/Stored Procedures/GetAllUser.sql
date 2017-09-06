
-- =============================================
-- Author:		<Jessica Gutierrez Becerril>
-- Create date: <28-04-2010>
-- Description:	<Extrae todos los usuarios con sus datos>
-- =============================================
create PROCEDURE [dbo].[GetAllUser] 
AS
BEGIN
Select UserName,UserMail,Firm,FamilyName,Agent,PCC
from dbo.Users
END
