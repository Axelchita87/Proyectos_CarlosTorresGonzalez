CREATE procedure [dbo].[GetSingleDocument]
@docname nvarchar(250)
as
SELECT [DocId]
      ,[Documento]
      ,[NombreDoc]
      ,[Extension]
  FROM [DocsBinarios]
  where NombreDoc = @docname