-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create Procedure[dbo].[InsertVolarisReservation]
@VolarisPNR varchar(50),
@SabrePNR varchar(50),
@Agent varchar(10),
@AgentMail varchar(50),
@Date datetime,
@AuthCode varchar(10),
@Approved  bit,
@Invoiced  bit,
@Amount decimal(18,0)
AS
BEGIN
INSERT INTO VolarisLog
            (
			[VolarisPNR],
             [SabrePNR],
             [Agent],
			 [AgentMail],
			 [Date],
			 [AuthCode],
             [Approved],
             [Invoiced],
			 [Amount]
             )
       VALUES
       (
	   		 @VolarisPNR,
             @SabrePNR,
             @Agent,
			@AgentMail,
			@Date,
			@AuthCode,
            @Approved,
            @Invoiced,
			@Amount
        )
END