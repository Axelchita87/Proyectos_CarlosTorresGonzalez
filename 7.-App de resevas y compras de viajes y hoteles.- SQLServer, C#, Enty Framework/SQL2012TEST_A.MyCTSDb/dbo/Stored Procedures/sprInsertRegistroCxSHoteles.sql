-- =============================================
-- Author:		Luis Felipe Segura Velasco
-- Author:		Luis Felipe Segura Velasco
-- Create date: 15 de Noviembre de 2013
-- Create date: 15 de Noviembre de 2013
-- Description:	PA que inserta el registro de un cargo por servicios de hotel desde MyCTS
-- Author:		José Ricardo Brito Ortega
-- Create date: 11 de Diciembte de 2014
-- Description:	Se le realizo una modificacion al tamño del parametro @fcPNR
-- =============================================
CREATE PROCEDURE [dbo].[sprInsertRegistroCxSHoteles] 
	@fcPNR varchar(15),
	@fcTransaccionId varchar(50),
	@fiOrgId int,
	@fcAutorization varchar(10),
	@fcOperation varchar(10),
	@fcNumeroTarjeta varchar(50),
	@fcFormaDePago varchar(10),
	@fdMonto decimal(18,4)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @Id int

	SELECT @Id = count(*)+1 FROM tblCXSHoteles

	INSERT INTO [dbo].[tblCXSHoteles]
           ([fcPNR]
           ,[fcTransaccionId]
           ,[fiOrgId]
           ,[Id]
           ,[fcAutorization]
           ,[fcOperation]
		   ,[fcNumeroTarjeta]
		   ,[fcFormaDePago]
		   ,[fdMonto])
     VALUES
           (@fcPNR,
			@fcTransaccionId,
			@fiOrgId,
			@Id,
			@fcAutorization,
			@fcOperation,
			@fcNumeroTarjeta,
			@fcFormaDePago,
			@fdMonto)
END
-- =============================================
-- EXEC sprInsertRegistroCxSHoteles 
-- =============================================
