



-- =============================================
-- Author:		<Jessica Gutierrez Becerril>
-- Creation date: <08-06-2010>
-- Description:	<Insert a AirLine in CatAirLinesFare>
-- =============================================
create PROCEDURE [dbo].[SetAirLineAgreements] 
	-- Input variables
	@IDAlCode varchar(5), 
	@InternationalComission varchar(2),
	@DomesticComission varchar(2),
	@TourCode varchar(100),
	@OSI varchar(100)
AS
BEGIN
    -- Insert statements for procedure 
    INSERT INTO dbo.AlAgreements(IDAlCode,InternationalComission,DomesticComission,TourCode,OSI)
	VALUES(@IDAlCode,@InternationalComission,@DomesticComission,@TourCode,@OSI)
END