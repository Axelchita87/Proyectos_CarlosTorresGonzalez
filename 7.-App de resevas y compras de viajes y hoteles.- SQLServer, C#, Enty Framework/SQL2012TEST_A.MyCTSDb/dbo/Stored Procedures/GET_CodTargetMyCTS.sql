--======================================
-- Creo: Eduardo Vázquez Orozco
-- Fecha: 25/04/2013
-- Descripcion: Selecciona el codigo
-- de la tarjeta del DK de la reservacion
--=======================================

CREATE PROCEDURE GET_CodTargetMyCTS
@Location varchar(50)
AS
BEGIN
SELECT CTA_BANC_CBR FROM tbl_CTA_BANC_CBR_MyCTS WHERE LOCATION = @Location
END

--=======================================
-- execute GET_CodTargetMyCTS 'AFA100'
--=======================================