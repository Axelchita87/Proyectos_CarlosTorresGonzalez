


-- =============================================
-- Author:		Jessica Gutiérrez Becerril
-- Create date: 09-05-2010
-- Description:	Procedure that delete a AlAgreements 
-- =============================================
create Procedure [dbo].[DeleteAirLineAgreements]
 @StrToSearch as varchar(10)
AS

Begin
	delete dbo.AlAgreements
	where IDAlCode=@StrToSearch
End
