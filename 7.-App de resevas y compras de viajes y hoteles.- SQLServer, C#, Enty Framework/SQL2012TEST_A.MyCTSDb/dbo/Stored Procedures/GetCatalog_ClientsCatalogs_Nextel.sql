-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: Sep-2009
-- =============================================
CREATE Procedure [dbo].[GetCatalog_ClientsCatalogs_Nextel]
 AS 
Begin
select Code [Value], 
(Code+' '+DescriptionCode) [Text],
 DescriptionCode [Text2], '' [Text3]
FROM
(
Select Distinct rtrim(CorporativeID) CorporativeID,rtrim(RemarkLabelID) RemarkLabelID, rtrim(Code) Code, rtrim(DescriptionCode) DescriptionCode
		From dbo.ClientsCatalogs
		WHERE CorporativeID='Nextel' and RemarkLabelID='C6'
)AS ClientsCatalogs
End





