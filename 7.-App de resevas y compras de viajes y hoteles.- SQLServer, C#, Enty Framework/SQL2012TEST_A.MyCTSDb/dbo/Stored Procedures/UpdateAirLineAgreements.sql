

-- =============================================
-- Author:		<Jessica Gutierrez Becerril>
-- Creation date: 09-06-2010
-- Description:	Update PCC
-- Modify by: */
-- =============================================
create PROCEDURE [dbo].[UpdateAirLineAgreements] 
@IDAlCode varchar(5),
@InternationalComission varchar(2),
@DomesticComission varchar(2),
@TourCode varchar(100),
@OSI varchar(100)


AS
BEGIN
	update  dbo.AlAgreements
	set IDAlCode=@IDAlCode,InternationalComission=@InternationalComission,
		DomesticComission=@DomesticComission,TourCode=@TourCode,OSI=@OSI
	where IDAlCode=@IDAlCode
END