-- =============================================
-- Author:		Ivan Martinez Guerrero
-- Create date: 6 de Abril de 2012
-- Description:	Procedure that deletes a TA in TACatalog
-- =============================================
CREATE Procedure [dbo].[DeleteTA]
	@TA as varchar(50)
AS
Begin
	Delete From	TACatalog
	Where TA=@TA
End

/****** Objeto:  StoredProcedure [dbo].[GetIATA]    Fecha de la secuencia de comandos: 05/04/2012 07:18:06 ******/
SET ANSI_NULLS ON
