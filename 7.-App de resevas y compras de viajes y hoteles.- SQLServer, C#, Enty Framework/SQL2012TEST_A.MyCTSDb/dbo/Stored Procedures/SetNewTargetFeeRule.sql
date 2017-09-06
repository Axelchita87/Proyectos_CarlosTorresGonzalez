-- =============================================
-- Author:		<Angel Trejo Arizmendi>
-- Creation date: 19-02-2010
-- Description:	Insert a New Target Element Rule
-- Modify by: */
-- =============================================
CREATE PROCEDURE [dbo].[SetNewTargetFeeRule] 

@RuleNumber int,
@IDTE int,
@Value2 varchar (50)

AS
BEGIN
	INSERT INTO [dbo].[TargetElementsRules]
           ([RuleNumber]
           ,[IDTE]
           ,[Value])
     VALUES
           (@RuleNumber,
            @IDTE,
            @Value2)
END