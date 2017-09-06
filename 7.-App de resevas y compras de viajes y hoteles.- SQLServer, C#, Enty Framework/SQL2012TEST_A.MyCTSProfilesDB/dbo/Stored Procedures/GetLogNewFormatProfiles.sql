



-- =============================================
-- Author:		<Ivan Martinez Guerrero>
-- Create date: <27/Enero/2010>
-- Description:	<Inserta Log>
-- =============================================
CREATE PROCEDURE [dbo].[GetLogNewFormatProfiles] 
	-- Add the parameters for the stored procedure here
	@pccid nvarchar(10),
	@Star1Name nvarchar(50),
    @Star2Name nvarchar(50),
	@level int
    
	
AS
BEGIN

	IF @level=1
    Begin

	Select UserName,ModifiedDate From dbo.LogNewFormatProfiles
	Where Pcc=@pccid and StarLevel1=@star1Name and StarLevel2 is null
	
	End

	ELSE IF @level=2
	Begin

	Select UserName,ModifiedDate From dbo.LogNewFormatProfiles
	Where Pcc=@pccid and StarLevel1=@star1Name and StarLevel2=@star2Name

	End

END

----------------------------------------------------------------------------------------------


/****** Object:  StoredProcedure [dbo].[SetLogNewFormatProfiles]    Script Date: 11/07/2011 12:30:31 ******/
SET ANSI_NULLS ON
