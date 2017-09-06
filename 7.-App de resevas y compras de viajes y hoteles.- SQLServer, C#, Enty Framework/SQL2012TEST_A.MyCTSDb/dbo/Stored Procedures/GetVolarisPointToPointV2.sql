-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetVolarisPointToPointV2]
@To as varchar (50),
@From as varchar(50)
AS
BEGIN

	select * from [dbo].[VolarisPointToPointV2]
	where [To]=@To and [From]=@From
END