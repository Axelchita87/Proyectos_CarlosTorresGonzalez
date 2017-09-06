-- =============================================
-- Author:	Jessica Gutierres
-- Create date: 11/06/13
-- Description:	Extraer si firma esta Activia y el FamilyName
-- =============================================
CREATE PROCEDURE [dbo].[Get_StatusFamilyName2]
@Firm varchar(4),
@PCC varchar(50)
AS
BEGIN
	select StatusFirm, FamilyName,PCC
	from [dbo].[Users]
	where [Firm]=@Firm and PCC=@PCC
END