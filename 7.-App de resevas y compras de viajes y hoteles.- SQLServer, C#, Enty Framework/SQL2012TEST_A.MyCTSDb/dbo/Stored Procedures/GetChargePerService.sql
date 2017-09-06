-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 12-05-2009
-- Description:	Procedure that gets a ChargePerService collection
-- =============================================
CREATE Procedure [dbo].[GetChargePerService]
 @StrToSearch as varchar(20)
AS
Begin
		select * from(
 		Select null [Import],null as [IDPaymentForm], null [Description]) as tb
		where [Import] is not null
		
 End