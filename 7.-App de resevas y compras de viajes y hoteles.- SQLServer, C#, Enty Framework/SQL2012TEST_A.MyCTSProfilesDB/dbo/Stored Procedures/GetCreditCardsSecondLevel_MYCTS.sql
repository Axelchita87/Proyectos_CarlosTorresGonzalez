-- =============================================
-- Author:		<Ivan Martínez Guerrero>
-- Modifier:	Luis Felipe Segura Velasco 
-- Create date: <22/julio/2011>
-- Modify date: 8 de Julio de 2012
-- Description:	<Procedimiento almacenado que permite extraer trajetas de crédito
--				 de la tabla de perfiles>
-- =============================================
CREATE PROCEDURE [dbo].[GetCreditCardsSecondLevel_MYCTS]
	@Name AS VARCHAR(50),
	@Level1 AS VARCHAR(10),
	@LastName AS VARCHAR(50)
AS BEGIN

	DECLARE
		@CategoryNameValues AS NVARCHAR(MAX),
		@QueryString AS NVARCHAR(MAX), 
		@DisplayNames AS NVARCHAR(MAX), 
		@FieldNames AS NVARCHAR(MAX) ,
		@merde as nvarchar(max)
		
	SELECT @FieldNames = '''CreditCar'',''HotelCreditCar'',''CreditCard2'',''CreditCard3'',''CreditCard4'',''CreditCard5'',''CreditCard6'',''CreditCard7'',''CreditCard8'',''Name'',''Level1'',''LastName'', ''MiddleName'''
	SELECT @DisplayNames = 'CreditCar,HotelCreditCar,CreditCard2,CreditCard3,CreditCard4,CreditCard5,CreditCard6,CreditCard7,CreditCard8'
	
	select @merde = REPLACE(LTRIM(RTRIM(@Name)),' ','')

	SELECT @CategoryNameValues = COALESCE(@CategoryNameValues + ',[' + a.FieldName +']', '[' + a.FieldName +']') FROM
		(SELECT FieldName
		FROM [DetailStars]
		WHERE [Level] = 2
		AND Visible   = 1
		AND FieldName in ('CreditCar','HotelCreditCar','CreditCard2','CreditCard3','CreditCard4','CreditCard5','CreditCard6','CreditCard7','CreditCard8','Name','Level1','LastName', 'MiddleName')
		) AS a

	SELECT @QueryString =
	'SELECT ' + @DisplayNames +
	' FROM' +
	'  (SELECT [Id],' + @CategoryNameValues +
	'  FROM' +
	'    (SELECT FieldName,' +
	'      Value,' +
	'      S.Id' +
	'    FROM' +
	'      ( SELECT * FROM DetailStars WHERE [level] = 2 and Fieldname in (' + @FieldNames + ' )' + 
	'      ) AS Ds' +
	'    JOIN' +
	'      (SELECT *' +
	'      FROM stars' +
	'      WHERE id IN' +
	'        (SELECT nam.id ID' +
	'        FROM' +
	'          ( SELECT Id FROM Stars ' +
	'          ) AS nam' +
	'        JOIN' +
	'          ( SELECT Id FROM Stars WHERE [Value] = ''' + @Level1 + '''' +
	'          ) AS lev' +
	'        ON nam.id = lev.id' +
	'        JOIN' +
	'          ( SELECT Id FROM Stars WHERE [Value] = ''' + @LastName + '''' +
	'          ) AS lstn' +
	'        ON nam.id = lstn.id' +
	'        )' +
	'      ) AS S ON Ds.Id = S.FieldKey' +
	'    ) AS SourceTable PIVOT ( MIN(Value) FOR FieldName IN (' + @CategoryNameValues + ') ) AS PivotTable' +
	'  ) AS tabla ' +
	/*
	'WHERE Name   = ''' + @Name + '''' +
	'AND Level1   = ''' + @Level1 + '''' +
	'AND LastName = ''' + @LastName + ''''
	EXECUTE (@QueryString)
	*/
--/*
		' where Level1 = ''' + @Level1  +''' and LastName like ''' + @LastName +'%''' +
		
		' and (REPLACE(LTRIM(RTRIM(Name + ISNULL(MiddleName,''''))),'' '','''') like '''+ @merde + '%'''  + 'OR MiddleName like' + '''%' + @Name +'%'')'
		--' WHERE ( ''' + @Name  + ''' like name + ''%'' OR ' + '''' + @Name+ ''' like ' + '''%'' + MiddleName ' + '+ ''%'')' 
 
--select (@QueryString)
--*/ 
EXECUTE (@QueryString)
END
-- =============================================
-- EXEC dbo.GetCreditCardsSecondLevel @Name=N'SERGIO',@LastName=N'ALVAREZ CANTU',@Level1=N'RIC100'
-- =============================================



/****** Object:  StoredProcedure [dbo].[GetCreditCardsFirstLevel]    Script Date: 05/12/2014 9:08:39 ******/
SET ANSI_NULLS ON
