


-- =============================================
-- Author:		GUADALUPE ARZATE
-- Create date: 12-07-2011
-- Description:	ACTUALIZA ESTATUS DE ACTIVO DE LOS SEGMENTOS CANCELADOS O ACTIVOS
-- Author:		JOSÉ RICARDO BRITO ORTEGA
-- Create date: 01-04-2015
-- Description:	REALIZA LA BUSQUEDA DE RECORD CON LIKE PARA DIFERENCIAR AUTOS DE HOTELS
-- =============================================
CREATE PROCEDURE [dbo].[UpdateDetailsPNRHotel]
@RecLog varchar(50),
@ChainCode varchar(50),
@Cancel_Number varchar(50),
@Cancel bit
AS
BEGIN
DECLARE @Cancel_Num varchar(50)
set @Cancel_Num=null
select @Cancel_Num=Cancel_Number from DetailsPNRHotel where Record like @RecLog and ChainCode=@ChainCode and Cancel_Number is not null
IF @Cancel_Num<>@Cancel_Number
------actualizacion si campo de cancelacion en vacio
UPDATE TOP(1)[dbo].[DetailsPNRHotel]
   SET[Status] = '0',Cancel_Number=@Cancel_Number
WHERE Record like @RecLog and ChainCode=@ChainCode and Cancel_Number is null
ELSE IF @ChainCode is not null
-----actualizacion si campo de cancelacion No existe Nuevo 
--BEGIN
UPDATE [dbo].[DetailsPNRHotel]
   SET[Status] = '0',Cancel_Number=@Cancel_Number
WHERE Record like @RecLog and ChainCode=@ChainCode
--END
ELSE IF @ChainCode is null and @Cancel_Number is null
BEGIN
UPDATE [dbo].[DetailsPNRHotel]
   SET[Status] = '0'
WHERE Record like @RecLog
END

IF @Cancel = 'True'
begin
UPDATE [dbo].[DetailsPNRHotel]
SET[Status] = '0'
WHERE Record like @RecLog
end


END