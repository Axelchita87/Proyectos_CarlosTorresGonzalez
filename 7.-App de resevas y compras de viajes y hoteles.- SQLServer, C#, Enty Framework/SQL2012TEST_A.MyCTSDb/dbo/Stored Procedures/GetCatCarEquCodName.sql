-- =============================================
-- Author:		<Angel Trejo Arizmendi>
-- Creation date: 26-03-2010
-- Description:	Get Car Equip Code Name
-- Modify by: */
-- =============================================
CREATE PROCEDURE [dbo].[GetCatCarEquCodName] 

@Code varchar(3)

AS
BEGIN
	select CatCarEquCodName 
	from dbo.CatCarEquipmentCodes
	where CatCarEquCodCode=@Code 
END