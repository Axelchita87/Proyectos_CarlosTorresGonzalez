
-- =============================================
-- Author:		<Emmanuel Flores>
-- Modify:		Luis Felipe Segura Velasco
-- Create date: <22/julio/2011>
-- Modify date: 8 de Julio de 2012
-- Description:	<Procedimiento almacenado que permite extraer la informacion
--				 de la tabla de perfiles>
-- =============================================
CREATE PROCEDURE [dbo].[GetStar1]
	@Pcc as nvarchar(10),
	@Level1 as nvarchar(100)	
AS
BEGIN

	DECLARE
	  @CategoryNameValues VARCHAR(MAX),
	  @CustomerDK VARCHAR(15),
	  @QueryString VARCHAR(MAX)

	SET @CustomerDK = 'CustomerDK'

	SELECT @CategoryNameValues = COALESCE(@CategoryNameValues + ',[' + a.FieldName +']', '[' + a.FieldName +']') 
	FROM
	  (SELECT top(1000) FieldName
	  FROM [DetailStars]
	  WHERE [Level]  = 1
	  AND Visible    = 1
	  AND FieldName <> 'CustomerDK'
	  ORDER BY OrderNum
	  ) AS a

	SELECT @QueryString = 
	'SELECT * ' +
	'FROM' +
	'  (SELECT [Id],' +
	'    CASE' +
	'      WHEN ' + @CustomerDK + ' IS NULL' +' THEN [ProfileName]' +
	'      ELSE CustomerDK' +
	'    END AS CustomerDk,' + @CategoryNameValues +
	'  FROM' +
	'    ( SELECT DISTINCT FieldName,' +
	'      Value,' +
	'      S.Id' +
	'    FROM DetailStars AS Ds' +
	'    JOIN Stars       AS S' +
	'    ON Ds.Id    = S.FieldKey' +
	'    WHERE S.ID IN' +
	'      (SELECT ID' +
	'      FROM Stars' +
	'      WHERE [value] = ''' + @Pcc + '''' +
	'      AND fieldkey  = 3 ' + 
	'      AND ID       IN' +
	'        ( SELECT ID FROM Stars WHERE [value] = ''' + @Level1 + ''' AND fieldkey = 1' +
	'        )' +
	'      )' +
	'    AND [LEVEL] = 1' +
	'    ) AS SourceTable PIVOT ( MIN(Value) FOR FieldName IN (' + @CategoryNameValues + ',' + @CustomerDK + ') ) AS PivotTable' +
	'  ) AS tabla' 

	exec (@QueryString)
END 
-- =============================================
-- EXEC dbo.GetStar1 @Pcc=N'L3UF',@Level1=N'HSE100'
-- =============================================
