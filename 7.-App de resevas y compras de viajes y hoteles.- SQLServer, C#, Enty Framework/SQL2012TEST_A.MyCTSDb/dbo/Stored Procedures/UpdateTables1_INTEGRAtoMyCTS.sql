-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 07-01-2009
-- Description:	Procedure that update tables values not duplicated from INTEGRA to MyCTS
--				Tables: OriginSales, OperativeUnits
-- =============================================
CREATE Procedure [dbo].[UpdateTables1_INTEGRAtoMyCTS]
AS
Begin
	--exec sp_tables_ex @table_server = 'CORPP', @table_schema='APPS'
	--UPDATING ORIGINSALES--
	INSERT INTO MYCTSDB.DBO.ORIGINSALES(IDSALES,DESCRIPTION)
	SELECT GEA.IDSALES,GEA.DESCRIPTION FROM GEAP..GEA.CTS_TB_ORIGINSALES GEA
	WHERE GEA.IDSALES NOT IN
	(SELECT IDSALES FROM MYCTSDB.DBO.ORIGINSALES)

	--UPDATING OPERATIVEUNITS--
	INSERT INTO MYCTSDB.DBO.OPERATIVEUNITS(ID,CCI,OUNAME)
	SELECT GEA.ID,GEA.CCI,GEA.OUNAME FROM GEAP..GEA.CTS_TB_OPERATIVEUNITS GEA
	WHERE GEA.CCI NOT IN
	(SELECT CCI FROM MYCTSDB.DBO.OPERATIVEUNITS)
End


