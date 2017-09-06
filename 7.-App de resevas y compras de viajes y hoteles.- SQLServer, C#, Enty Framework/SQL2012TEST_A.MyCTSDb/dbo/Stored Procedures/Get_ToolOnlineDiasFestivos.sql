-- =============================================
-- Author:		Jessica Gutierrez
-- Create date: 05/07/13
-- Description:	Extrae los Dias Festivos
-- =============================================
CREATE PROCEDURE Get_ToolOnlineDiasFestivos
AS
BEGIN
	Select [Fecha],[TipoFestivo],[Horario]
	from [dbo].[ToolOnlineDiasFestivos]

END
