



-- =============================================
-- Author:		Eduardo Sánchez Almazán
-- Create date: Sep - 2009
-- Description:	Regresa los catálogos correpondientes al usuario
-- =============================================
CREATE Procedure [dbo].[GetMissingCatalogs]
 @filesLeft as nvarchar(1000)
AS
 declare @sql nvarchar(4000)
declare @filename nvarchar(250)
declare @fileversion nchar(8)
declare @spname nvarchar(150)

DECLARE @outputCursor CURSOR

set @sql = N'select SPName from catalogs ' + 
			'where [filename] in (' + @filesLeft + ') order by orderby'

set @sql = 'SET @outputCursor = CURSOR FORWARD_ONLY STATIC FOR ' + 
			@sql + ' ; OPEN @outputCursor'
exec sp_executesql
              @sql,
              N'@outputCursor CURSOR OUTPUT',
              @outputCursor OUTPUT 

fetch next from @outputCursor
into @spname

while @@fetch_status = 0
begin
	exec @spname
	fetch next from @outputCursor
	into @spname
end

close @outputCursor
deallocate @outputCursor









