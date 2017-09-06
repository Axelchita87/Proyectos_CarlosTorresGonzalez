-- =============================================
-- Author:		<Emmanuel Flores>
-- Modify:		Luis Felipe Segura Velasco
-- Create date: <22/julio/2011>
-- Modify date: 6 de Julio de 2012
-- Description:	<Procedimiento almacenado que permite extraer la informacion de la tabla de perfiles>
-- =============================================
CREATE PROCEDURE [dbo].[GetStar2]
	@Pcc NVARCHAR(10) = null,
	@Level1 NVARCHAR(100) = null,
	@level2 NVARCHAR(100) = null
AS
BEGIN
	DECLARE 
		@CategoryNameValues VARCHAR(MAX),
		@QueryString VARCHAR(MAX)

	SELECT  
		@CategoryNameValues = COALESCE(@CategoryNameValues + ',[' + a.FieldName +']', '[' + a.FieldName +']') 
	FROM
	(
		SELECT DISTINCT FieldName
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
	'    LEFT JOIN' +
	'      (SELECT *' +
	'      FROM stars' +
	'      WHERE id = ' +
	'        (SELECT top 1 pcc.id' +
	'        FROM' +
	'          ( SELECT id FROM Stars WHERE fieldkey IN (3,27) AND [Value] = ''' + @Pcc +'''' +
	'          ) AS pcc' +
	'        JOIN' +
	'          ( SELECT id FROM Stars WHERE fieldkey = 28 AND [Value] = ''' + @Level1  +'''' +
	'          ) AS level1' +
	'        ON pcc.id = level1.id' +
	'        JOIN' +
	'          ( SELECT id FROM Stars WHERE fieldkey = 29 AND [Value] = ''' + @Level2 + '''' +
	'          ) AS level2' +
	'        ON pcc.id = level2.id' +
	'        )' +
	'      ) AS S ON Ds.Id                                  = S.FieldKey' +
	'    WHERE [level]                                      = ''2''' +
	'    ) AS SourceTable PIVOT ( MIN(Value) FOR FieldName IN (' + @CategoryNameValues + ') ) AS PivotTable' +
	'  ) AS tabla ' +
	'WHERE Pcc  = ''' + @Pcc + '''' +
	'AND Level1 = ''' + @Level1 + '''' +
	'AND Level2 = ''' + @Level2 + ''''
	print @QueryString
	exec (@QueryString)
END 
-- =============================================
-- EXEC dbo.GetStar2 @Pcc=N'3l64',@Level1=N'E97107',@Level2=N'sanchez/juan'
-- =============================================



