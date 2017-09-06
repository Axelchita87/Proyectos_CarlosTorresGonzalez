
-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 15-05-2009
-- Description:	Procedure that gets a Corporative Airline Agreements
-- =============================================
CREATE Procedure [dbo].[GetClientsAlAgreements]
 @DKToSearch as varchar(10),
 @AirlineID as varchar(5),
 @InternationalFlight as bit
AS
--Declare
	--@DKToSearch varchar(50)
	--Search for IDCorporative that corresponds to @DKToSearch
--	Select @DKToSearch = Attribute1ICAAV--Attribute1 
--	From dbo.QualityControls
--	Where Location_DK = @DKToSearch
	If(	@InternationalFlight = 1)
	Begin
		Select 
			ITCode,
			ITCommand
		From
			dbo.ClientsAlAgreements
		Where ( Attribute1 = @DKToSearch and AirlineID = @AirlineID and (FlightType = 'F' or FlightType = 'A'))
	End
	Else
	Begin
		Select 
			ITCode,
			ITCommand
		From
			dbo.ClientsAlAgreements
		Where ( Attribute1 = @DKToSearch and AirlineID = @AirlineID and (FlightType = 'D' or FlightType = 'A'))
	End

