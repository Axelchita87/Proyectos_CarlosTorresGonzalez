-- =============================================
-- Author:		Emmanuel Flores
-- Create date: 19 Abril 2011
-- Description:	Calcula el Metadato de la columna calculada de
-- la tabla Star1
-- =============================================
CREATE FUNCTION [dbo].[CalculateMetadata] (@type varchar(3), @text varchar(4)

    
) RETURNS Varchar(20)
AS
BEGIN
	declare @mdata varchar(20)
	declare @mType char



	select @mdata = Metadata from Metadatas where [Type] = @type and [Value] = @text
			if(@mdata is not null) 
				RETURN @mdata

	select @mdata = Metadata from Metadatas where [Type] = @type and [Value] = substring(@text,0,3)
				if (@mdata is not null)
				RETURN @mdata

	select @mdata = Metadata from Metadatas where [Type] = @type and [Value] = substring(@text,0,2)
			if (@mdata is not null)
				RETURN @mdata

	select @mdata = Metadata from Metadatas where [Type] = @type and [Value] = substring(@text,0,1)
			if (@mdata is not null)
				RETURN @mdata
				
	RETURN 'Datos Generales'
   
END
