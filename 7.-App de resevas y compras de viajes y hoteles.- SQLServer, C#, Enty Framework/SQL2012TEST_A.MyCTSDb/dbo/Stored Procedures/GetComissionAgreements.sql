
-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 22-05-2009
-- Description:	Procedure that gets a Comission-Agreements Record
-- =============================================
CREATE Procedure [dbo].[GetComissionAgreements]
 @DKToSearch as varchar(50),
 @AirlineID as varchar(5),
 @InternationalFlight as bit,
 @ClassType as varchar(1)
AS
Declare
	--@DKToSearch varchar(50),
	@ITCode varchar(100),
	@ITCommand varchar(10)
	
	--Search for IDCorporative that corresponds to @DKToSearch
--	Select @DKToSearch = Attribute1ICAAV--Attribute1 
--	From dbo.QualityControls
--	Where Location_DK = @DKToSearch

	--For International Flights
	If(	@InternationalFlight = 1)
	Begin
		--Looking for Client Agreements
		Select @ITCode=CAA.ITCode, @ITCommand=CAA.ITCommand
		From dbo.ClientsAlAgreements CAA
		Where ( CAA.Attribute1 = @DKToSearch and CAA.AirlineID = @AirlineID and (FlightType = 'F' or FlightType = 'A'))
		--if there are not client agreements, start looking for CTS agreements
		if(cast(isnull(@ITCode,1) as varchar(50))='1' and cast(isnull(@ITCommand,1) as varchar(50))='1')
		Begin
			Select @ITCode=CTSAA.ITCode, @ITCommand=CTSAA.ITCommand
			From dbo.CTSAlAgreements CTSAA
			Where ( CTSAA.AirlineID = @AirlineID and ClassType = @ClassType and (FlightType = 'F' or FlightType = 'A') )
		End
	--Building the Comission-Agreements Query
	Select 
		AA.InternationalComission,
		AA.TourCode,
		AA.OSI,
		@ITCode as ITCode,
		@ITCommand as ITCommand
	From 
		dbo.AlAgreements AA
	Where 
		AA.IDAlCode = @AirlineID
	End

	--For Domestic Flights
	Else If(@InternationalFlight = 0)
	Begin
		--Looking for Client Agreements
		Select @ITCode=CAA.ITCode, @ITCommand=CAA.ITCommand
		From dbo.ClientsAlAgreements CAA
		Where ( CAA.Attribute1 = @DKToSearch and CAA.AirlineID = @AirlineID and (FlightType = 'D' or FlightType = 'A'))
		--if there are not client agreements, start looking for CTS agreements
		if(cast(isnull(@ITCode,1) as varchar(50))='1' and cast(isnull(@ITCommand,1) as varchar(50))='1')
		Begin
			Select @ITCode=CTSAA.ITCode, @ITCommand=CTSAA.ITCommand
			From dbo.CTSAlAgreements CTSAA
			Where ( CTSAA.AirlineID = @AirlineID and ClassType = @ClassType and (FlightType = 'D' or FlightType = 'A') )
		End
	--Building the Comission-Agreements Query
	Select 
		AA.DomesticComission,
		AA.TourCode,
		AA.OSI,
		@ITCode as ITCode,
		@ITCommand as ITCommand
	From 
		dbo.AlAgreements AA
	Where 
		AA.IDAlCode = @AirlineID
	End
	

