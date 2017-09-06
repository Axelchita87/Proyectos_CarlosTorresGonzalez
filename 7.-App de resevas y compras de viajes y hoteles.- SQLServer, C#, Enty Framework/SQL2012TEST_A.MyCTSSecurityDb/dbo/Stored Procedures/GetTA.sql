-- =============================================
-- Author:		Ivan Martinez Guerrero
-- Create date: 28 de Marzo de 2012
-- Description:	Procedure that gets a TA
-- =============================================
CREATE Procedure [dbo].[GetTA]
	@TA as varchar(50)
AS
Begin
	Select [Type], Pcc, TA, Asigned from TACatalog
	where TA=@TA
End

/****** Objeto:  StoredProcedure [dbo].[SetTA]    Fecha de la secuencia de comandos: 05/04/2012 07:16:35 ******/
SET ANSI_NULLS ON
