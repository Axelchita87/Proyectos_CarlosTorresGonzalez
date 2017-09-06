-- =============================================
-- Author:		???????????
-- Modify:		Luis Felipe Segura Velasco
-- Create date: ???????????
-- Modify date: 5 de Mayo de 2012
-- Description:	Obtiene el perfil de Interjet
-- =============================================
CREATE PROCEDURE [dbo].[GetInterJetProfile] 
	@input varchar(MAX)
AS
BEGIN
SELECT *
FROM   (SELECT [Id],
			   [Pcc],
               [Level1],
               [Level2],
               [Name],
               [LastName],
               [OfficePhone],
               [Ext],
               [OfficePhoneCode],
               [DirectPhone],
               [DirectPhoneCode],
               [Email],
               [FrequentFlyer1],
               [FrequentFlyer2],
               [FrequentFlyer3],
               [FrequentFlyer4],
               [FrequentFlyer5],
               [Passport],
               [Birthday],
               [Visa],
               [ImmigrationForm],
               [RFC],
               [CreditCar],
               [PersonalCar],
               [StreetAndNumber],
               [Colony],
               [PostalCode],
               [Estate],
               [City],
               [Name2],
               [LastName2],
               [Paternal],
               [Maternal],
               [Occupation],
			   [Seat],
			   [Family1],
			   [Family2],
			   [Family3],
			   [Family4],
			   [Family5],
			   [Family6],
               [Comments],
               [HotelCreditCar],
               [CadHotel1],
               [CadHotel2],
               [Leasing1],
               [Leasing2],
               [DATE],
               [Purged],
               [Osi],
               [Remarks],
			   [AlternativeEmail],
			   [Historic],
			   [SabreFormats],
               [CreditCard2],
               [CreditCard3],
               [CreditCard4],
               [CreditCard5],
               [CreditCard6],
               [CreditCard7],
               [CreditCard8]
	 FROM     ( SELECT FieldName,
					   Value,
					   S.Id
				FROM   DetailStars AS Ds
				LEFT JOIN
                       ( SELECT id,
                               FieldKey,
                               [Value]
						FROM   Stars
                       )
                       AS S
               ON          Ds.Id = S.FieldKey
       WHERE    [level] = 2
       AND     s.id IN
               ( 
				SELECT id
               FROM    Stars
               WHERE   [Value] = @input
               )
       ) AS SourceTable  
PIVOT  (  MIN(Value) FOR FieldName IN ([Pcc],
                                       [Level1],
                                       [Level2],
                                       [Name],
                                       [LastName],
                                       [OfficePhone],
                                       [Ext],
                                       [OfficePhoneCode],
                                       [DirectPhone],
                                       [DirectPhoneCode],
                                       [Email],
                                       [FrequentFlyer1],
                                       [FrequentFlyer2],
                                       [FrequentFlyer3],
                                       [FrequentFlyer4],
                                       [FrequentFlyer5],
                                       [Passport],
                                       [Birthday],
                                       [Visa],
                                       [ImmigrationForm],
                                       [RFC],
                                       [CreditCar],
                                       [PersonalCar],
                                       [StreetAndNumber],
                                       [Colony],
                                       [PostalCode],
                                       [Estate],
                                       [City],
                                       [Name2],
                                       [LastName2],
                                       [Paternal],
                                       [Maternal],
                                       [Occupation],
                                       [Seat],
                                       [Family1],
                                       [Family2],
                                       [Family3],
                                       [Family4],
                                       [Family5],
                                       [Family6],
                                       [Comments],
                                       [HotelCreditCar],
                                       [CadHotel1],
                                       [CadHotel2],
                                       [Leasing1],
                                       [Leasing2],
                                       [DATE],
                                       [Purged],
                                       [Osi],
                                       [Remarks],
                                       [CreditCard2],
                                       [CreditCard3],
                                       [CreditCard4],
                                       [CreditCard5],
                                       [CreditCard6],
                                       [CreditCard7],
                                       [CreditCard8],
                                       [AlternativeEmail],
                                       [Historic],
                                       [SabreFormats])  
						) AS PivotTable
				) AS tabla
WHERE  LEVEL2 = @input
END

