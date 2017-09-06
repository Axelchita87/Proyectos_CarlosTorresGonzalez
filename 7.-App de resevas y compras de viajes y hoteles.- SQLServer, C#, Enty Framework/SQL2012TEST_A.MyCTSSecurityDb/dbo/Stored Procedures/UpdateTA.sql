-- =============================================
-- Author:		Ivan Martinez Guerrero
-- Create date: 22 de Marzo de 2012
-- Description:	Procedure that updates a TA in TACatalog
-- =============================================
CREATE Procedure [dbo].[UpdateTA]
	@Type as varchar(50),
	@Pcc as varchar(50),
	@TA as varchar(50)
AS
Begin
	Update	TACatalog
	Set [Type]=@Type,Pcc= @PCC
	Where TA=@TA
End

/****** Objeto:  StoredProcedure [dbo].[UpdateIATA]    Fecha de la secuencia de comandos: 05/04/2012 07:11:03 ******/
SET ANSI_NULLS ON
