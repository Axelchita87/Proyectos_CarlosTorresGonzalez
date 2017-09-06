



-- =============================================
-- Author:		Marcos Q. Ramirez
-- Create date: 27-10-2011
-- Description:	Procedure that get lines that
-- will be procedured by MYCTSHotelRobot
-- Author:		José Ricardo Brito Ortega
-- Create date: 11-11-2014
-- Description: Add fields to table DetailsPNRHotel (Description, In_City, Out_City)
-- Author:		Marcos Q. Ramirez
-- Create date: 27-10-2011
-- Description:	Procedure that get lines that
-- will be procedured by MYCTSHotelRobot
-- Author:		José Ricardo Brito Ortega
-- Create date: 01-12-2014
-- Description: Modify Lentght @PNR
-- Author:		Marcos Q. Ramirez
-- Create date: 08-01-2014
-- Description: Add fields to response (pax_profile, pax_mail)
-- =============================================
CREATE Procedure [dbo].[GetPNRHotelLines]
@PNR as varchar(15),
@ORGID int
AS
Begin
	SELECT l.[ID]
      ,l.[Record]
      ,l.[Confirmation_Number]
      ,l.[Hotel]
      ,l.[Provid_Direc_Pay]
      ,l.[DK]
      ,l.[Phone]
      ,l.[RFC]
      ,l.[Mail]
      ,l.[Request]
      ,l.[Payment_form]
      ,l.[Car_Number]
      ,l.[Sales_Source]
      ,l.[Operational_Unit]
      ,l.[User]
      ,l.[Service_Type]
      ,l.[Provider]
      ,l.[Site]
      ,l.[In_Date]
      ,l.[Out_Date]
      ,l.[City]
      ,l.[Room]
      ,l.[Room_Type]
      ,l.[Meal_Plan]
      ,l.[Number_Nights]
      ,l.[Passenger_Name]
      ,l.[Passenger_Number]
      ,l.[Surname]
      ,l.[Title]
      ,l.[Passenger_Type]
      ,l.[Rate]
      ,l.[Currency]
      ,l.[Provider_Commission]
      ,l.[Cost]
      ,l.[Price]
      ,l.[Taxes]
      ,l.[Created_Date]
      ,l.[Time_Limit]
      ,l.[Status]
      ,l.[Cancel_Number]
      ,l.[ChainCode]
      ,l.[ChangeType]
      ,l.[OrgId]
      ,l.[Pcc]
	  ,l.[RemarksString]
      ,l.[UserName]
	  ,l.[Description]
	  ,l.[In_City]
	  ,l.[Out_City]
	  , P.[Level2] as pax_profile
	  , P.[Email] pax_mail
	from dbo.DetailsPNRHotel as l
	left join (SELECT Level2, Email, level1
FROM   (SELECT [Level2],
               [Email],
			   [level1]
	 FROM     ( SELECT FieldName,
					   Value,
					   S.Id
				FROM   [MyCTSProfilesDb].dbo.DetailStars AS Ds
				LEFT JOIN
                       ( SELECT id,
                               FieldKey,
                               [Value]
						FROM   [MyCTSProfilesDb].dbo.Stars
                       )
                       AS S
               ON          Ds.Id = S.FieldKey
       WHERE    [level] = 2
       AND     s.id IN
               ( 
				SELECT id
               FROM    [MyCTSProfilesDb].dbo.Stars               
               )
       ) AS SourceTable  
PIVOT  (  MIN(Value) FOR FieldName IN (
                                       [Level2],
                                       [Email],
									   [level1]
                                      )  
						) AS PivotTable
				) AS tabla) as p
				on p.level2 = l.surname +  '/' + l.passenger_name 
				and p.level1 = l.DK   
	where l.[status] is not null
    and l.[status] <> 0
    and l.[record] is not null    
    and l.[created_date] in (
    select max([created_date])
	from dbo.DetailsPNRHotel
    where [record] = @PNR
    and [OrgId] = @ORGID
    )
    and l.[record] = @PNR
    and l.[OrgId] = @ORGID
End
