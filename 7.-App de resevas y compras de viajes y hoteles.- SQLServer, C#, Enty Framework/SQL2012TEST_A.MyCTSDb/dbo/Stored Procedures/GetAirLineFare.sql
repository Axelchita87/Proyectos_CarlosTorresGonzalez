

-- =============================================
-- Author:		Jessica Gutierrez Becerril
-- Create date: 01-06-2010
-- Description:	Procedure that gets an AirLine
-- =============================================
CREATE Procedure [dbo].[GetAirLineFare]
 @StrToSearch as varchar(10)
AS
Begin
		Select Distinct CatAirLinFarId, CatAirLinFarName,CCAut,CCMan,Cash,PMix,Misc,OpManual
		From  dbo.CatAirLinesFare
		Where CatAirLinFarId = @StrToSearch 
End
