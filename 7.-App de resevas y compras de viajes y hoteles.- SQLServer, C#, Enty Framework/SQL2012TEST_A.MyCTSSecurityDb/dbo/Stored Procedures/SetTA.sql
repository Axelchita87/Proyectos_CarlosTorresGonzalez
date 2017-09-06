-- =============================================
-- Author:		Ivan Martínez Guerrero
-- Create date: Today
-- Description:	Procedure that sets the value in the TA column
-- =============================================
CREATE PROCEDURE [dbo].[SetTA]
	@firm varchar,
	@ta varchar(6)
AS
BEGIN
	Update dbo.Users 
	Set  [TA]=@ta
	Where [Firm] = @firm
END

/****** Objeto:  StoredProcedure [dbo].[GetAgentForNewUser]    Fecha de la secuencia de comandos: 05/04/2012 07:16:26 ******/
SET ANSI_NULLS ON
