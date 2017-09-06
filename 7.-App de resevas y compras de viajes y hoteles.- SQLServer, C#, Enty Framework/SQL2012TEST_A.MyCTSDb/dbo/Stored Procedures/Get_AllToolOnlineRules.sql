
-- =============================================================
-- Autor:         Jessica Gutierrez
-- Fecha creacion: 27/05/2013
-- Modifico:      
-- Fecha modificacion:  
-- Descripcion:  SP que obtiene todos los campos de la tabla,
--				 ToolOnlineLog
-- =============================================================

CREATE PROCEDURE [dbo].[Get_AllToolOnlineRules]
AS
BEGIN

select [Corporative],[ToolOnline],[Attribute1],[Supervisor],[SupAgent],[SupPCC], [SupStatus],[Consultor1],
[ConAgent1],[ConPCC1],[ConStatus1],[Consultor2],[ConAgent2], [ConPCC2], [ConStatus2],[Consultor3],
[ConAgent3], [ConPCC3] ,[ConStatus3],[Consultor4],[ConAgent4],[ConPCC4], [ConStatus4],
[Consultor5],[ConAgent5],[ConPCC5],[ConStatus5],[FechaInsert],[InsertBy],
[FechaUpdate],[UpdateBy]
from [dbo].[ToolOnlineRules]
end