<?php
require_once 'class/class.altas.php';
//session_start();
if(isset($_SESSION['user']) && $_SESSION['permiso']=='directivo'){

?>

<body>

	<script LANGUAGE="JavaScript">
			/*	function numerico(e)
				{	var key; 
					var keychar;
					if (window.event)
					   key = window.event.keyCode;
					else if (e)
					   key = e.which;
					else
					   return true;
					keychar = String.fromCharCode(key);
					keychar = keychar.toLowerCase();
					if ((key==null) || (key==0) || (key==8) || (key==9) || (key==27) )
					   return true;
					else if ((("1234567890").indexOf(keychar) > -1))
					   return true;
					else
					   return false;
				}
				
				function alfanumerico(e)
				{
					var key;
					var keychar;
					if (window.event)
					   key = window.event.keyCode;
					else if (e)
					   key = e.which;
					else
					   return true;
					keychar = String.fromCharCode(key);
					keychar = keychar.toLowerCase();
					// control keys
					if ((key==null) || (key==0) || (key==8) ||
						(key==9) || (key==27) )
					   return true;
				
					// alphas and numbers
					else if ((("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz 1234567890Ã¡Ã©Ã­Ã³ÃºÃÃ‰ÃÃ“ÃšÃ¼ÃœÃ±Ã‘-_.:,;()").indexOf(keychar) > -1))
					   return true;
					else
					   return false;
				}
				
				
		
				
				
				function alfabetico(e)
				{
					var key;
					var keychar;
					if (window.event)
					   key = window.event.keyCode;
					else if (e)
					   key = e.which;
					else
					   return true;
					keychar = String.fromCharCode(key);
					keychar = keychar.toLowerCase();
					// control keys
					if ((key==null) || (key==0) || (key==8) ||
						(key==9) || (key==27) )
					   return true;
				
					// alphas and numbers
					else if ((("ABCDEFGHIJKLMNÃ‘OPQRSTUVWXYZ abcdefghijklmnÃ±opqrstuvwxyz").indexOf(keychar) > -1))
					   return true;
					else
					   return false;
				}
				
				function co(e)
				{
					var key;
					var keychar;
					if (window.event)
					   key = window.event.keyCode;
					else if (e)
					   key = e.which;
					else
					   return true;
					keychar = String.fromCharCode(key);
					keychar = keychar.toLowerCase();
					// control keys
					if ((key==null) || (key==0) || (key==8) ||
						(key==9) || (key==27) )
					   return true;
				
					// alphas and numbers
					else if ((("ABCDEFGHIJKLMNÃ‘OPQRSTUVWXYZ abcdefghijklmnÃ±opqrstuvwxyz 1234567890._-@ ").indexOf(keychar) > -1))
					   return true;
				 	else
					   return false;
				}*/

	$(function(){//Funciones para validar fotografía
	  //Oculta contenedor	
	    contenedor = $('#foto_preview'); 
		contenedor.hide();	
		 
	  //Preview Imagen
	  function readURL(input) {
		contenedor = $('#foto_preview');  
      	if (input.files && input.files[0]) {
        	var reader = new FileReader();
        	reader.onload = function (e) {
           		contenedor.attr('src', e.target.result);
				contenedor.show()
        	}
        	reader.readAsDataURL(input.files[0]);
    	}
	  }	
	  
	  //Limpiar Input
	  function limpiar_input(input, contenedor) {
		var control_input = input;
      	control_input.replaceWith(control_input.val('').clone(true));
		contenedor.attr('src', '');
		contenedor.hide()
	  };
		
		//Valida el tamaño de la imagen
	   valida_tamano = function(input){
		var control_input = input; 
	   	size=(control_input.files[0].size/1024/1024).toFixed(2);
		return size
	   }
	   	//Validar extensión
	   valida_extension = function(input){
   		var control_input = input; 
    	var ext = control_input.value.match(/\.(.+)$/)[1].toLowerCase();
    	switch (ext) {
        	case 'jpg':
        	case 'jpeg':
        	case 'png':
        	case 'gif':
            	return true
        	default:
            	return false;
    	}
	   };
	   
	   mensajes_error = function(clave){
		  switch (clave) {
        	case 1: alert("La imagen debe pesar máximo 2Mb");break;
			case 2: alert("La extensión de la imagen es invalida");break;
        	default:
            	return false;
    	} 
	   }
		
		
      $('#image-file').on('change', function() {
		  size=valida_tamano(this);
		  extension=valida_extension(this)
		  console.log(valida_extension(this));
		  if (size<2&&extension==true){
			readURL(this);
			$('#btnClearFoto').show();
		  }else{
			limpiar_input($('#image-file'),$('#foto_preview'))   
		  	if(extension==false){mensajes_error(2);}
			else{ 
				if(size>2){mensajes_error(1);}
			}
		  }
	  });

      $('#cont-image_preview').click(function(){
      	$('#image-file').click();
      })

      $('#btnClearFoto').hide();

      $('#btnClearFoto').click(function(){
      	limpiar_input($('#image-file'),$('#foto_preview'));
      	$('#btnClearFoto').hide();
      });

		//Validar los campos obligatorios
		 $("#form-alta").submit(function() {
			var x1 = $("#usuario").val();
			var x2 = $("#contrasena").val();
			var x3 = $("#permiso").val();
			if (x1==''||x2==''||x3=='0') {
				alert("Debes llenar todos los campos obligatorios");
				return false;
			} else
				return true;
		});


	})
			
						
		</script>

<div border="0" class="table-responsive" >
	<?php require "views/directivos/menu_vertical.php" ?>

	<div id="contenido">
		<?php require "views/directivos/header_directivo.php" ?>		
		<div id="contenedor">

			<h3>Alta de Reportes</h3>

			<div id="" class="cont-form col-md-10">

			<form action="index.php?command=alta_directivo" method="POST" enctype="multipart/form-data" style="width:100%" id="form-alta">
				
					<br />
					<div class="label-h">Datos generales</div>
					<div class="caja-campos">
						<div class="label" style="">Usuario:*</div>
						<div class="">
							<input name="usuario" id="usuario" class="" placeholder="Usuario">
						</div>

						<div class="label" style="">
							Contrase&ntilde;a:*
						</div>

						<div class="">
							<input name="contrasena" id="contrasena" class="" placeholder="Contrase&ntilde;a">
						</div>

						<div class="label" style="">
							Permiso*
						</div>
						<div class="">
						<select name="permiso" id="permiso" class="">
							<option value="0">Selecciona...</option>
							<option value="1">Directivo</option>
							<option value="2">Auditor</option>
							<option value="3">Promotor</option>
						</select>

						<div class="label" style="">
							Correo:*
						</div>
						<div class="">
							<input name="correo" type="mail" class="" placeholder="correo electronico">
						</div>
						<div class="label" style="">
							Telefono:
						</div>
						<div class="">
							<input name="telefono" class="" placeholder="Telefono">
						</div>
						<div id="marco-foto">
							<div class="label" style="">
								Foto:
							</div>

							<div id="cont-image_preview"><img src="" id="foto_preview"/></div>
							<div class="btn btn-sm btn-block btn-success" id="btnClearFoto">Borrar foto</div>
							<div class="">
								<input name="Foto1" id="image-file" type="file" class="" >
							</div>
						</div>

					</div>
					</div>
					

					<div class="label-h">Nombre</div>
					<div class="caja-campos">
						<input class="campo" name="apellido-paterno" placeholder="Apellido Paterno" type="campo">
						<div class="label">Apellido Paterno</div>
	 					<input class="campo" name="apellido-materno" placeholder="Apellido Materno" type="campo">
						<div class="label">Apellido Materno</div>
						<input class="campo" name="nombre" placeholder="Nombre" type="campo">
						<div class="label">Nombre(s)</div>
					</div>	

					<div class="label-h">Dirección actual</div>
					<input class="campo" name="direccion" placeholder="Dirección" type="campo">
					<div class="label">Calle, Número</div>


					<div class="">
						<select name="estado" class="">
							<option>Selecciona...</option>
						</select>
					</div>
					<div class="" style="">
						Estado:
					</div>

					<div class="">
						<select name="municipio" class="">
							<option>Selecciona...</option>
						</select>
					</div>
					<div class="" style="">
						Municipio:
					</div>
							

					<div class="label-h">Telefonos</div>
					<input class="campo" name="telefono-local" placeholder="Telefono Casa" type="campo">
					<div class="label">Casa</div>
					<input class="campo" name="telefono-celular" placeholder="Telefono Celular" type="campo">
					<div class="label">Celular</div>
					<input class="campo" name="nombre" placeholder="Correo" type="campo">
					<div class="label">Correo(s)</div>
						

					<div class="label-h">Otros</div>
					<input class="campo" name="f-nacimiento" placeholder="Fecha de Nacimento" type="campo">
					<div class="label">Lugar de Nacimiento</div>
					<input class="campo" name="l-nacimiento" placeholder="Lugar de Nacimento" type="campo">
					<div class="label">Lugar de Nacimiento</div>
					<input class="campo" name="nacionalidad" placeholder="Nacionalidad" type="campo">
					<div class="label">Nacionalidad</div>
					<input type="radio" name="sex" value="1" checked>Hombre
					<input type="radio" name="sex" value="2">Mujer
					<div class="label">Genero </div>
					<div class="label">Encaso de emergencia llamar a: </div>
					<input class="campo" name="nombre-emergencia1" placeholder="Nombre" type="campo">
					<div class="label">Nombre </div>
					<input class="campo" name="numero-emergencia1" placeholder="Número" type="campo">
					<div class="label">Teléfono: </div>
					<input class="campo" name="nombre-emergencia2" placeholder="Nombre" type="campo">
					<div class="label">Nombre </div>
					<input class="campo" name="numero-emergencia2" placeholder="Número" type="campo">
					<div class="label">Teléfono: </div>	

					
					<div class="">
						<input type="submit" value="Guardar" name="btn_alta" class="btn btn-block btn-sm btn-info">
					</div>


					<br />
				

			</form>
			</div>
		</div>
		<?php require "views/directivos/footer_directivo.php" ?>
		
	</div>
</div>
</body>
<?php

}
else{
?>
<script>
alert("tu no tienes permiso para ver este contenido");
document.location.href="index.php?command=home";
</script>
<?php
}
?>
