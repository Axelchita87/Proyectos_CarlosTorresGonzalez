


-- =============================================
-- Author:		<Jessica Gutierrez Becerril>
-- Creation date: <01-07-2010>
-- Description:	<Actualiza a QualityControls in dbo.LabelsRemarks 
-- and dbo.QCControlsFeatures>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateQualityControls] 

	@Description varchar(100), 
	@IDCtrl varchar(50),
	@CtrlType varchar(50),
	@CtrlName varchar(50),
	@CtrlDescription varchar(50),
	@CtrlLen int, 
	@CtrlCurrentCriteria varchar(50),
	@CtrlCatalogues varchar(150),
	@AllowInsertValues bit
AS
BEGIN
    -- Insert statements for procedure 
	update  dbo.LabelsRemarks
	set Description=@Description
	where IDRemarkLabel=@IDCtrl

	update dbo.QCControlsFeatures
	set CtrlType=@CtrlType,ReservationCtrlType=@CtrlType,CtrlName=@CtrlName,
	CtrlDescription=@CtrlDescription,CtrlLen=@CtrlLen,CtrlCurrentCriteria=@CtrlCurrentCriteria,
	CtrlCatalogues=@CtrlCatalogues,AllowInsertValues=@AllowInsertValues
	where IDCtrl=@IDCtrl
end
