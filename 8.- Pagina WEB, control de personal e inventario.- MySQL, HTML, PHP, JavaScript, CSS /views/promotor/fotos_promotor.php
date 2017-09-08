<?php
require_once 'class/class.altaReporte.php';

if(isset($_SESSION['user']) && $_SESSION['permiso']=='promotor'){
?>

<body class="skin-blue sidebar-mini">

<style>
#image-file{
	display:none;
}

</style>	

<script>
$(function(){//Funciones para validar fotografía
	  	
		 
	  //Preview Imagen
	  function readURL(input) {
		contenedor = $('#foto_preview2');  
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
   		var arr_aux = control_input.value.split('.') 
   		var ext = arr_aux[control_input.value.split('.').length-1]

    	//var ext = control_input.value.match(/\.(jpg)$|\.(jpge)$|\.(png)$|\.(gif)$/)[1].toLowerCase();
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
			limpiar_input($('#image-file'),$('#foto_preview2'))   
		  	if(extension==false){mensajes_error(2);}
			else{ 
				if(size>2){mensajes_error(1);}
			}
		  }
	  });

      $('#cont-image_preview2').click(function(){
      	$('#image-file').click();
      })

      $('#btnClearFoto').hide();

      $('#btnClearFoto').click(function(){
      	limpiar_input($('#image-file'),$('#foto_preview2'));
      	$('#btnClearFoto').hide();
      });

		//Validar los campos obligatorios
		 $("#form-alta").submit(function() {
			var x1 = $("#foto_preview2").attr('src');
			var x2 = $("#cac").val();
			if (x1==''||x2=='0') {
				alert("No haz llenados los datos necesarios");
				return false;
			} else
				return true;
		});


	})

