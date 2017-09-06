-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetVolarisStatesALL] 
AS
BEGIN
select CatStaCodCode, CatStaCodDescription from [dbo].[CatStatusCodes]
END