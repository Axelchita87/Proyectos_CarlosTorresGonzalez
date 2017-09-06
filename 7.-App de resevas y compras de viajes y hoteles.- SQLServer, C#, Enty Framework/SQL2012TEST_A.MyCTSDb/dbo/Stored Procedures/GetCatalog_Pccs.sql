-- =============================================
-- Author:		Denisse Cestelos R.
-- Modify:		Denisse Cestelos R.
-- Create date: 26 de abril de 2013
-- Modify date: 26 de abril de 2013
-- Description:	agrega un nuevo usuario y asigna rol
-- =============================================
CREATE PROCEDURE GetCatalog_Pccs
	
AS
BEGIN
	SET NOCOUNT ON;
	
	select
		CatPccId [Value], 
		(CatPccId + ' ' + CatPccName) [Text],
		CatPccName [Text2],
		cast(OrgId as nvarchar) [Text3],
		Type [Text5], 
		Tool [Text6], 
		GDS [Text7], 
		Status [Text8]
	from 
	(
		Select Distinct 
			rtrim(CatPccId) CatPccId,
			A.OrgId OrgId, 
			rtrim(CatPccName) CatPccName,
			P.Type, 
			P.Tool, 
			P.GDS, 
			P.Status
	From 
		dbo.CatPccs P
		inner join 
			MyCTSSecurityDb.dbo.Applications A 
		on 
			A.ApplicationId=P.ApplicationId
	)
	as
		Pccs
END
-- =============================================
-- EXEC GetCatalog_Pccs '','','','','','','','','','','','',''
-- =============================================
