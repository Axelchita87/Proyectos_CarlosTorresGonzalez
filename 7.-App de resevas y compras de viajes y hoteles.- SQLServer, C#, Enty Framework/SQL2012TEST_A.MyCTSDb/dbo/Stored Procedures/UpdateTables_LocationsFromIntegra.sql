-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 25-03-2010
-- Description:	Procedure that updates the MyCTSDb.dbo.Location_Attribute table from INTEGRA
-- =============================================
CREATE Procedure [dbo].[UpdateTables_LocationsFromIntegra]
As
begin
	insert into dbo.Location_Attribute([Location],[Attribute1],[Status],[Status_Site])
	select LOCATION,ATTRIBUTE1,[STATUS],STATUS_SITE 
	from CORPP..APPS.CTS_CLIENTES_V 
	where ATTRIBUTE1 is not null and 
	([status]='A' or [status_site]='A') and
	LOCATION not in
	(
		select location 
		from dbo.Location_Attribute
		where [status]='A' or [status_site]='A'
	)
end
