-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE Procedure[dbo].[InsertInterJetLog]
@Agent varchar(50),
@ReservationCode  varchar(10),
@Approved  bit,
@Invoiced  bit
AS
BEGIN
INSERT INTO LogInterJet
            ([Agent],
             [Date],
             [ReservationCode],
             [Approved],
             [Invoiced]
             )
       VALUES
       (@Agent,
        GETDATE(),
        @ReservationCode,
        @Approved,
        @Invoiced
        )
END
