<?php
require_once 'class/class.altas.php';
//session_start();
if(isset($_SESSION['user']) && $_SESSION['permiso']=='directivo'){

?>

  <body class="skin-blue sidebar-mini">

	<style type="text/css">		
		
		.input-group-addon{min-width: 40px;}				 

	</style>

	<script LANGUAGE="JavaScript">
			

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

		 $("#btn_alta").on('click',function(){
		 	$("#form-alta").submit();
		 })

		$("#estado").on('change',function(){
			var valores = r_datos({'get_estados':$("#estado").val()})
			//console.log(valores[0].replace("",""));

			v_valores = JSON.parse(valores)
			if ($("#estado").val()!='0'){$("#municipio").html(v_valores[0])}
		})


	})
			
						
		</script>

<div class="wrapper">
      
      

      <?php require "views/directivos/menu_vertical.php" ?>      
      <?php require "views/directivos/header_directivo.php" ?>


      <div class="content-wrapper">

      
       <!-- Main content -->
        <section class="content"> 
        	<section class="content-header">
				<h1>
					Alta de Usuarios
				</h1>
				<ol class="breadcrumb">
            		<li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
            		<li><a href="#">Alta de Usuarios</a></li>
          		</ol>
			</section>

			<div id="" class="">

			<form action="index.php?command=alta_directivo" method="POST" enctype="multipart/form-data"  role="form" id="form-alta" >
				<br />
					<div class="box box-primary">
						<div class="box-header"><h4>Datos generales</h4></div>
						<div class="box-body">						
							<div class="col-md-10 col-sm-10 col-xs-7">	
								<div class="form-group row">
									<label class="col-md-2 col-sm-2 col-xs-12">Usuario:*</label>
									<div class="col-md-5 col-sm-8 col-xs-12">
										<div class="input-group">
											<span class="input-group-addon">@</span>
											<input name="usuario" id="usuario"  placeholder="Usuario" class="form-control">
										</div>
									</div>
								</div>

								<div class="form-group row">					
									<label class="col-md-2 col-sm-2 col-xs-12" >Contrase&ntilde;a:*</label>
									<div class="col-md-5 col-sm-8 col-xs-12">
										<div class="input-group">
											<span class="input-group-addon"><i class="fa fa-key"></i></span>
											<input name="contrasena" id="contrasena" class="form-control" placeholder="Contrase&ntilde;a">
										</div>							
									</div>
								</div>

								<div class="form-group row">	
									<label class="col-md-2 col-sm-2 col-xs-12">Permiso*</label>	
									<div class="col-md-5 col-sm-8 col-xs-12">
										<select name="permiso" id="permiso" class="form-control">
											<option value="0">Selecciona...</option>
											<option value="1">Directivo</option>
											<option value="2">Auditor</option>
											<option value="3">Promotor</option>
										</select>
									</div>
								</div>

								<div class="form-group row">
									<label class="col-md-2 col-sm-2 col-xs-12">Tel. Casa</label>
									<div class="col-md-5 col-sm-8 col-xs-12">
										<div class="input-group">
											<span class="input-group-addon"><i class="fa fa-phone"></i></span>	
											<input type="text" class="form-control" name="telefono-local" id="telefono-local" data-inputmask="'mask': '99 9999-9999'" data-mask>
										</div>
									</div>
								</div>
								<div class="form-group row">									
									<label class="col-md-2 col-sm-2 col-xs-12">Tel. Celular</label>
									<div class="col-md-5 col-sm-8 col-xs-12">
										<div class="input-group">
											<span class="input-group-addon"><i class="fa fa-mobile-phone"></i></span>
											<input type="text" class="form-control" name="telefono-celular" id="telefono-celular" data-inputmask="'mask': '99 9999-9999'" data-mask>
										</div>
									</div>
								</div>
								<div class="form-group row">
									<label class="col-md-2 col-sm-2 col-xs-12">Correo(s)</label>
									<div class="col-md-5 col-sm-8 col-xs-12">
										<div class="input-group">
											<span class="input-group-addon"><i class="fa fa-envelope"></i></span>
											<input type="text" class="form-control" name="correo" id="correo">
										</div>		
									</div>							
								</div>

								<div class="form-group row">									
									<label class="col-md-2 col-sm-2 col-xs-12">No. de seguridad social</label>
									<div class="col-md-5 col-sm-8 col-xs-12">
										<div class="input-group">
											<span class="input-group-addon"><i class="fa fa-plus"></i></span>
											<input type="text" class="form-control" name="no_seguro_social" id="no_seguro_social">
										</div>
									</div>
								</div>
								<div class="form-group row">
									<label class="col-md-2 col-sm-2 col-xs-12">No. de cuenta</label>
									<div class="col-md-5 col-sm-8 col-xs-12">
										<div class="input-group">
											<span class="input-group-addon"><i class="fa fa-credit-card"></i></span>
											<input type="text" class="form-control" name="no_cuenta" id="no_cuenta">
										</div>		
									</div>							
								</div>
								<div class="form-group row">
									<label class="col-md-2 col-sm-2 col-xs-12">Usuario activo</label>
									<div class="col-md-5 col-sm-8 col-xs-12">
										<input type="checkbox" class="minimal" name="usuario_activo" id="usuario_activo">
									</div>							
								</div>
							</div>

							<div class="col-md-2 col-sm-2 col-xs-5">
								<div id="marco-foto">
									<div class="label" style=""> Foto:</div>

									<div id="cont-image_preview"><img src="" id="foto_preview"/></div>
									<button class="btn btn-block btn-primary" id="btnClearFoto">Borrar foto</button>
									<div class="">
										<input name="Foto1" id="image-file" type="file" class="" >
									</div>
								</div>
							</div>
						</div>
					</div>

			
						
					
					<div class="box box-primary">
						<div class="box-header"><h4>Nombre</h4></div>
						<div class="box-body">
							<div class="col-md-12 col-sm-12 col-xs-12">
								<div class="form-group row">	
									<label class="col-md-2 col-sm-2 col-xs-12">Apellido Paterno</label>
									<div class="col-md-5 col-sm-8 col-xs-12">
										<input class="form-control" name="apellido-paterno" placeholder="Apellido Paterno" type="campo">
									</div>					
								</div>
	 							<div class="form-group row">	
			 						<label class="col-md-2 col-sm-2 col-xs-12">Apellido Materno</label>
			 						<div class="col-md-5 col-sm-8 col-xs-12">
		 								<input class="form-control" name="apellido-materno" placeholder="Apellido Materno" type="campo">							
		 							</div>
								</div>
								<div class="form-group row">	
									<label class="col-md-2 col-sm-2 col-xs-12">Nombre(s)</label>
									<div class="col-md-5 col-sm-8 col-xs-12">
										<div class="input-group">
											<span class="input-group-addon"><i class="fa fa-user"></i></span>
											<input class="form-control" name="nombre" placeholder="Nombre" type="campo">
										</div>
									</div>							
								</div>
							</div>
						</div>
					</div>
					
					<div class="box box-primary">
						<div class="box-header"><h4>Dirección actual</h4></div>
						<div class="box-body">
							<div class="col-md-12 col-sm-12 col-xs-12">
								<div class="form-group row">
									<label class="col-md-2 col-sm-2 col-xs-12">Calle, Número</label>
									<div class="col-md-5 col-sm-8 col-xs-12">
										<div class="input-group">
											<span class="input-group-addon"><i class="fa fa-map-marker"></i></span>
											<input class="form-control" name="direccion" placeholder="Dirección" type="campo">
										</div>
									</div>
								</div>
								<div class="form-group row">
									<label class="col-md-2 col-sm-2 col-xs-12" style="">Estado:</label>	
									<div class="col-md-5 col-sm-8 col-xs-12">								
										<select name="estado" id="estado" class="form-control">
				 							<option value="0">Selecciona...</option>
											<?php
											global $obj_db;
                        					$consulta2 = "SELECT id_estado, nombre FROM estados ORDER BY nombre ASC";
                        					$result2 = $obj_db->consulta($consulta2);
                       						if($result2!=false){
				                         		foreach($result2 as $fila2){
                         							echo "<option value ='".$fila2['id_estado']."'>".utf8_encode($fila2['nombre'])."</option>";
                          						}
                        					}
                       						?>
										</select>
									</div>							
								</div>
								<div class="form-group row">
									<label class="col-md-2 col-sm-2 col-xs-12" style="">Municipio:</label>
									<div class="col-md-5 col-sm-8 col-xs-12">
										<select name="municipio" id="municipio" class="form-control">
											<option value="0">Selecciona...</option>
										</select>
									</div>
								</div>
							</div>
						</div>
					</div>
					
					<div class="box box-primary">
						<div class="box-header"><h4>Otros</h4></div>
						<div class="box-body">
							<div class="col-md-12 col-sm-12 col-xs-12">
								<div class="form-group row">
									<div class="col-md-6 col-sm-6" >										
										<label class="col-md-4 col-sm-4 col-xs-12">Fecha de Nacimiento</label>
										<div class="col-md-8 col-sm-8 col-xs-12">
											<div class="input-group">
												<span class="input-group-addon"><i class="fa fa-calendar"></i></span>
												<input class="form-control" name="f-nacimiento" placeholder="Fecha de Nacimento" type="campo" data-inputmask="'alias': 'dd/mm/yyyy'" data-mask>
											</div>
										</div>
									</div>
									<div class="col-md-6 col-sm-6">
										<label class="col-md-4 col-sm-4 col-xs-2">Lugar de Nacimiento</label>
										<div class="col-md-8 col-sm-8 col-xs-12">
											<div class="input-group">
												<span class="input-group-addon"><i class="fa fa-dot-circle-o"></i></span>
												<input class="form-control" name="l-nacimiento" placeholder="Lugar de Nacimento" type="campo">
											</div>
										</div>
									</div>
									
								</div>
								<div class="form-group row">
								
								
								</div>
								<div class="form-group row">
									<div class="col-md-6 col-sm-6" >
										<label class="col-md-4 col-sm-4 col-xs-2">Nacionalidad</label>
										<div class="col-md-8 col-sm-8 col-xs-12">
											<div class="input-group">
												<span class="input-group-addon"><i class="fa fa-map-marker"></i></span>
												<input class="form-control" name="nacionalidad" placeholder="Nacionalidad" type="campo">
											</div>
										</div>
									</div>
									<div class="col-md-6 col-sm-6" >
										<label class="col-md-4 col-sm-4 col-xs-2">Genero </label>
										<div class="col-md-8 col-sm-8 col-xs-12">
											<label class="radio-inline"><input type="radio" name="sex" value="1" checked class="minimal">Hombre</label>
											<label class="radio-inline"><input type="radio" name="sex" value="2" class="minimal">Mujer</label>
										</div>
									</div>
								</div>
								
								<div class="box-header"><h4>Encaso de emergencia llamar a: </h4></div>
								<div class="form-group row">	
									<div class="col-md-7 col-sm-7" >		
										<label class="col-md-3 col-sm-4 col-xs-2">Nombre </label>
										<div class="col-md-8 col-sm-8 col-xs-12">
											<div class="input-group">
												<span class="input-group-addon"><i class="fa fa-user"></i></span>		
												<input class="form-control" name="nombre-emergencia1" placeholder="Nombre" type="campo">
											</div>
										</div>
									</div>
									<div class="col-md-5 col-sm-5">
										<label class="col-md-3 col-sm-4 col-xs-2">Teléfono: </label>
										<div class="col-md-8 col-sm-8 col-xs-12">
											<div class="input-group">
												<span class="input-group-addon"><i class="fa fa-phone"></i></span>	
												<input class="form-control" name="numero-emergencia1" placeholder="Número" type="campo">
											</div>
										</div>
									</div>
								
								</div>
							
								<div class="form-group row">
									<div class="col-md-7 col-sm-7" >
										<label class="col-md-3 col-sm-4 col-xs-2">Nombre </label>
										<div class="col-md-8 col-sm-8 col-xs-12">
											<div class="input-group">
												<span class="input-group-addon"><i class="fa fa-user"></i></span>	
												<input class="form-control" name="nombre-emergencia2" placeholder="Nombre" type="campo">
											</div>
										</div>
									</div>
									<div class="col-md-5 col-sm-5" >
										<label class="col-md-3 col-sm-4 col-xs-2">Teléfono: </label>
										<div class="col-md-8 col-sm-8 col-xs-12">
											<div class="input-group">
												<span class="input-group-addon"><i class="fa fa-phone"></i></span>		
												<input class="form-control" name="numero-emergencia2" placeholder="Número" type="campo">
											</div>
										</div>
									</div>
								</div>	
								<div class="form-group row">
									<div class="col-md-7 col-sm-7" >
										<label class="col-md-3 col-sm-4 col-xs-2">Comentarios: </label>
										<div class="col-md-8 col-sm-8 col-xs-12">
											<textarea class="form-control" name="anexo1" id="anexo1" placeholder="Anexo1" type="campo"></textarea>
										</div>
									</div>								
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
                    <div class="box box-primary">
                    	<div class="box-header"><h4>Extras</h4></div>
						<div class="box-body">
							<div class="col-md-12 col-sm-12 col-xs-12">
								<input id="form_ext" name="form_ext" type="hidden" value="true">
						<?php
		                    	foreach($result3 as $fila3){
		            	?>
                         	
                         			<div class="form-group row">
										<div class="col-md-6 col-sm-6" >
											<label class="col-md-4 col-sm-4 col-xs-2"><?php echo $fila3['f_label']?></label>
											<div class="col-md-8 col-sm-8 col-xs-12">
												<input class="form-control" id="<?php echo "form_ext_".$fila3['id_form']?>" name="<?php echo "form_ext_".$fila3['id_form']?>" placeholder="<?php echo $fila3['f_default']?>" type="campo">
											</div>
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
                    </div>

					<div class="box-footer">
						<button type="submit" value="Guardar" name="btn_alta" id="btn_alta" class="btn btn-primary">Guardar</button>
					</div>

					<br />
				
			</form>
			</div>
		</section>
		
		
	</div>
	<?php require "views/directivos/footer_directivo.php" ?>
</div>
<script type="text/javascript">
      $(function () {
        $("[data-mask]").inputmask();

        //iCheck for checkbox and radio inputs
        $('input[type="checkbox"].minimal, input[type="radio"].minimal').iCheck({
          checkboxClass: 'icheckbox_minimal-blue',
          radioClass: 'iradio_minimal-blue'
        });
      });
</script>
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
