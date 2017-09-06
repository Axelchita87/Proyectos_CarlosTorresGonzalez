-- =============================================
-- Author:		Ivan Martinez Guerrero
-- Create date: 10 de Abril de 2012
-- Description:	Procedure that updates a Firm
-- =============================================
CREATE Procedure [dbo].[UpdateStatusFirm]
	@Firm as varchar(50)
AS
Begin
	Update	FirmCatalog
	Set Asigned=1
	Where Firm=@Firm
End

/****** Objeto:  StoredProcedure [dbo].[UpdateStatusAgent]    Fecha de la secuencia de comandos: 05/04/2012 07:10:01 ******/
SET ANSI_NULLS ON
