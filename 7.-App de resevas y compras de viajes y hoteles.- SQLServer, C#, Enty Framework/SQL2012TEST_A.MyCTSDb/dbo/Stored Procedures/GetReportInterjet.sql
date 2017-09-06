CREATE PROCEDURE [dbo].[GetReportInterjet]
@fecha datetime
AS
Begin
SELECT Date as fecha,ReservationCode,Amount FROM dbo.LogInterJet WHERE 
Date >= @fecha + ' ' + '00:00:00' and Date < @fecha + ' ' + '23:59:59'
End
