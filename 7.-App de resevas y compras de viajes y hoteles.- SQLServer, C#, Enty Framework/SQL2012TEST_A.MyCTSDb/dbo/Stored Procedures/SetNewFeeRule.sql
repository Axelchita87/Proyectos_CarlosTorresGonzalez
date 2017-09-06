-- =============================================
-- Author:		<Angel Trejo Arizmendi>
-- Creation date: 18-02-2010
-- Description:	Insert a New Fee Rule in 
-- Modify by: */
-- =============================================
CREATE PROCEDURE [dbo].[SetNewFeeRule] 

@Attribute1 varchar(10),
@Priority int,
@Description varchar(20),
@ExtendedDescription varchar(100),
@DefaultFee decimal(18,0),
@DefaultMount money,
@Mandatory bit,
@ActivationState bit,
@StartDate datetime,
@ExpirationDate datetime,
@CreatedByAgent varchar(2)
AS
BEGIN
	INSERT INTO [dbo].[CorporativeFeesRules]
           ([Attribute1]
           ,[Priority]
           ,[Description]
           ,[ExtendedDescription]
           ,[DefaultFee]
           ,[DefaultMount]
           ,[Mandatory]
           ,[ActivationState]
           ,[StartDate]
           ,[ExpirationDate]
		   ,[CreatedByAgent])
     VALUES
           (@Attribute1,
			@Priority,
			@Description,
			@ExtendedDescription,
			@DefaultFee,
			@DefaultMount,
			@Mandatory,
			@ActivationState,
			@StartDate,
			@ExpirationDate,
            @CreatedByAgent)
	SELECT max (RuleNumber) as IDRuleNumber
	from [dbo].[CorporativeFeesRules]
	
		
END
