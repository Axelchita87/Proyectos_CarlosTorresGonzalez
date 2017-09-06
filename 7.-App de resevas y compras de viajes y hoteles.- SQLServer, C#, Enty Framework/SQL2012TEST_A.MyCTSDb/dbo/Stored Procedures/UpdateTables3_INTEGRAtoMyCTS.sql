-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 26-01-2010
-- Description:	KRAKEN,Master Procedure that update tables values from INTEGRA to MyCTS
--				Tables: Location_Attribute
-- =============================================
CREATE Procedure [dbo].[UpdateTables3_INTEGRAtoMyCTS]
AS
Begin
	Insert into dbo.Location_Attribute(Location,Attribute1,[Status],Status_Site)
	Select LOCATION,ATTRIBUTE1,[STATUS],STATUS_SITE 
	From CORPP..APPS.CTS_CLIENTES_V 
	Where LOCATION NOT IN (SELECT LOCATION From dbo.Location_Attribute)
	Order By Location
End