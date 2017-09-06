
-- =============================================
-- Author:		Marcos Q. Ramirez
-- Create date: 25-02-2010
-- Description:	Obtiene las formas de pago activadas por aereolinea
-- =============================================
CREATE Procedure [dbo].[GetAirLinFOP]
 @AirlinToSearch as varchar(10)
AS
Begin

select CatAirLinFarId, CatAirLinFarName, CCAut, CCMan, Cash, PMix, Misc
from dbo.CatAirLinesFare
where CatAirLinFarId = @AirlinToSearch

End



