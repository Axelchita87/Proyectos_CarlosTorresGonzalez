
-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 16-07-2009
-- Description:	Procedure that gets all the corporatives without Quality Controls
-- =============================================
CREATE Procedure [dbo].[GetCorporativesWithoutQC]
AS
Begin
	select IDCorporative as 'Corporativos Faltantes de QC'from dbo.Corporatives
	where IDCorporative not in (select CorporativeID from dbo.QualityControls)
End

