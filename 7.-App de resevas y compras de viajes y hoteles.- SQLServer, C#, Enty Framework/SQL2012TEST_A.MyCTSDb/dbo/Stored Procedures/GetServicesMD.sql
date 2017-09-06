-- =============================================
-- Author:		Jessica Gutierrez
-- Create date: 06/03/2015
-- Description:	Extraer los servicios para EM
-- =============================================
CREATE PROCEDURE [dbo].[GetServicesMD]

AS
BEGIN
	Select [Service]
	from [dbo].[CatServicesMD]
END
