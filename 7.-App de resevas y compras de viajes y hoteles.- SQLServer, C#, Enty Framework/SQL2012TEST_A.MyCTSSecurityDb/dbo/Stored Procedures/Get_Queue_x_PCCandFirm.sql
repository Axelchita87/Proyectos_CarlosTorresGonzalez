
-- =============================================================
-- Autor:         Jessica Gutierrez
-- Fecha creacion: 27/05/2013
-- Modifico:      ----
-- Fecha modificacion:  17/06/13
-- Descripcion:  SP que obtiene todos los campos de la tabla [dbo].[Users]
--				 
-- =============================================================

CREATE PROCEDURE [dbo].[Get_Queue_x_PCCandFirm]
@Firm as nvarchar(50),
@PCC as nvarchar(50)
AS
Begin
 SELECT [Queue],UserMail
 FROM [dbo].[Users]
 WHERE [Firm]=@Firm and [PCC]=@PCC
End