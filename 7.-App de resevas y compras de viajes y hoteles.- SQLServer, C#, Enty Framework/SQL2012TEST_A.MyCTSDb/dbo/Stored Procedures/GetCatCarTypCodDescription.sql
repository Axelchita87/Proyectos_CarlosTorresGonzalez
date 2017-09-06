-- =============================================
-- Author:		<Angel Trejo Arizmendi>
-- Creation date: 26-03-2010
-- Description:	Get Cat Car Type Code Description
-- Modify by: */
-- =============================================
CREATE PROCEDURE [dbo].[GetCatCarTypCodDescription] 

@Code varchar(4)

AS
BEGIN
	select  CatCarTypCodDescription
	from dbo.CatCarTypesCodes
	where CatCarTypCodCode=@Code 
END