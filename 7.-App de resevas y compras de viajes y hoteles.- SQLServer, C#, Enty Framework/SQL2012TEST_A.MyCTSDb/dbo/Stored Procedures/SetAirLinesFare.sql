
-- =============================================
-- Author:		<Jessica Gutierrez Becerril>
-- Creation date: <01-06-2010>
-- Description:	<Insert a AirLine in CatAirLinesFare>
-- =============================================
CREATE PROCEDURE [dbo].[SetAirLinesFare] 
	-- Input variables
	@CatAirLinFarId varchar(5), 
	@CatAirLinFarName varchar(150),
	@CCAut bit,
	@CCMan bit,
	@Cash bit, 
	@PMix bit,
	@Misc bit,
	@LogoAirLine image,
	@OPManual bit
	
AS
BEGIN
    -- Insert statements for procedure 
    INSERT INTO dbo.CatAirLinesFare(CatAirLinFarId,CatAirLinFarName,CCAut,CCMan,Cash,PMix,Misc,LogoAirLine,OPManual)
	VALUES(@CatAirLinFarId,@CatAirLinFarName,@CCAut,@CCMan,@Cash,@PMix,@Misc,@LogoAirLine,@OPManual)
END
