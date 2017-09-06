

-- =============================================
-- Author:		<Jessica Gutierrez Becerril>
-- Creation date: 02-06-2010
-- Description:	Update AirLineFare
-- Modify by: */
-- =============================================
create PROCEDURE [dbo].[UpdateAirLineFare] 

@CatAirLinFarId varchar(5), 
@CatAirLinFarName varchar(150),
@CCAut bit,
@CCMan bit,
@Cash bit, 
@PMix bit,
@Misc bit

AS
BEGIN
	update dbo.CatAirLinesFare
	set  CatAirLinFarName=@CatAirLinFarName,
		 CCAut=@CCAut,CCMan=@CCMan,Cash=@Cash,PMix=@PMix,Misc=@Misc
	where CatAirLinFarId=@CatAirLinFarId

END