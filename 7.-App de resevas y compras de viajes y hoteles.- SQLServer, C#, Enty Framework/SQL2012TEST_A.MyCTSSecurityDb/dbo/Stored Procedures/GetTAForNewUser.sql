-- =============================================
-- Author:		Ivan Martinez Guerrero
-- Create date: 6 de Abril de 2012
-- Description:	Procedure that gets a TA not asigned
-- =============================================
CREATE Procedure [dbo].[GetTAForNewUser]
@Pcc as varchar(10)
AS
Begin
	Select Top(1) * From TACatalog
	Where asigned=0 and [Type]='CRT' and Pcc=@Pcc
End

/****** Objeto:  StoredProcedure [dbo].[InsertIATA]    Fecha de la secuencia de comandos: 05/04/2012 07:13:17 ******/
SET ANSI_NULLS ON
