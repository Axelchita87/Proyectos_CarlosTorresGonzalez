-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[UpdateVolarisLog]

@VolarisPNR varchar(10),
@SabrePNR varchar(10),
@Invoiced bit
AS
BEGIN
update [dbo].[VolarisLog] 
set [Invoiced]=@Invoiced,[SabrePNR]=@SabrePNR
where VolarisPNR=@VolarisPNR
END