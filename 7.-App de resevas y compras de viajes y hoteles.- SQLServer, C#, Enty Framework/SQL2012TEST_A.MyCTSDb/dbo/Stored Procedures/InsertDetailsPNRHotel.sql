-- =============================================
-- Author:		guadalupe arzate
-- Create date: 14-06-11
-- Description:	 stored que inserta los datos de hotel
-- Author:      José Ricardo Brito Ortega
-- Create date: 11/11/14
-- Description: Se agregaron campos a la tabla DetailsPNRHHotel para el flujo de autos(Description, In_City, Out_City).
-- Author:      José Ricardo Brito Ortega
-- Create date: 08/01/15
-- Description: se cambio el tipo del campo @Number_Nights a float
-- =============================================
CREATE PROCEDURE [dbo].[InsertDetailsPNRHotel]
@Record varchar(50),
@Confirmation_Number varchar(50),
@Hotel varchar(50),
@Provid_Direc_Pay bit,
@DK varchar(50),
@Phone varchar(50),
@RFC varchar(50),
@Mail varchar(50),
@Request varchar(50),
@Payment_form varchar(50),
@Car_Number int,
@Sales_Source varchar(50),
@Operational_Unit varchar(50),
@User varchar(50),
@Service_Type varchar(50),
@Provider varchar(50),
@Site varchar(50),
@In_Date Datetime,
@Out_Date Datetime,
@City varchar(50),
@Room varchar(50),
@Room_Type varchar(50),
@Meal_Plan varchar(50),
@Number_Nights float,
@Passenger_Name varchar(50),
@Passenger_Number int,
@Surname varchar(50),
@Title varchar(50),
@Passenger_Type varchar(50),
@Rate nvarchar(10),
@Currency varchar(10),
@Provider_Commission float,
@Cost float,
@Price float,
@Taxes float,
@Created_Date datetime,
@Time_Limit datetime,
@Status varchar(50),
@Cancel_Number varchar(50),
@ChainCode varchar(50),
@ChangeType varchar(50),
@OrgId int,
@Pcc varchar(10),
@RemarksString varchar(3000),
@UserName varchar(50),
@GeaErrorMsg varchar(1000),
@Description varchar(max) = null,
@In_City varchar(50) = null,
@Out_City varchar(50) = null
AS
BEGIN

INSERT INTO [dbo].[DetailsPNRHotel] WITH (ROWLOCK) 
           (
		   Record
		   ,Confirmation_Number
		   ,Hotel
		   ,[Provid_Direc_Pay]
           ,[DK]
           ,[Phone]
           ,[RFC]
           ,[Mail]
           ,[Request]
           ,[Payment_form]
           ,[Car_Number]
           ,[Sales_Source]
           ,[Operational_Unit]
           ,[User]
           ,[Service_Type]
           ,[Provider]
           ,[Site]
           ,[In_Date]
           ,[Out_Date]
		   ,[City]
           ,[Room]
           ,[Room_Type]
           ,[Meal_Plan]
           ,[Number_Nights]
           ,[Passenger_Name]
           ,Passenger_Number
           ,[Surname]
           ,[Title]
           ,[Passenger_Type]
           ,[Rate]
           ,[Currency]
           ,[Provider_Commission]
           ,[Cost]
           ,[Price]
           ,Taxes
           ,Created_Date
           ,[Time_Limit]
		   ,[Status]
		   ,Cancel_Number
		   ,ChainCode
		   ,ChangeType
           ,OrgId
           ,Pcc
		   ,RemarksString
           ,UserName
           ,GeaErrorMsg
		   ,[Description]
		   ,In_City
		   ,Out_City
           )						
     VALUES
           (
			@Record,
		    @Confirmation_Number,
		    @Hotel,
			@Provid_Direc_Pay,
			@DK ,
			@Phone ,
			@RFC ,
			@Mail ,
			@Request ,
			@Payment_form ,
			@Car_Number ,
			@Sales_Source ,
			@Operational_Unit ,
			@User ,
			@Service_Type ,
			@Provider ,
			@Site ,
			@In_Date ,
			@Out_Date ,
			@City,
	     	@Room,
			@Room_Type,
			@Meal_Plan,
			@Number_Nights,
			@Passenger_Name,
			@Passenger_Number,
			@Surname,
			@Title,
			@Passenger_Type,
			@Rate,
			@Currency,
			@Provider_Commission,
			@Cost,
			@Price,
			@Taxes,
            @Created_Date,
            @Time_Limit,
            @Status,
            @Cancel_Number,
            @ChainCode,
            @ChangeType,
            @OrgId,
			@Pcc,
			@RemarksString,
            @UserName,
            @GeaErrorMsg,
			@Description,
			@In_City,
			@Out_City
            )
END