-- =============================================
-- AUTOR: <EDUARDO VAZQUEZ OROZCO>
-- FECHA DE CREACION:  19/04/2013
-- DESCRIPCION: SELECCIONA TODAS LAS FORMAS DE PAGO EXCEPTO TC UATP
-- =============================================

  CREATE PROCEDURE CatFormPaymentCTSSinFoPTP
  AS
	BEGIN

	 SELECT * FROM CatFormPaymentCTS WHERE FormTypeSabreCode !='TP'
	END

--===============================================
-- EXEC CatFormPaymentCTSSinFoPTP
--===============================================