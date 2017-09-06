


CREATE PROCEDURE [dbo].[UploadDoc]
(
@doc AS Image, 
@nombre AS VarChar(100), 
@extension AS VarChar(100)
) 
AS
INSERT INTO DocsBinarios (Documento, NombreDoc, Extension) values (@doc, @nombre, @extension)



