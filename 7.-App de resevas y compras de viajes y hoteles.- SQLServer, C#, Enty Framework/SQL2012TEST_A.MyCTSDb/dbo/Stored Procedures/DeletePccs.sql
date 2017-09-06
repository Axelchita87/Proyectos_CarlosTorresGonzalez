

-- =============================================
-- Author:		Jessica Gutiérrez Becerril
-- Create date: 04-05-2010
-- Description:	Procedure that delete a Pcc 
-- =============================================
create Procedure [dbo].[DeletePccs]
 @StrToSearch as varchar(10)
AS

Begin
	delete dbo.CatPccs
	where CatPccId=@StrToSearch
End
