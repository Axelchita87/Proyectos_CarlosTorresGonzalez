
-- =============================================================
-- Autor:         Jessica Gutierrez
-- Fecha creacion: 27/05/2013
-- Modifico:      ----
-- Fecha modificacion:  15/06/13
-- Descripcion:  SP que obtiene todos los campos de la tabla [dbo].[Users]
--				 
-- =============================================================

create PROCEDURE [dbo].[Get_Email]
@Firm as nvarchar(50),
@PCC as nvarchar(50)
AS
Begin
 SELECT UserMail
 FROM [dbo].[Users]
 WHERE [Firm]=@Firm and [PCC]=@PCC
End