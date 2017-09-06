-- =============================================
-- Author:		<Marcos Q. Ramirez>
-- Create date: <Create Date,,>
-- Description:	<Description,,>

CREATE PROCEDURE GetOrganizations
AS
BEGIN
	select Orgname as [description], orgid as code  from catorganizations
END
