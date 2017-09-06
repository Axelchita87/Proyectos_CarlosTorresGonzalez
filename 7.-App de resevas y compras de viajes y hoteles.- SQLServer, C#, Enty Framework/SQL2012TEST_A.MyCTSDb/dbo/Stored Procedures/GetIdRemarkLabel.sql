

-- =============================================
-- Author:		Jessica Gutiérrez Becerril
-- Create date: 26/08/2010
-- Description:	Procedure that gets a LabelRemark 
-- =============================================
create Procedure [dbo].[GetIdRemarkLabel]
@Description as varchar(50)
AS
Begin
		SELECT IDRemarkLabel 
		FROM dbo.LabelsRemarks
		WHERE Description=@Description
 End
