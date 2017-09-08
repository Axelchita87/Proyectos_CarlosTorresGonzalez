<?php
require_once 'class/class.altas.php';
//session_start();
if(isset($_SESSION['user']) && $_SESSION['permiso']=='directivo'){

?>

<body>

	<style type="text/css">
		.campo{min-height:20px;background-color:#ccc;}
		
	</style>

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


	  //recuperar datos	
	  r_datos = function(options){

          options=(options==typeof(undefined))?'':options;
          params=options;
        var datos = $.ajax({
          url:'class/class.altas.php',
    		  type:'post',
    		  dataType:'json',
          data:params,
    		  async:false    		
    	 }).responseText;
        return datos
      }
		 
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

      /*$('#cont-image_preview').click(function(){
      	$('#image-file').click();
      })*/

      $('#btnClearFoto').hide();

      $('#btnClearFoto').click(function(){
      	limpiar_input($('#image-file'),$('#foto_preview'));
      	$('#btnClearFoto').hide();
      });

		//Validar los campos obligatorios
		 $("#form-alta").submit(function() {
			var x1 = $("#usuario").val();
			if (x1=='0') {
				alert("Debes seleccionar un usuario");
				return false;
			} else
				return true;
		});

		$("#usuario").on('change',function(){
			var valores = r_datos({'get_perfil_usuario':$("#usuario").val()})

			v_valores = JSON.parse(valores)
			if ($("#usuario").val()!='0'){
				$("#contrasena").html("*******");
				$("#permiso").html(v_valores[2]);
				$("#telefono-local").html(v_valores[3]);
				$("#telefono-celular").html(v_valores[4]);
				$("#correo").html(v_valores[5]);
					if(v_valores[6]!=''){
						$("#foto_preview").attr('src',"uploads/usuarios/thumbs/"+v_valores[6]);
						$("#foto_preview").show();
						$('#btnClearFoto').hide();
					}else{
						$("#foto_preview").attr('src',"images/no-image.jpg");
						$("#foto_preview").hide();
						$('#btnClearFoto').hide();
					}
				$("#apellido-paterno").html(v_valores[7]);
				$("#apellido-materno").html(v_valores[8]);
				$("#nombre").html(v_valores[9]);
				$("#direccion").html(v_valores[10]);
				$("#estado").html(v_valores[11]);
				$("#municipio").html(v_valores[12]);
				$("#f-nacimiento").html(v_valores[13]);
				$("#l-nacimiento").html(v_valores[14]);
				$("#nacionalidad").html(v_valores[15]);
						if(v_valores[16]=='1'){
							v_valores[16]='Hombre'
						}else if(v_valores[16]=='2'){
							v_valores[16]='Mujer'
						}
				$("#genero").html(v_valores[16]);
				$("#nombre-emergencia1").html(v_valores[17]);
				$("#numero-emergencia1").html(v_valores[18]);
				$("#nombre-emergencia2").html(v_valores[19]);
				$("#numero-emergencia2").html(v_valores[20]);
				$("#anexo1").html(v_valores[24]);
				//Anexo 2 Forms extras
				v_valores_f_ext = JSON.parse(v_valores[25])
				var z = v_valores_f_ext;
					for(var i in z) {
						console.log(i)
						f_cont='#'+i;
						$(f_cont).html(v_valores_f_ext[i]);
					}
			}else{
				$("#contrasena").html('');
				$("#permiso").html('');
				$("#correo").html('');
				$("#telefono").html('');
				$("#foto_preview").attr('src','');
				$("#apellido-paterno").html('');
				$("#apellido-materno").html('');
				$("#nombre").html('');
				$("#direccion").html('');
				$("#estado").html('');
				$("#municipio").html('');
				$("#f-nacimiento").html('');
				$("#l-nacimiento").html('');
				$("#nacionalidad").html('');
				$("#genero").html('');
				$("#nombre-emergencia1").html('');
				$("#numero-emergencia1").html('');
				$("#nombre-emergencia2").html('');
				$("#numero-emergencia2").html('');
				$("#anexo1").html('');
				//Anexo 2 Forms extras
				v_valores_f_ext = JSON.parse(v_valores[25])
				var z = v_valores_f_ext;
					for(var i in z) {
						console.log(i)
						f_cont='#'+i;
						$(f_cont).html('');
					}
			}
		})


	})
			
						
		</script>

