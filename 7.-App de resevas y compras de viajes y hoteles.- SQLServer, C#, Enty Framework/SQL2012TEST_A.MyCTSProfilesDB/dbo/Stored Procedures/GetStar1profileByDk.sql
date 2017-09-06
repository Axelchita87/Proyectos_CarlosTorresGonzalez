-- =============================================
-- Author:	Emmanuel FLores	
-- Modify:	Luis Felipe Segura Velasco
-- Create date: 17/05/2011
-- Modifi date: 02/08/2012
-- Description: Busca si se encuentra almacenado algun 
--				perfil de primer nivel con el DK pasado como
--				parametro
-- =============================================
CREATE PROCEDURE [dbo].[GetStar1profileByDk] 
	@vDK varchar(8)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT ProfileName + ' - ' + Pcc AS 'Level1'
	FROM   (SELECT FieldName,
				   Value,
				   S.Id
		   FROM    DetailStars AS Ds
				   LEFT JOIN
						   (SELECT *
						   FROM    Stars
						   WHERE   id IN
								   ( SELECT id
								   FROM    Stars
								   WHERE   fieldkey = 2
								   AND     value = @vDK
								   )
						   )
						   AS S
				   ON      Ds.Id = S.FieldKey
		   WHERE   [level] = 1
		   AND     FIELDNAME IN ('pcc',
								 'ProfileName',
								 'CustomerDk')
		   )
		   AS SourceTable PIVOT(MIN(Value) FOR FieldName IN (pcc,
															 ProfileName,
															 CustomerDk)) AS PivotTable
		WHERE ProfileName = @vDK
END
-- =============================================
-- EXECUTE dbo.GetStar1profileByDk 'EFF112'
-- =============================================

