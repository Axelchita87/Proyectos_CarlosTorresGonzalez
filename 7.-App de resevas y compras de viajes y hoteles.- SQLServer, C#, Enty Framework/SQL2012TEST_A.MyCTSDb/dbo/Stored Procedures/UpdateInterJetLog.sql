-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateInterJetLog]

@ReservationCode varchar(10),
@Approved bit,
@Invoiced bit	
AS
BEGIN
update [dbo].[LogInterJet] 
set [Invoiced]=@Invoiced
where ReservationCode=@ReservationCode
END