-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE GetXMLStar2

	AS
BEGIN
	DECLARE @id int, @r_pcc varchar (10), @r_level1 varchar (100), @r_level2 varchar(100)
DECLARE @tmp table
(
	id int,
	pcc varchar(10),
	level1 varchar(100),
	level2 varchar(100)
)


CREATE TABLE #fin ( valor xml );

DECLARE @SALIDA XML
insert @tmp

select id, pcc, level1, level2 from UpdatedProfiles where StatusActualizacion = 0

select top 1 @id = id, @r_pcc = pcc, @r_level1 = level1, @r_level2 = level2 from @tmp

while (@@rowcount > 0)
begin
	-- AQUI EMPIEZA
	DECLARE 
		@CategoryNameValues VARCHAR(MAX),
		@QueryString VARCHAR(MAX)

insert into #fin
SELECT  (
SELECT *
  FROM (SELECT [Id],[AlternativeEmail],[Birthday],[CadHotel1],[CadHotel2],[City],[Colony],[Comments],[CostCenter],
  [CreditCar],[CreditCard2],[CreditCard3],[CreditCard4],[CreditCard5],[CreditCard6],[CreditCard7],[CreditCard8],
  [CustomerField1],[CustomerField2],[CustomerField3],[DATE],[DateModify],[DirectPhone],[DirectPhoneCode],[Division],
  [Email],[EmployeeID],[Estate],[Ext],[Family1],[Family2],[Family3],[Family4],[Family5],[Family6],[FrequentFlyer1],
  [FrequentFlyer2],[FrequentFlyer3],[FrequentFlyer4],[FrequentFlyer5],[Gender],[Historic],[HotelCreditCar],[ImmigrationForm],
  [LastName],[LastName2],[Leasing1],[Leasing2],[Level1],[Level2],[ManagerLoginID],[Maternal],[MiddleName],[ModifyOrigin],
  [MonthPreferences],[Name],[Name2],[Occupation],[OfficePhone],[OfficePhoneCode],[Osi],[Passport],[Passport2],[Passport3],
  [Paternal],[Pcc],[PersonalCar],[PlacePreferences],[Position_Title],[PostalCode],[Purged],[Remarks],[RFC],[SabreFormats],
  [Seat],[StreetAndNumber],[TravelClass],[Visa],[WantInformation]
   FROM    (SELECT FieldName,      VALUE,      S.Id    FROM DetailStars AS Ds    
   LEFT JOIN      (SELECT *      FROM stars      WHERE id =        (SELECT top 1 pcc.id        FROM          
   ( SELECT id FROM Stars WHERE fieldkey IN (3,27) AND [VALUE] = @r_pcc          ) AS pcc        JOIN         
    ( SELECT id FROM Stars WHERE fieldkey = 28 AND [VALUE] = @r_level1         ) AS level1        
	ON pcc.id = level1.id        JOIN          ( SELECT id FROM Stars WHERE fieldkey = 29 AND [VALUE] = @r_level2         )
	 AS level2        ON pcc.id = level2.id        )      ) AS S ON 
	 Ds.Id                                  = S.FieldKey    WHERE [LEVEL]                                      = '2'    ) 
	 AS SourceTable PIVOT ( MIN(VALUE) FOR FieldName IN ([AlternativeEmail],[Birthday],[CadHotel1],[CadHotel2],[City],[Colony],
	 [Comments],[CostCenter],[CreditCar],[CreditCard2],[CreditCard3],[CreditCard4],[CreditCard5],[CreditCard6],[CreditCard7],
	 [CreditCard8],[CustomerField1],[CustomerField2],[CustomerField3],[DATE],[DateModify],[DirectPhone],[DirectPhoneCode],[Division],
	 [Email],[EmployeeID],[Estate],[Ext],[Family1],[Family2],[Family3],[Family4],[Family5],[Family6],[FrequentFlyer1],[FrequentFlyer2],
	 [FrequentFlyer3],[FrequentFlyer4],[FrequentFlyer5],[Gender],[Historic],[HotelCreditCar],[ImmigrationForm],[LastName],[LastName2],
	 [Leasing1],[Leasing2],[Level1],[Level2],[ManagerLoginID],[Maternal],[MiddleName],[ModifyOrigin],[MonthPreferences],[Name],[Name2],
	 [Occupation],[OfficePhone],[OfficePhoneCode],[Osi],[Passport],[Passport2],[Passport3],[Paternal],[Pcc],[PersonalCar],
	 [PlacePreferences],[Position_Title],[PostalCode],[Purged],[Remarks],[RFC],[SabreFormats],[Seat],[StreetAndNumber],[TravelClass],
	 [Visa],[WantInformation]) ) AS PivotTable  ) AS
   tabla WHERE Pcc  = @r_pcc AND Level1 = @r_level1 AND Level2 = @r_level2 FOR XML AUTO
   ) AS TB
	
	delete from @tmp where id=@id
	select top 1 @id = id, @r_pcc = pcc, @r_level1 = level1, @r_level2 = level2 from @tmp
end

select * from #fin
drop table #fin
END

