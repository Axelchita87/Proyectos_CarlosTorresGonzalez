

-- =============================================
-- Author:		<Angel Trejo Arizmendi>
-- Creation date: 02-03-2010
-- Description:	Get all information about fee rules by Attribute1
-- Modify by: */
-- =============================================
CREATE PROCEDURE [dbo].[GetInfoFeeRuleByAttribute1] 
@Attribute1 as varchar(6),
@RuleNumber as int,
@OrgId as int
AS
BEGIN
	select @Attribute1=C.Attribute1
	from dbo.CorporativeFeesRules C
	inner join dbo.Attributes A on C.Attribute1=A.Attribute1
	where RuleNumber=@RuleNumber and OrgId=@OrgId
	select *
	from dbo.CorporativeFeesRules
	where Attribute1=@Attribute1
	order by Priority
END