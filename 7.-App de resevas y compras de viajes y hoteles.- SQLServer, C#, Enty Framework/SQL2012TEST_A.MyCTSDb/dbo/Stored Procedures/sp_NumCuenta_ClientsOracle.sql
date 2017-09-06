--======================================
-- Creo: Eduardo Vázquez Orozco
-- Fecha: 25/04/2013
-- Descripcion: Selecciona el codigo
-- de la tarjeta del DK de la reservacion
--=======================================

CREATE PROCEDURE sp_NumCuenta_ClientsOracle
@Location varchar(50)
AS
BEGIN
SELECT CTA_BANC_CBR FROM NumCta_ClientsOracl WHERE LOCATION = @Location
END

--=======================================
-- execute sp_NumCuenta_ClientsOracle 'AFA100'
--=======================================