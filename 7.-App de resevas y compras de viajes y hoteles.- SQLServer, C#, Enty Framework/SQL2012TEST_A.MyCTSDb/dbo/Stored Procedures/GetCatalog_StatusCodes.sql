
-- =============================================
-- Author:		Eduardo Sánchez Almazán
-- Create date: Jun-2009
-- =============================================
CREATE Procedure [dbo].[GetCatalog_StatusCodes]
 
AS
begin

select CatStaCodCode [Value], 
(CatStaCodCode + ' ' + CatStaCodDescription) [Text],
CatStaCodDescription [Text2], '' [Text3],'' [Text5],'' [Text6],'' [Text7],'' [Text8]
from 
	(
	Select Distinct rtrim(CatStaCodCode)CatStaCodCode, 
				rtrim(CatStaCodDescription)CatStaCodDescription
		From CatStatusCodes
	) as StatusCodes

end

