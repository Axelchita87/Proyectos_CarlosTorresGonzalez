CREATE PROCEDURE [dbo].[GetReportVolaris]
@fecha datetime
AS
BEGIN
select Date As fecha, VolarisPNR, Amount from dbo.VolarisLog
where Date >= @fecha + ' ' + '00:00:00' and Date < @fecha + ' ' + '23:59:59'
END 
