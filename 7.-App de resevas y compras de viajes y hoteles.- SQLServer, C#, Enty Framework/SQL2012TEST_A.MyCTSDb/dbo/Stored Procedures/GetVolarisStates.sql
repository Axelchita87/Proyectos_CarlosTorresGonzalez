-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetVolarisStates] 
 @countryId varchar(15)
AS
BEGIN
select * from [dbo].[CatCities] where CatCitCouId =@countryId
END