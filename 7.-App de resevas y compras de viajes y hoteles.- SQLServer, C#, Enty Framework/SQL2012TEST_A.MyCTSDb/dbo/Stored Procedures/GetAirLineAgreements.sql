-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 14-05-2009
-- Description:	Procedure that gets an Agreements-Airline Collection
-- =============================================
CREATE Procedure [dbo].[GetAirLineAgreements]
	@AlCodeToSearch as varchar(10)
AS
	Begin
		Select 
			IDAlCode, InternationalComission, DomesticComission, TourCode, OSI
		From
			dbo.AlAgreements
		Where ( IDAlCode = @AlCodeToSearch )
	End



