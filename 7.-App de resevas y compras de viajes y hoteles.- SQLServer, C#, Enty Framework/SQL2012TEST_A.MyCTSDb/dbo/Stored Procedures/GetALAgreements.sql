

-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 14-05-2009
-- Description:	Procedure that gets an Agreements-Airline Collection
-- =============================================
create Procedure [dbo].[GetALAgreements]
AS
	Begin
		Select 
			IDAlCode, InternationalComission, DomesticComission, TourCode, OSI
		From
			dbo.AlAgreements
	End

