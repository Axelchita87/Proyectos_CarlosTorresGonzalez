-- =============================================
-- Author:		Jessica Gutierrez
-- Create date: 21/06/2013
-- Description:	Extraer solo el atributo1 
-- ===========================================_==
CREATE PROCEDURE [dbo].[GetOnlyAttributte1_DK]
@Attribute1 as varchar(50)
AS
BEGIN
	Select Attribute1
	from [dbo].[Location_Attribute]
	where [Location]=@Attribute1
END