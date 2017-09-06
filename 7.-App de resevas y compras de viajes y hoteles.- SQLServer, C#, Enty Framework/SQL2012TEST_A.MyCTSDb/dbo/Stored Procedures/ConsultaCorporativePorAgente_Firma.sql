-- =============================================
-- Author:		Jessica Gutierrez
-- Create date: 11/06/13
-- Description:	Extraer Información de [dbo].[ToolOnlineRules] pero solo por agente firmado
-- =============================================
CREATE PROCEDURE [dbo].[ConsultaCorporativePorAgente_Firma]
@Firm int
AS
BEGIN
Select [Corporative],[ToolOnline],[Attribute1],[Supervisor],[SupAgent],[SupPCC], [SupStatus],[Consultor1],
[ConAgent1],[ConPCC1],[ConStatus1],[Consultor2],[ConAgent2], [ConPCC2], [ConStatus2],[Consultor3],
[ConAgent3], [ConPCC3] ,[ConStatus3],[Consultor4],[ConAgent4],[ConPCC4], [ConStatus4],
[Consultor5],[ConAgent5],[ConPCC5],[ConStatus5],[FechaInsert],[InsertBy],
[FechaUpdate],[UpdateBy]
from [dbo].[ToolOnlineRules]
where [SupAgent]=@Firm 
END