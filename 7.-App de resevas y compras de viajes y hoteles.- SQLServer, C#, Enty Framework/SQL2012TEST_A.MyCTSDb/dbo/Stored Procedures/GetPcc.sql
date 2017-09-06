CREATE Procedure [dbo].[GetPcc]
 @Pcc as varchar(6)
AS

Begin
	Select CatPccId,CatPccName,ApplicationId,[Type],Tool,GDS
	from dbo.CatPccs
	Where CatPccId = @Pcc
End

/****** Objeto:  StoredProcedure [dbo].[InsertPcc]    Fecha de la secuencia de comandos: 05/02/2012 18:18:13 ******/
SET ANSI_NULLS ON
