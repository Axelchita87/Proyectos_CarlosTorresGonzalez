-- =============================================
-- Author:		<Angel Trejo Arizmendi>
-- Creation date: 18-02-2010
-- Description:	Insert a LocationDK that not accepted 
-- Modify by: */
-- =============================================
CREATE PROCEDURE [dbo].[SetLocationDKNotAccepted] 

@RuleNumber as int,
@LocationDK as varchar(6)

AS
BEGIN
if(@LocationDK is not null)
	begin
		INSERT INTO [dbo].[RuleNumberNotEnableForLocation]
				([RuleNumber]
				,[LocationDK])

		VALUES
				(@RuleNumber,
				 @LocationDK)
		select @LocationDK as LocationDK
	end
else
	begin
		select LocationDK
		from [dbo].[RuleNumberNotEnableForLocation]
		where RuleNumber=@RuleNumber
		order by LocationDK
	end 
		
END