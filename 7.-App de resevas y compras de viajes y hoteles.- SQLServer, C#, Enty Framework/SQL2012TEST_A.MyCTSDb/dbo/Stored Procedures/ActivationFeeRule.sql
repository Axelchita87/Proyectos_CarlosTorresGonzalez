-- =============================================
-- Author:		<Angel Trejo Arizmendi>
-- Creation date: 12-03-2010
-- Description:	Activation Fee Rule 
-- Modify by: */
-- =============================================
CREATE PROCEDURE [dbo].[ActivationFeeRule] 

@RuleNumber int

AS
BEGIN
	update dbo.CorporativeFeesRules
	set ActivationState = 1
	where RuleNumber = @RuleNumber
END