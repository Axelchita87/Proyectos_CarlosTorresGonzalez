-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SelectALLFromCatServicesExtras 
AS
BEGIN
	Select [NombreServicio],[CodigoServicio]
	from [dbo].[CatServicesExtras]
END
