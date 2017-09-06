-- =============================================
-- Author:		Ivan Martinez Guerrero
-- Create date: 6 de Abril de 2012
-- Description:	Procedure that gets a Queue not asigned
-- =============================================
CREATE Procedure [dbo].[AssignQueueFirm]
@NewQueue as varchar (6),
@Agent as varchar (2),
@Pcc as varchar (4)
AS
Begin
	Update Users
	Set [Queue]=@NewQueue
	Where Agent=@Agent and Pcc=@Pcc
End

/****** Objeto:  StoredProcedure [dbo].[DeleteIATA]    Fecha de la secuencia de comandos: 05/04/2012 07:18:26 ******/
SET ANSI_NULLS ON
