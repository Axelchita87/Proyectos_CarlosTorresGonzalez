-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertPNRInterJetLog]

@ReservationCode varchar(10),
@RecordLocator varchar(10)
AS
BEGIN
update [dbo].[LogInterJet] 
set [RecordLocator]=@RecordLocator
where ReservationCode=@ReservationCode
END
