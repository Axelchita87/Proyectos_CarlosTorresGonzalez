-- =============================================
-- Author:		José Ricardo Brito Ortega
-- Create date: 14/07/2014
-- Description:	Divide y obtiene una tabla con las palabras obtenidas del corte de una frase a  a partir de un delimitador.
-- =============================================
CREATE FUNCTION fnSplitString
(	
	-- Add the parameters for the function here
	@String NVARCHAR(4000),
    @Delimiter NCHAR(1)
)
RETURNS TABLE 
AS
RETURN 
(
	WITH Split(stpos,endpos) 
    AS(
        SELECT 0 AS stpos, CHARINDEX(@Delimiter,@String) AS endpos
        UNION ALL
        SELECT endpos+1, CHARINDEX(@Delimiter,@String,endpos+1)
            FROM Split
            WHERE endpos > 0
    )
    SELECT 'Id' = ROW_NUMBER() OVER (ORDER BY (SELECT 1)),
        'Data' = SUBSTRING(@String,stpos,COALESCE(NULLIF(endpos,0),LEN(@String)+1)-stpos)
    FROM Split
)