<div border="0" class="table-responsive" >
	<?php require "views/directivos/menu_vertical.php" ?>

	<div id="contenido">
		<?php require "views/directivos/header_directivo.php" ?>		
		<div id="contenedor">

			<h3> Perfíl de Usuarios </h3>

			<div id="" class="cont-form col-md-10">

			<form action="index.php?command=modificar_directivo" method="POST" enctype="multipart/form-data" style="width:100%" id="form-alta">

					<br />
					<div class="label-h">Datos generales</div>
					<div class="caja-campos row">
						
						<div class="col-md-10 col-sm-10 col-xs-7">	
							<div class="row grid">
								<div class="label col-md-2 col-sm-2 col-xs-12" style="">Usuario*</div>
								<select class="col-md-5 col-sm-8 col-xs-12" name="usuario" id="usuario" >
	 								<option value="0">Selecciona...</option>
									<?php
									global $obj_db;
                        			$consulta2 = "SELECT id_usuario,user_name FROM usuario ORDER BY user_name ASC";
                        			$result2 = $obj_db->consulta($consulta2);
                        			if($result2!=false){
	                          			foreach($result2 as $fila2){
                          					echo "<option class='text-danger text-center' value ='".$fila2['id_usuario']."'>".$fila2['user_name']."</option>";
                          				}
                        			}
                        			?>
								</select>								
    						</div>

    						<div class="row grid">
    							<label class="label col-md-2 col-sm-2 col-xs-12" style="">Contrase&ntilde;a:*</label>
								<div name="contrasena" id="contrasena" class="campo col-md-5 col-sm-8 col-xs-12" ></div>								
							</div>

							<div class="row grid">
								<label class="label col-md-2 col-sm-2 col-xs-12" style="">Permiso*</label>
								<div name="permiso" id="permiso" class="campo col-md-5 col-sm-8 col-xs-12"></div>								
							</div>

							<div class="row grid">
								<label class="label col-md-2 col-sm-2 col-xs-12">Casa</label>
								<div class="campo col-md-5 col-sm-8 col-xs-12" name="telefono-local" id="telefono-local"></div>								
							</div>

							<div class="row grid">
								<label class="label col-md-2 col-sm-2 col-xs-12">Celular</label>
								<div class="campo col-md-5 col-sm-8 col-xs-12" name="telefono-celular" id="telefono-celular"></div>								
							</div>

							<div class="row grid">
								<label class="label col-md-2 col-sm-2 col-xs-12">Correo(s)</label>	
								<div class="campo col-md-5 col-sm-8 col-xs-12" name="correo" id="correo"></div>								
							</div>

						</div>
                        
                        <div class="col-md-2 col-sm-2 col-xs-5">
							<div id="marco-foto">
								<div class="label" style=""> Foto:</div>
								<div id="cont-image_preview"><img src="" id="foto_preview"/></div>
							</div>
						</div>

					</div>
					
					

					<div class="label-h">Nombre</div>
					<div class="caja-campos  row">
						<div class="col-md-12 col-sm-12 col-xs-12">
							<div class="row grid">
								<label class="label col-md-2 col-sm-2 col-xs-2">Apellido Paterno</label>
								<div class="campo col-md-5 col-sm-8 col-xs-12" name="apellido-paterno" id="apellido-paterno" placeholder="Apellido Paterno" type="campo"></div>
							</div>
	 						<div class="row grid">
		 						<label class="label col-md-2 col-sm-2 col-xs-2">Apellido Materno</label>
	 							<div class="campo col-md-5 col-sm-8 col-xs-12" name="apellido-materno" id="apellido-materno" placeholder="Apellido Materno" type="campo"></div>
							</div>
							<div class="row grid">
								<label class="label col-md-2 col-sm-2 col-xs-2">Nombre(s)</label>
								<div class="campo col-md-5 col-sm-8 col-xs-12" name="nombre" id="nombre" placeholder="Nombre" type="campo"></div>
							</div>
						</div>
					</div>		

					<div class="label-h">Dirección actual</div>
					<div class="caja-campos  row">
						<div class="col-md-12 col-sm-12 col-xs-12">
							<div class="row grid">
								<label class="label col-md-2 col-sm-2 col-xs-2">Calle, Número</label>
								<div class="campo col-md-5 col-sm-8 col-xs-12" name="direccion" id="direccion"></div>
								
							</div>	

							<div class="row grid">
								<label class="label col-md-2 col-sm-2 col-xs-2" style="">Estado:</label>
								<div name="estado" id="estado" class="campo col-md-5 col-sm-8 col-xs-12"></div>
                        		
                        	</div>

                        	<div class="row grid">
                        		<label class="label col-md-2 col-sm-2 col-xs-2" style="">Municipio:</label>
								<div class="campo col-md-5 col-sm-8 col-xs-12" name="municipio" id="municipio"></div>
								
							</div>
						</div>
					</div>
					
					

					<div class="label-h">Otros</div>
					<div class="caja-campos row">
						<div class="col-md-12 col-sm-12 col-xs-12">
							<div class="row grid">
								<div class="col-md-6 col-sm-6" >
									<label class="label col-md-4 col-sm-4 col-xs-2">Fecha de Nacimiento</label>
									<div class="campo col-md-8 col-sm-8 col-xs-12" name="f-nacimiento" id="f-nacimiento"></div>
								</div>
								<div class="col-md-6 col-sm-6">
									<label class="label col-md-4 col-sm-4 col-xs-2">Lugar de Nacimiento</label>
									<div class="campo col-md-8 col-sm-8 col-xs-12" name="l-nacimiento" id="l-nacimiento"></div>
								</div>
								
							</div>
							<div class="row grid">
								
								
							</div>
							<div class="row grid">
								<div class="col-md-6 col-sm-6" >
									<label class="label col-md-4 col-sm-4 col-xs-2">Nacionalidad</label>
									<div class="campo col-md-8 col-sm-8 col-xs-12" name="nacionalidad" id="nacionalidad"></div>
								</div>
								<div class="col-md-6 col-sm-6" >
									<label class="label col-md-4 col-sm-4 col-xs-2">Genero </label>
									<div class="campo col-md-8 col-sm-8 col-xs-12" name="genero" id="genero"></div>
								</div>
							</div>
							
							<div class="label">Encaso de emergencia llamar a: </div>
							<div class="row grid">	
								<div class="col-md-7 col-sm-7" >		
									<label class="label col-md-3 col-sm-4 col-xs-2">Nombre </label>			
									<div class="campo col-md-9 col-sm-8 col-xs-12" name="nombre-emergencia1" id="nombre-emergencia1"></div>
								</div>
								<div class="col-md-5 col-sm-5" >
									<label class="label col-md-3 col-sm-4 col-xs-2">Teléfono: </label>
									<div class="campo col-md-9 col-sm-8 col-xs-12" name="numero-emergencia1" id="numero-emergencia1"></div>
								</div>
								
							</div>
							
							<div class="row grid">
								<div class="col-md-7 col-sm-7" >
									<label class="label col-md-3 col-sm-4 col-xs-2">Nombre </label>
									<div class="campo col-md-9 col-sm-8 col-xs-12" name="nombre-emergencia2" id="nombre-emergencia2"></div>
								</div>
								<div class="col-md-5 col-sm-5" >
									<label class="label col-md-3 col-sm-4 col-xs-2">Teléfono: </label>	
									<div class="campo col-md-9 col-sm-8 col-xs-12" name="numero-emergencia2" id="numero-emergencia2"></div>
								</div>
							</div>	
							<div class="row grid">
								<div class="col-md-7 col-sm-7" >
									<label class="label col-md-3 col-sm-4 col-xs-2">Comentarios: </label>
									<div class="campo col-md-9 col-sm-8 col-xs-12" name="anexo1" id="anexo1" placeholder="Anexo1" type="campo"></div>
								</div>								
							</div>							
						</div>
					</div>

					<?php
						global $obj_db;
                    	$consulta3 = "SELECT id_form, f_alias, f_label, f_default FROM form_extra WHERE id_seccion=1 ORDER BY f_alias ASC";
                        $result3 = $obj_db->consulta($consulta3);
                       	if($result3!=false){
                    ?>
                    <div class="label-h">Extras</div>
					<div class="caja-campos row">
						<div class="col-md-12 col-sm-12 col-xs-12">
							<input id="form_ext" name="form_ext" type="hidden" value="true">
					<?php
		                    foreach($result3 as $fila3){
		            ?>
                         	
                         		<div class="row grid">
									<div class="col-md-6 col-sm-6" >
										<label class="label col-md-4 col-sm-4 col-xs-2"><?php echo $fila3['f_label']?></label>
										<div class="campo col-md-8 col-sm-8 col-xs-12" id="<?php echo "form_ext_".$fila3['id_form']?>" name="<?php echo "form_ext_".$fila3['id_form']?>" placeholder="<?php echo $fila3['f_default']?>" type="campo"></div>
									</div>	
								</div>	
                   	<?php
                   			}
                    ?>
                   		</div>
					</div>
                   	<?php		
                   	   	}
                    ?>


					<hr>
					
					<div class="caja-campos">
						<div class="">
							<input value="Modificar" type="submit" name="btn_modificar_usuario" id="btn_modificar_usuario" class="btn btn-block btn-sm btn-info" >
							<input value="Imprimir" type="button" name="imprimir_perfi_usuario" id="imprimir_perfil_usuario" class="btn btn-block btn-sm btn-info" >
						</div>
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
