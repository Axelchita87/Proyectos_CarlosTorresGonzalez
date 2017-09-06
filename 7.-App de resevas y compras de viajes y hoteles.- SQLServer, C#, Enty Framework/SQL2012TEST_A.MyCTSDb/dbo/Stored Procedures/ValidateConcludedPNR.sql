
-- =============================================
-- Author:		Marcos Q. Ramirez
-- Create date: 20-02-2012
-- Description:	procedure that verifyies pnr status
-- =============================================
create Procedure [dbo].[ValidateConcludedPNR]
@PNR as varchar(10),
@ORGID int
AS
Begin    

  select Count(record)as 'Count' from detailspnrhotel
  where record = @PNR
  and status in ('3', '4')

End