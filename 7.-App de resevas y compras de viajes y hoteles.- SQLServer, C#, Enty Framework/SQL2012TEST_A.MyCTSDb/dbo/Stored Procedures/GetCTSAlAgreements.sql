-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 15-05-2009
-- Description:	Procedure that gets the CTS Airline Agreements
-- =============================================
CREATE Procedure [dbo].[GetCTSAlAgreements]
	@AirlineID as varchar(5),
	@ClassType as varchar(1),
	@InternationalFlight as bit
AS
	If(	@InternationalFlight = 1)
	Begin
		Select 
			ITCode,
			ITCommand
		From
			dbo.CTSAlAgreements
		Where ( AirlineID = @AirlineID and ClassType = @ClassType and (FlightType = 'F' or FlightType = 'A') )
	End
	Else
	Begin
		Select 
			ITCode,
			ITCommand
		From
			dbo.CTSAlAgreements
		Where ( AirlineID = @AirlineID and ClassType = @ClassType and (FlightType = 'D' or FlightType = 'A') )
	End
