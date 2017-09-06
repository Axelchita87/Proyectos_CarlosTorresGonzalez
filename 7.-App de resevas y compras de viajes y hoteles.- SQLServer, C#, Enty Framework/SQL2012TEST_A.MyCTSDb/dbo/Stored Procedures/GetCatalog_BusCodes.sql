
-- =============================================
-- Author:		Eduardo Sánchez Almazán
-- Create date: Jun-2009
-- =============================================
CREATE Procedure [dbo].[GetCatalog_BusCodes]
 
AS
begin

select CatBusCodCode [Value], 
(CatBusCodCode + ' ' + CatBusCodName) [Text],
CatBusCodName [Text2], '' [Text3],'' [Text5],'' [Text6],'' [Text7],'' [Text8]
from 
	(
	select distinct rtrim(CatBusCodCode) CatBusCodCode, rtrim(CatBusCodName) CatBusCodName
		From dbo.CatBusCodes
	) as BusCodes

end

