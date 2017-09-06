-- =============================================
-- Author:		<Angel Trejo Arizmendi>
-- Creation date: 04-03-2010
-- Description:	Update Priority by Attribute1
-- Modify by: */
-- =============================================
CREATE PROCEDURE [dbo].[UpdatePriorityByAttribute1] 

@NewPriority int,
@Attribute1 varchar (6)

AS
BEGIN
	update dbo.CorporativeFeesRules
	set Priority=Priority +1
	where Attribute1=@Attribute1 and Priority>=@NewPriority

END