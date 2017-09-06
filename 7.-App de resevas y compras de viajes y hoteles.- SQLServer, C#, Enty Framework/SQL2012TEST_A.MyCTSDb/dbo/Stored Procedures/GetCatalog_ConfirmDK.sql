-- =============================================
-- Author:		Denisse Cestelos R.
-- Modify:		Denisse Cestelos R.
-- Create date: 26 de abril de 2013
-- Modify date: 26 de abril de 2013
-- Description:	agrega un nuevo usuario y asigna rol
-- =============================================
CREATE PROCEDURE GetCatalog_ConfirmDK
	
AS
BEGIN
	SET NOCOUNT ON;
	select 
		[IDDK] [Value], 
		([IDDK] + ' ' + [Name]) [Text],
		[Name] [Text2],
		'' [Text3],
		'' [Text5],
		'' [Text6],
		'' [Text7],
		'' [Text8]
	from 
	(
		Select Distinct 
			rtrim([IDDK]) [IDDK], 
			rtrim([Name]) [Name]
		From dbo.DK
	) 
	as 
		DK
END
-- =============================================
-- EXEC GetCatalog_ConfirmDK '','','','','','','','','','','','',''
-- =============================================
