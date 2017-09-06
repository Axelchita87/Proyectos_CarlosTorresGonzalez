-- =============================================
-- Author:	Jessica Gutierrez
-- Create date: 23/08/13
-- Description:	Extrae los Estados de Volaris
-- =============================================
CREATE PROCEDURE GetVolarisCatStates 
AS
BEGIN
	Select Code, Name from [dbo].[VolarisCatStates]
END
