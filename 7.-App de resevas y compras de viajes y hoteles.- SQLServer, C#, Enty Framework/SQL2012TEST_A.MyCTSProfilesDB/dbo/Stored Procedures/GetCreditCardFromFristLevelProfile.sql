-- =============================================
-- Author:		<Marcos Q. Ramirez Luna>
-- Modifier:	Luis Felipe Segura Velasco / Ivan Martinez Guerrero
-- Create date: <05/Febrero/2010>
-- Modify date: 26 de Julio de 2013
-- Description:	<Obtiene el catalogo de todas las estrellas de primer y segundo nivel>
-- =============================================
CREATE PROCEDURE [dbo].[GetCreditCardFromFristLevelProfile]
	@input varchar(MAX)
AS
BEGIN
	SELECT *
	FROM   ( SELECT [ProfileName],
				   [CreditCard],
				   [CreditCard2],
				   [CreditCard3],
				   [CreditCard4],
				   [CreditCard5]
		   FROM    (SELECT FieldName,
						   Value,
						   S.Id
				   FROM    DetailStars AS Ds
						   LEFT JOIN
								    (
									   SELECT id,
											   FieldKey,
											   [Value]
										FROM    Stars
										WHERE ID = 
										(
											SELECT id
											FROM    Stars
											WHERE value =  @input
											and fieldkey = 1
										)
									)
								   AS S
						   ON      Ds.Id = S.FieldKey
				   WHERE   [level] = 1
					AND FieldName IN (
					'ProfileName',
					'CreditCard',
					'CreditCard2',
					'CreditCard3',
					'CreditCard4',
					'CreditCard5')
				   )
				   AS SourceTable PIVOT ( MIN(Value) FOR FieldName IN ([ProfileName],
																	   [CreditCard],
																	   [CreditCard2],
																	   [CreditCard3],
																	   [CreditCard4],
																	   [CreditCard5]) ) AS PivotTable
		   )
		   AS tabla
	WHERE  ProfileName = @input
END
-- =============================================
-- exec GetCreditCardFromFristLevelProfile 'CNM100'
-- =============================================