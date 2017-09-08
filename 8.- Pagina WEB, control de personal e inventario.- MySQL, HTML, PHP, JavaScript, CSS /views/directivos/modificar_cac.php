<?php
require_once 'class/class.altaReporte.php';

if(isset($_SESSION['user']) && $_SESSION['permiso']=='directivo'){
?>

  <body class="skin-blue sidebar-mini">

<style>
#image-file{
	display:none;
}

</style>	

<script>
$(function(){//Funciones para validar fotografía


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


	  //Oculta contenedor	
	    contenedor = $('#foto_preview'); 
		contenedor.hide();	
		 
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
		

	   can_mod_cac = function(){
			if (confirm("Si cancelas ahora no se guardarán los cambios, deseas salir?")){
				document.location.href="?command=perfil_cac";
			}
		}
		
	   function get_municipios(estado){
			var valoresm = r_datos({'get_estados':estado})
			//console.log(valores[0].replace("",""));

			m_valores = JSON.parse(valoresm)
			if ($("#estado").val()!='0'){$("#municipio").html(m_valores[0])}
	   }

      $('#image-file').on('change', function() {
		  size=valida_tamano(this);
		  extension=valida_extension(this)
		  console.log(valida_extension(this));
		  if (size<2&&extension==true){
			readURL(this);
			$('#btnClearFoto').show();
			$('#name_foto').val('');
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
			var x2 = $("#nombre-cac").val();
			var x3 = $("#estado").val();
			var x4 = $("#municipio").val();
			if (x2==''||x3=='0') {
				alert("No haz llenados los datos necesarios");
				return false;
			} else
				return true;
		});



		//Recuperar estados
		$("#estado").on('change',function(){
			get_municipios($("#estado").val());
		})


		 function get_perfil(val){
			var valores = r_datos({'get_perfil_cac':val})

			v_valores = JSON.parse(valores)
			if (val!='0'){
				$("#nombre-cac").val(v_valores[7]);
				$("#direccion-cac").val(v_valores[0]);
				$("#estado option[value="+ v_valores[5] +"]").attr("selected",true);
				get_municipios(v_valores[5]);
				$("#municipio option[value="+ v_valores[6] +"]").attr("selected",true);
				$("#telefono-cac").val(v_valores[3]);
				console.log(v_valores[0])

					if(v_valores[4]!=''){
						$("#foto_preview2").attr('src',"uploads/cacs/"+v_valores[4]);
						$("#foto_preview").show();
						$('#btnClearFoto').show();
						$('#name_foto').val(v_valores[4]);
						//Anexo 2 Forms extras
							console.log(v_valores[8]);

							v_valores_f_ext = (v_valores[8]!='') ? JSON.parse( v_valores[8] ) : '';
							var z = v_valores_f_ext;
								for(var i in z) {
									console.log(i)
									f_cont='#'+i;
									$(f_cont).val(v_valores_f_ext[i]);
								}
						$('#tienda_activa').prop('checked',v_valores[9]==0 ? true : false);
					}else{
						$("#foto_preview2").attr('src',"images/no-image.jpg");
						$("#foto_preview").hide();
						$('#btnClearFoto').hide();
						$('#name_foto').val('');
						//Anexo 2 Forms extras
						v_valores_f_ext = JSON.parse(v_valores[8])
						var z = v_valores_f_ext;
							for(var i in z) {
								console.log(i)
								f_cont='#'+i;
								$(f_cont).val(v_valores_f_ext[i]);
							}
						$('#tienda_activa').prop('checked', false);
					}
			}
		}

		get_perfil(<?php echo isset($_POST['cac'])?$_POST['cac']:0; ?>);

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
					Modificar de Tienda
				</h1>
				<ol class="breadcrumb">
            		<li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
            		<li><a href="#">Modificar Tienda</a></li>
          		</ol>
			</section>


			<div id="" class="">

		
				<form action="index.php?command=modificar_cac" method="POST" enctype="multipart/form-data" style="width:100%" id="form-alta">
				
					<br />
					<div class="box box-primary">
						<div class="box-header"><h4>Datos de la Tienda</h4></div>
						<div class="box-body">
							<div class="col-md-12 col-sm-12 col-xs-12">
								<div class="form-group row">
									<input type="hidden" id="id_cac" name="id_cac" value="<?php echo isset($_POST['cac'])?$_POST['cac']:0; ?>">
									<label class="col-md-2 col-sm-2 col-xs-12" style="">Tienda*</label>
									<div class="col-md-5 col-sm-8 col-xs-12">
										<div class="input-group">
											<span class="input-group-addon"><i class="fa fa-shopping-cart"></i></span>
											<input class="form-control" name="nombre-cac" id="nombre-cac" type="text" placeholder="Nombre del CAC">
										</div>
									</div>									
								</div>

								<div class="form-group row">
									<label class="col-md-2 col-sm-2 col-xs-12" style="">Direccion</label>
									<div class="col-md-5 col-sm-8 col-xs-12">
										<div class="input-group">
											<span class="input-group-addon"><i class="fa fa-map-marker"></i></span>
											<input class="form-control" name="direccion-cac" id="direccion-cac" type="text" placeholder="Calle, No., C.P.">
										</div>
									</div>									
								</div>

								<div class="form-group row">
									<label class="col-md-2 col-sm-2 col-xs-12" style="">Estado:*</label>
									<div class="col-md-5 col-sm-8 col-xs-12">
										<select class="form-control" name="estado" id="estado">
			 								<option value="0">Selecciona...</option>
											<?php
											//global $obj_db;
                        					$consulta2 = "SELECT id_estado, nombre FROM estados ORDER BY nombre ASC";
                        					$result2 = $obj_db->consulta($consulta2);
                        					if($result2!=false){
			                          			foreach($result2 as $fila2){
                          							echo "<option class='text-danger text-center' value ='".$fila2['id_estado']."'>".utf8_encode($fila2['nombre'])."</option>";
                          						}
                        					}
                        					?>
										</select>
									</div>									
								</div>

								<div class="form-group row">
									<label class="col-md-2 col-sm-2 col-xs-12" style="">Municipio:*</label>
									<div class="col-md-5 col-sm-8 col-xs-12">
										<select class="form-control" name="municipio" id="municipio" class="">
											<option value="0">Selecciona...</option>
										</select>
									</div>									
								</div>

								<div class="form-group row">
									<label class="col-md-2 col-sm-2 col-xs-12" style="">Telefono (s)</label>
									<div class="col-md-5 col-sm-8 col-xs-12">
										<div class="input-group">
											<span class="input-group-addon"><i class="fa fa-phone"></i></span>
											<input class="form-control" name="telefono-cac" id="telefono-cac" type="text" placeholder="Tel-1, Tel-2...">
										</div>
									</div>
								</div>

								<div class="form-group row">
									<label class="col-md-2 col-sm-2 col-xs-12" style="">Tienda activa</label>
									<div class="col-md-5 col-sm-8 col-xs-12">
										<input type="checkbox" name="tienda_activa" id="tienda_activa" class="minimal" >
									</div>
								</div>

		 					</div>				
						</div>
					</div>


					<?php
						global $obj_db;
                    	$consulta3 = "SELECT id_form, f_alias, f_label, f_tipo, f_default FROM form_extra WHERE id_seccion=2 ORDER BY f_alias ASC";
                        $result3 = $obj_db->consulta($consulta3);
                       	if($result3!=false){
                    ?>
                    <div class="box box-primary">
						<div class="box-header"><h4>Extras</h4></div>
						<div class="caja-campos row">
							<div class="col-md-12 col-sm-12 col-xs-12">
								<input id="form_ext" name="form_ext" type="hidden" value="true">
						<?php
		                    	foreach($result3 as $fila3){
			                    	if ($fila3['f_tipo']!=2){
		            	?>
                         		
	                         		<div class="form-group row">
										<label class="col-md-2 col-sm-4 col-xs-12"><?php echo $fila3['f_label']?></label>
										<div class="col-md-5 col-sm-8 col-xs-12">
											<input class="form-control" id="<?php echo "form_ext_".$fila3['id_form']?>" name="<?php echo "form_ext_".$fila3['id_form']?>" placeholder="<?php echo $fila3['f_default']?>" type="campo">
										</div>
									</div>	
                   		<?php
                   					}
                   					else{
                   		?>	
                   					
                   					<div class="form-group row">
										<label class="col-md-2 col-sm-4 col-xs-12"><?php echo $fila3['f_label']?></label>
										<div class="col-md-5 col-sm-8 col-xs-12">
											<select class="form-control" id="<?php echo "form_ext_".$fila3['id_form']?>" name="<?php echo "form_ext_".$fila3['id_form']?>" type="campo">
												<?php 
													$a_opciones = explode(',', $fila3['f_default']);
													foreach ($a_opciones as $value) {
												?>
													<option><?php echo $value?></option>
												<?php
													}
												?>
											</select>
										</div>
									</div>
                   	
	                   	<?php				
                   					}
                   				}
                    	?>
	                   		</div>
						</div>
                   		<?php		
	                   	   	}
                    	?>
					</div>
					

					<div class="box box-primary">
						<div class="box-header"><h4>Cargar foto</h4></div>
						<div class="caja-campos row">
							<div class="col-md-12 col-sm-12 col-xs-12">
								<label class="col-md-2 col-sm-2 col-xs-2 col-md-offset-3 col-sm-offset-3 col-xs-offset-3" style="">Foto de Tienda:</label>
							</div>
							<div class="form-group row">
								<div id="marco-foto2" class="col-md-7 col-sm-6 col-xs-12 col-md-offset-3 col-sm-offset-2">
									<div  id="cont-image_preview2" class=""><img src="" id="foto_preview2" /></div>
									<input name="Foto1" id="image-file" type="file" class="" >		
									<input type="hidden" id="name_foto" name="name_foto">					
								</div>	
							</div>
							<div class="form-group row">
								<button class="btn btn-primary" id="btnClearFoto">Borrar foto</button>
							</div>
						</div>
					</div>


					<div class="">
						<button type="submit" value="Guardar" name="btn_enviar_modificar_cac" class="btn btn-primary">Guardar</button>
						<button type="button" value="Cancelar" name="btn_cancelar_modificar_directivo" class="btn btn-primary" onClick="can_mod_cac()">Cancelar</button>
					</div>

					<br />
				

				</form>
			</div>
		</section>
	</div>
		<?php require "views/directivos/footer_directivo.php"; ?>
</div>

	<script>
		$(function(){

			//iCheck for checkbox and radio inputs
	        $('input[type="checkbox"].minimal, input[type="radio"].minimal').iCheck({
	          checkboxClass: 'icheckbox_minimal-blue',
	          radioClass: 'iradio_minimal-blue'
	        });

		})
	</script>

</body>
<?php
}
else if($_SESSION['permiso']!='directivo'){
?>
<script>
alert("tu no tienes permiso para ver este contenido");
document.location.href="index.php?command=home";
</script>
<?php
}
?>