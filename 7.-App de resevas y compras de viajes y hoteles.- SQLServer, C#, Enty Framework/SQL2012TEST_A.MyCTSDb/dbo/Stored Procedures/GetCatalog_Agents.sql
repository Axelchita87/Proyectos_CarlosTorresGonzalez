
-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 23-03-2010
-- =============================================
CREATE Procedure [dbo].[GetCatalog_Agents]
 AS 
Begin

select Agent [Value], 
	(Agent + ' ' + FamilyName) [Text],
 FamilyName [Text2],cast(OrgId as nvarchar) [Text3],'' [Text5],'' [Text6],'' [Text7],'' [Text8]
from 
(
	select Distinct rtrim(u.Agent) Agent,
	rtrim(u.FamilyName) FamilyName
	,app.OrgId OrgId
	 from MyCTSSecurityDb.dbo.Users u
	inner join   [MyCTSDb].[dbo].[CatPccs] catpcc
	on u.PCC = catpcc.[CatPccId]
	inner join MyCTSSecurityDb.dbo.Applications app
	on catpcc.ApplicationId = app.ApplicationId
) as Agents
order by Agent
	
	--select Agent [Value], 
	--(Agent + ' ' + FamilyName) [Text],
	-- FamilyName [Text2],'hola' [Text3] 
	--from 
	--(
	--	select Distinct rtrim(Agent) Agent,rtrim(FamilyName) FamilyName
	--	from MyCTSSecurityDb.dbo.Users
	--) as Agents
	--order by Agent
End


