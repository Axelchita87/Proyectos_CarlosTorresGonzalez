-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE Procedure[dbo].[InsertLowFareAirLinesError]
@Agent varchar(50),
@ErrorMessage  varchar(MAX),
@AirLine  varchar(50),
@Date  datetime,
@ServiceName varchar(50)
AS
BEGIN
INSERT INTO LowFareAirLinesErrorLog
            ([Agent],
             [ErrorMessage],
             [AirLine],
             [Date],
			 [ServiceName]
             )
       VALUES
       (@Agent,
        @ErrorMessage,
        @AirLine,
        @Date,
		@ServiceName
        )
END