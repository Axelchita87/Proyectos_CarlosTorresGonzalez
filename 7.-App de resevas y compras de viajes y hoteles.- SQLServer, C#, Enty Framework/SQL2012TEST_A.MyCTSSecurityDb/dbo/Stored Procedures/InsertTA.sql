-- =============================================
-- Author:		Ivan Martinez Guerrero
-- Create date: 22 de Marzo de 2012
-- Description:	Procedure that inserts a TA in TACatalog
-- =============================================
CREATE Procedure [dbo].[InsertTA]
	@Type as varchar(50),
	@Pcc as varchar(50),
	@TA as varchar(50)
AS
Begin
	Insert Into	TACatalog([Type], Pcc, TA, Asigned)
	Values(@Type, @PCC, @TA, 0)
End

/****** Objeto:  StoredProcedure [dbo].[SetTA]    Fecha de la secuencia de comandos: 05/04/2012 07:13:12 ******/
SET ANSI_NULLS ON