</script>

    <!-- Site wrapper -->
    <div class="wrapper">

      	<?php require "views/promotor/header_promotor.php"; ?>
      	<?php require "views/promotor/menu_vertical.php"; ?>
        <!-- Content Wrapper. Contains page content -->
      	<div class="content-wrapper">


			<section class="content-header">
          		<h1>
		            Alta de Fotos
            		<small>Fotos</small>
          		</h1>
          		<ol class="breadcrumb">
		            <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
            		<li><a href="#">Fotos</a></li>
          		</ol>
       		</section>


			<section id="" class="container">

			<?php	
				$consulta = "SELECT id_usuario, user_name, user_nombre, apellido_paterno, user_estado, user_foto, user_municipio FROM usuario WHERE id_usuario=".$_SESSION['user_id']." LIMIT 1";
				$result = $obj_db->consulta($consulta);
		    	if($result!=false){
	            	foreach($result as $fila){
        	?>
				<form action="index.php?command=reportes_promotor" method="POST" enctype="multipart/form-data" id="form-alta" role="form">
				
					<br />
					<div class="box box-primary">
						<div class="box-header"><h4>Datos de la tienda</h4></div>
						<div class="box-body">							
							<div class="col-md-10 col-sm-10 col-xs-7">
								<div class="form-group row">
									<label class="col-md-2 col-sm-2 col-xs-2" style="">Nombre</label>
									<div class="col-md-5 col-sm-8 col-xs-12">
										<div class="input-group">
											<span class="input-group-addon"><i class="fa fa-user"></i></span>
											<div class="form-control"><?php echo $fila['user_nombre']." ".$fila['apellido_paterno']; ?></div>
										</div>
									</div>
								</div>

								<div class="form-group row">
									<label class="col-md-2 col-sm-2 col-xs-2">Estado</label>
									<div class="col-md-5 col-sm-8 col-xs-12">
										<div class="input-group">
											<span class="input-group-addon"><i class="fa fa-map-marker"></i></span>
											<div id="cont-estado" class="form-control">No disponible</div>
										</div>
									</div>
	 							</div>
		 					
								<div class="form-group row">
									<label class="col-md-2 col-sm-2 col-xs-2" style="">Tienda*</label>
									<div class="col-md-5 col-sm-8 col-xs-12">
										<div class="input-group">
											<span class="input-group-addon"><i class="fa fa-shopping-cart"></i></span>
	 										<select name="cac" id="cac" class="form-control">	 								
			 									<option value="0">Selecciona...</option>
												<?php
												global $obj_db;
                        						$consulta2 = "SELECT id_cac, cac_name FROM cac ORDER BY cac_name ASC";
                        						$result2 = $obj_db->consulta($consulta2);
                        						if($result2!=false){
		                          					foreach($result2 as $fila2){
                          								echo "<option class='text-danger text-center' value ='".$fila2['id_cac']."'>".$fila2['cac_name']."</option>";
                          							}  
                          						}                      			
                        						?>
											</select>
										</div>
									</div>									
								</div>
	                            
                            	<div class="form-group row">
									<label class="col-md-2 col-sm-2 col-xs-2" style="">Clasificación</label>
									<div class="col-md-5 col-sm-8 col-xs-12">
										<div class="input-group">
											<span class="input-group-addon"><i class="fa fa-filter"></i></span>
	 										<select name="id_fotos_clasificacion" id="foto_clasificacion" class="form-control">	 								
			 									<option value="0">Selecciona...</option>
												<?php
												global $obj_db;
                        						$consulta2 = "SELECT id_fotos_clasificacion, fotos_clasificacion_name FROM fotos_clasificacion ORDER BY fotos_clasificacion_name ASC";
                        						$result2 = $obj_db->consulta($consulta2);
                        						if($result2!=false){
		                          					foreach($result2 as $fila2){
                          								echo "<option class='text-danger text-center' value ='".$fila2['id_fotos_clasificacion']."'>".$fila2['fotos_clasificacion_name']."</option>";
                          							}  
                          						}                      			
                        						?>
											</select>
										</div>
									</div>
								</div>

								<div class="form-group row">
									<label class="col-md-2 col-sm-2 col-xs-2" style="">Fecha</label>
									<div class="col-md-5 col-sm-8 col-xs-12">
										<div class="input-group">
											<span class="input-group-addon"><i class="fa fa-calendar"></i></span>
											<div class="form-control"><?php echo date('Y/m/d'); ?></div>								
										</div>
									</div>
								</div>
								
								<div class="form-group row">
									<label class="col-md-2 col-sm-2 col-xs-2" style="">Hora</label>
									<div class="col-md-5 col-sm-8 col-xs-12">
										<div class="input-group">
											<span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
											<div class="form-control"><?php echo date('H:i:s'); ?></div>								
										</div>
									</div>
								</div>
							</div>

							<div class="col-md-2 col-sm-2 col-xs-5">						
								<div class="form-group row">
									<div id="marco-foto" style="top:0;">
										<label class="col-md-2 col-sm-2 col-xs-2" style="">Foto:</label>
										<div id="cont-image_preview" ><img src="uploads/usuarios/<?php echo $fila['user_foto']==''?'no-image.jpg':$fila['user_foto']; ?>" id="foto_preview"/></div>									
									</div>
								</div>
							</div>
						</div>
					</div>
					

					<div class="box box-primary">
						<div class="box-header"><h4>Cargar foto</h4></div>
						<div class="box-body">
							<div class="col-md-12 col-sm-12 col-xs-12">
								<div class="form-group row">
									<label class="col-md-2 col-sm-2 col-xs-2 col-md-offset-2 col-sm-offset-2 col-xs-offset-2" style="">Foto de la Tienda:*</label>
								</div>
								<div class="form-group row">
									<div id="marco-foto2" class="col-md-6 col-sm-6 col-xs-12 col-md-offset-2 col-sm-offset-3">
										<div  id="cont-image_preview2" class=""><img src="" id="foto_preview2" /></div>
										<input name="Foto1" id="image-file" type="file" class="" >
									</div>	
								</div>
								<div class="form-group row">
									<div class="btn btn-primary" id="btnClearFoto">Borrar foto</div>
								</div>
							</div>
						</div>		
					</div>
							<hr>

							<div class="">
								<button type="submit" value="Guardar" name="btn_enviar_foto_cac" class="btn btn-primary">Guardar</button>
								<button type="submit" value="Cancelar" name="btn_cancelar_foto_cac" class="btn btn-primary">Cancelar</button>
							</div>

					
							<br />


				</form>
				<?php
										}
									}
				?>	
			</section>
		</div>
		<?php require "views/promotor/footer_promotor.php" ?>
	</div>
</div>

</body>
<?php
}
else if($_SESSION['permiso']!='promotor'){
?>
<script>
alert("tu no tienes permiso para ver este contenido");
document.location.href="index.php?command=home";
</script>
<?php
}
?>