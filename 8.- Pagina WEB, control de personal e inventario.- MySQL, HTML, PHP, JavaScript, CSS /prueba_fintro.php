<DOCTYPE!>
<html>

<head>
	<meta charset="UTF8">
</head>

<body>
	 <select name="tipo_seleccion" id="tipo_seleccion" class="form-control">
                            <option value="0">Selecciona...</option>
                            <option value="1">Campaña</option>
                            <option value="2">Evaluador</option>
                            <option value="3">Encargado</option>
     </select>
     <br>
     <br>
     <br>
	<select multiple="" class="form-control" id="opciones_seleccion" name="seleccion">
		<option value="0">Selecciona...</option>
		<option  value="11"></option>
		<option  value="12"></option>
		<option  value="13">prueba</option>
		<option  value="14">Campana 3</option>
		<option  value="15">Campana 3</option>
		<option  value="16">Campana 3</option>
		<option  value="17">Campana 1</option>
		<option  value="18">Campana 1</option>
		<option value="19">Campana 3</option>
		<option value="20">Campana 3</option>
		<option  value="21">undefined</option>
		<option value="22">
	</select>
	<br>
	<br>
     <br>
     
	<button id="btn-respuesta" onclick="capturar()">Seleccionados</button>

	<script>
	    function capturar()

    {

    	var seleccion=document.getElementById("tipo_seleccion").value;
    	if (seleccion== 1);
    		document.getElementById("resultado1").innerHTML="Campaña " ;

		var porId=document.getElementById("opciones_seleccion");
        var multi = [];
        for (var i = 0; i < porId.length; i++) {
        if (porId.options[i].selected) multi.push(porId.options[i].value);
   		 }
   			 console.log(multi);
   			 document.getElementById("resultado").innerHTML="<br>Por ID: "+multi ;



	}

	</script>
	<br>
     <br>
     <br>
	<div id = "resultado1">Tipo...</div><div id="resultado"> Y sus ID's ...</div>

</body>
</html>