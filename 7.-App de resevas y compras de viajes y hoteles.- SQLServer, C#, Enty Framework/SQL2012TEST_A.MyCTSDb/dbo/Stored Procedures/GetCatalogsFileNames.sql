



-- =============================================
-- Author:		Eduardo Sánchez Almazán
-- Create date: Sep - 2009
-- Description:	Regresa el nombre de todos los catálogos
-- =============================================
CREATE Procedure [dbo].[GetCatalogsFileNames]
AS

select lower([filename]) [filename]
from catalogs
order by orderby









