
-- =============================================================
-- Autor:         Eduardo Vázquez Orozco
-- Fecha creacion: 27/05/2013
-- Modifico:      Jessica Gutierrez
-- Fecha modificacion:  07/06/13
-- Descripcion:  SP que obtiene todos los campos de la tabla,
--				 ToolOnlineLog
-- =============================================================

CREATE PROCEDURE [dbo].[Get_ToolOnlineRules]
@attribute varchar(6)
AS
BEGIN

select [Corporative],[ToolOnline],[Attribute1],[Supervisor],[SupAgent],[SupPCC], [SupStatus],[Consultor1],
[ConAgent1],[ConPCC1],[ConStatus1],[CountConsul1], [Consultor2],[ConAgent2], [ConPCC2], [ConStatus2],[CountConsul2], 
[Consultor3],[ConAgent3], [ConPCC3] ,[ConStatus3],[CountConsul3], [Consultor4],[ConAgent4],[ConPCC4], [ConStatus4],[CountConsul4], 
[Consultor5],[ConAgent5],[ConPCC5],[ConStatus5],[CountConsul5],[FechaInsert],[InsertBy],
[FechaUpdate],[UpdateBy]
from [dbo].[ToolOnlineRules]
where [Attribute1]=@attribute
end