-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 13/04/2009, modificado: 15/04/2009
-- Description:	SP that obtains information about a Sabre error msg
-- =============================================
CREATE PROCEDURE [dbo].[GetSabreErrorMsg]
	@SabreErrMsg as varchar(100),
	@ModuleId as int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT CEM.CusErrMsgUserMsg,
	  CEM.CusErrMsgModuleSrc
	FROM dbo.CusErrMsg CEM WITH(NOLOCK) 
	INNER JOIN dbo.SabreErrMsg SEM WITH(NOLOCK) 
	ON SEM.SabreErrMsgId             = CEM.CusErrMsgSabreErrMsgId
	WHERE SEM.SabreErrMsgCommandName = @SabreErrMsg
	AND CEM.CusErrMsgModuleId        = @ModuleId

END
-- =============================================
-- EXEC GetSabreErrorMsg 'NOT VALID FOR CARRIER',1
-- =============================================