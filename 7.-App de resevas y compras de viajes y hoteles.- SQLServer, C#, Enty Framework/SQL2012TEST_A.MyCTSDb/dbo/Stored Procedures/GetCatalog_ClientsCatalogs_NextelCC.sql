-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: Sep-2009
-- =============================================
create Procedure [dbo].[GetCatalog_ClientsCatalogs_NextelCC]
 AS 
Begin
select Code [Value], 
(Code+' '+Upper(DescriptionCode)) [Text],
 Upper(DescriptionCode) [Text2], '' [Text3]
FROM
(
Select Distinct rtrim(CorporativeID) CorporativeID,rtrim(RemarkLabelID) RemarkLabelID, rtrim(Code) Code, rtrim(DescriptionCode) DescriptionCode
		From dbo.ClientsCatalogs
		WHERE CorporativeID='Nextel' and RemarkLabelID='C3'
)AS ClientsCatalogs
End



