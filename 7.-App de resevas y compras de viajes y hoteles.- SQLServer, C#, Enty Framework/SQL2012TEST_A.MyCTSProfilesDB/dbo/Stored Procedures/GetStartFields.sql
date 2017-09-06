
CREATE proc [dbo].[GetStartFields]
@id int
as

DECLARE @CategoryNameValues as NVARCHAR(1200);

SELECT @CategoryNameValues =
COALESCE(@CategoryNameValues + ',[' + a.FieldName +']',
'[' + a.FieldName +']')
FROM (SELECT DISTINCT FieldName FROM [StarTest] where StarId = @id) a
ORDER BY a.FieldName;

PRINT @CategoryNameValues;

--PRINT @CategoryNameValues;
DECLARE @QueryString as NVARCHAR(1000)

SET @QueryString =
'SELECT '
+ @CategoryNameValues +
'FROM
(SELECT  StarId,
            FieldName,
            Value FROM [StarTest] where StarId = ' + cast(@id as nvarchar(5)) + ')DataQuery 
PIVOT
(min([Value]) for FieldName IN ('+@CategoryNameValues+'))
as PivotResult
ORDER by StarId'

--print @QueryString
EXECUTE(@QueryString)