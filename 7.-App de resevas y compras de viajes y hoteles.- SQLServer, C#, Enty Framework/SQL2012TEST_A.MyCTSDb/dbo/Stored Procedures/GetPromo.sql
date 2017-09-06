

-- =============================================
-- Author:		Ivan Martínez Guerrero
-- Create date: 09-08-2011
-- Description:	Procedure that gets a DHL collection
-- =============================================
CREATE Procedure [dbo].[GetPromo]
@Airline as varchar(10),
@TypeCard as varchar(10),
@Bank as varchar (20)
AS
Begin
	SELECT  Airline, TypeCard, EmissionBank, DatePromoBegin,DatePromoEnd, MonthsWithInterest, 
	MonthsWithoutInterest, Description, Amount, Origen, Destination, OrigenZone, DestinationZone,
	CountryEmission, SharedFlight, IncludedClasses, ExcludedClasses, ApplyDatePromoFlight
	FROM dbo.AllPromoFOP
	WHERE Airline=@Airline and TypeCard=@TypeCard and EmissionBank=@Bank
 End

