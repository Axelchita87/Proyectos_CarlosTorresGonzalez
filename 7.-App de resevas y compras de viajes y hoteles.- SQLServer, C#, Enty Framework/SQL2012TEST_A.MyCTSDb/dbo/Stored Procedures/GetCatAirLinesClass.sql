-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCatAirLinesClass]
	
AS
BEGIN
 declare @Sql varchar(1000)
 set @Sql = 'SELECT CatAirLinClaId,CatAirLinClaName FROM CatAirLinesClass'
 exec(@Sql)
--print @Sql
END



