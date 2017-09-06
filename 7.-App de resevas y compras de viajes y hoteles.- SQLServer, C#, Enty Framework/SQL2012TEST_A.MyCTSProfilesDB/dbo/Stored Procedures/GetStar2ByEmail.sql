



-- =============================================
-- Author:		<Marcos Q Ramirez>
-- Modify:		
-- Create date: <24/agosto/2012>
-- Modify date: 
-- Description:	<Procedimiento almacenado que permite extraer la informacion de la tabla de perfiles de segundo nivel por email>
-- =============================================
CREATE PROCEDURE [dbo].[GetStar2ByEmail]
	@Email NVARCHAR(100) = null	
AS
BEGIN
	DECLARE 
		@CategoryNameValues VARCHAR(MAX),
		@QueryString VARCHAR(MAX)

	SELECT
		@CategoryNameValues = COALESCE(@CategoryNameValues + ',[' + a.FieldName +']', '[' + a.FieldName +']') 
	FROM
	(
		SELECT FieldName
		FROM [DetailStars]
		WHERE [Level] = 2
		AND Visible   = 1
	) AS a

	SELECT @QueryString =
	'SELECT *' +
	'FROM' +
	'  (SELECT [Id],' + @CategoryNameValues + 
	'  FROM' +
	'    (SELECT FieldName,' +
	'      Value,' +
	'      S.Id' +
	'    FROM DetailStars AS Ds' +
	'    INNER JOIN' +
	'      (SELECT *' +
	'      FROM stars' +
	'      WHERE id =' +
	'        (SELECT top 1 Email.id' +
	'        FROM' +
	'          ( SELECT id FROM Stars WHERE [Value] = ''' + @Email +'''' +
	'          ) AS Email' +	
	'        )' +
	'      ) AS S ON Ds.Id                                  = S.FieldKey' +
	'    WHERE [level]                                      = ''2''' +
	'    ) AS SourceTable PIVOT ( MIN(Value) FOR FieldName IN (' + @CategoryNameValues + ') ) AS PivotTable' +
	'  ) AS tabla ' +
    'WHERE Email  = ''' + @Email + ''''

	EXEC (@QueryString)
END 
-- =============================================
-- EXEC dbo.GetStar2 @Pcc=N'L3UF',@Level1=N'HSE100',@Level2=N'PAZ/ENRIQUE'
-- =============================================





