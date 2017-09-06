
-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 07-07-2009
-- Description:	Procedure that update tables values not duplicated from ICAAV to MyCTS
-- =============================================
CREATE Procedure [dbo].[UpdateTables_ICAAVtoMyCTS]
AS
Begin
	--Adding corporatives not duplicated from ICAAV to MyCTSDb
	insert into MyCTSDb.dbo.Corporatives (IDCorporative,[Name],StatID,Modified)
	select distinct id_corporativo,nombre_corporativo,id_stat,fecha_mod
	from icaavcapa..dba.corporativo 
	where id_Corporativo not in (select IDCorporative from MyCTSDb.dbo.Corporatives)

	--Adding DKs not duplicated from ICAAV to MyCTSDb
	insert into MyCTSDb.dbo.DK (IDDK,CorporativeID,[Name])
	select distinct id_cliente,id_corporativo,nombre_cliente 
	from icaavcapa..dba.clientes 
	where id_cliente not in(select iddk from MyCTSDb.dbo.DK)

	--Adding Origin Sales not duplicated from ICAAV to MyCTSDb
	insert into MyCTSDb.dbo.OriginSales (IDSales,[Description])
	select distinct id_oriven,nombre_oriven 
	from icaavcapa..dba.origen_venta
	where id_oriven not in(select IDSales from MyCTSDb.dbo.OriginSales)

	--Adding ChargePerService not duplicated from ICAAV to MyCTSDb
	insert into MyCTSDb.dbo.ChargePerService (IDChargePerService,Import,IDPaymentForm)
	select distinct id_referencia,(importe*1.15) as importe,id_forma_pago 
	from icaavcapa..dba.gds_cxs
	where id_referencia not in(select IDChargePerService from MyCTSDb.dbo.ChargePerService)

	--Adding Operative Units not duplicated from ICAAV to MyCTSDb
--	insert into MyCTSDb.dbo.OperativeUnits (OUName,OUDescription,OUST,OUCreated)
--	select distinct id_unidad_negocio,desc_unidad_negocio,id_stat,fecha_mod 
--	from icaavcapa..dba.unidad_negocio
--	where id_unidad_negocio not in(select OUName from MyCTSDb.dbo.OperativeUnits)

End

