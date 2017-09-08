<?php
require_once 'class/class.altaReporte.php';

if(isset($_SESSION['user']) && $_SESSION['permiso']=='directivo'){
?>

<body>


<style>
#image-file{
	display:none;
}

</style>	

<script>
$(function(){//Funciones para validar fotografía

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

	   can_mod_producto = function(){
			if (confirm("Si cancelas ahora no se guardarán los cambios, deseas salir?")){
				document.location.href="?command=perfil_producto";
			}
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
			var x2 = $("#producto").val();
			if (x1==''||x2=='0') {
				alert("No haz llenados los datos necesarios");
				return false;
			} else
				return true;
		});

	  	function get_perfil(val){
			var valores = r_datos({'get_perfil_producto':val})

			v_valores = JSON.parse(valores)
			if (val!='0'){
				$("#nombre-producto").val(v_valores[0]);
				$("#gama option[value="+ v_valores[1] +"]").attr("selected",true);
				$("#descripcion-producto").val(v_valores[2]);
				$("#precio-producto").val(v_valores[4]);

					if(v_valores[3]!=''){
						$("#foto_preview2").attr('src',"uploads/productos/"+v_valores[3]);
						$("#foto_preview").show();
						$('#btnClearFoto').show();
						$('#name_foto').val(v_valores[3]);
						//Anexo 2 Forms extras
						v_valores_f_ext = JSON.parse(v_valores[6])
							var z = v_valores_f_ext;
							for(var i in z) {
								console.log(i)
								f_cont='#'+i;
								$(f_cont).val(v_valores_f_ext[i]);
							}
					}else{
						$("#foto_preview2").attr('src',"images/no-image.jpg");
						$("#foto_preview").hide();
						$('#btnClearFoto').hide();
						$('#name_foto').val('');
						//Anexo 2 Forms extras
						v_valores_f_ext = JSON.parse(v_valores[6])
							var z = v_valores_f_ext;
							for(var i in z) {
								console.log(i)
								f_cont='#'+i;
								$(f_cont).val(v_valores_f_ext[i]);
							}
					}
			}
		}

		get_perfil(<?php echo isset($_POST['nombre-producto'])?$_POST['nombre-producto']:0; ?>)

	})

</script>

<div border="0" class="table-responsive">
	<?php require "views/directivos/menu_vertical.php" ?>

	<div id="contenido">
		<?php require "views/directivos/header_directivo.php" ?>		
		<div id="contenedor">

			<n3>Modificar Producto</h3>

				<div id="" class="cont-form col-md-10">

			<form action="index.php?command=modificar_producto" method="POST" enctype="multipart/form-data" style="width:100%" id="form-alta">
				

					<br />
					<div class="label-h">Datos del Producto</div>
					<div class="caja-campos row">
						<div class="col-md-12 col-sm-12 col-xs-12">
							<div class="row grid">
								<input type="hidden" id="id_producto" name="id_producto" value="<?php echo isset($_POST['nombre-producto'])?$_POST['nombre-producto']:0; ?>">
								<label class="label col-md-2 col-sm-2 col-xs-2" style="">Producto*</label>
								<input class="campo col-md-5 col-sm-8 col-xs-12" name="nombre-producto" id="nombre-producto" type="text" placeholder="Nombre del Producto">
							</div>

							<div class="row grid">	
								<div class="label col-md-2 col-sm-2 col-xs-2">Gama</div>					
								<select name="gama" id="gama" class="campo col-md-5 col-sm-8 col-xs-12">
									<option value="0">Selecciona...</option>
									<?php
									global $obj_db;
                        			$consulta = "SELECT id_categoria, nombre_categoria FROM categorias ORDER BY id_categoria ASC";
                        			$result = $obj_db->consulta($consulta);
                        			if($result!=false){
	                          			foreach($result as $fila){
                          					echo "<option class='text-danger text-center' value ='".$fila['id_categoria']."'>".$fila['nombre_categoria']."</option>";
                          				}
                        			}
                        			?>
								</select>								
							</div>

							<div class="row grid">
								<label class="label col-md-2 col-sm-2 col-xs-2" style="">Descripción</label>
								<input class="campo col-md-5 col-sm-8 col-xs-12" name="descripcion-producto" id="descripcion-producto" type="text" placeholder="Descripción del Producto">
							</div>

							<div class="row grid">
								<label class="label col-md-2 col-sm-2 col-xs-2" style="">Precio</label>
								<input class="campo col-md-5 col-sm-8 col-xs-12" name="precio-producto" id="precio-producto" type="text" placeholder="00,0">
							</div>
						</div>
	 											
					</div>



					<?php
						global $obj_db;
                    	$consulta3 = "SELECT id_form, f_alias, f_label, f_default FROM form_extra WHERE id_seccion=3 ORDER BY f_alias ASC";
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
										<input class="campo col-md-8 col-sm-8 col-xs-12" id="<?php echo "form_ext_".$fila3['id_form']?>" name="<?php echo "form_ext_".$fila3['id_form']?>" placeholder="<?php echo $fila3['f_default']?>" type="campo">
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
					
					

					<div class="label-h">Cargar foto</div>
					<div class="caja-campos row">
						<div class="row grid">
							<label class="label col-md-2 col-sm-2 col-xs-2 col-md-offset-3 col-sm-offset-3 col-xs-offset-3" style="">Foto CAC:*</label>
						</div>
						<div class="row grid">
							<div id="marco-foto2" class="col-md-8 col-sm-6 col-xs-12 col-md-offset-3 col-sm-offset-2">
								<div  id="cont-image_preview2" class=""><img src="" id="foto_preview2" /></div>
								<input name="Foto1" id="image-file" type="file" class="" >
								<input type="hidden" id="name_foto" name="name_foto">							
							</div>	
						</div>
						<div class="row grid">
							<div class="btn col-md-2 col-sm-offset-3" id="btnClearFoto">Borrar foto</div>
						</div>
					</div>	

					<hr>


					<div class="">
						<input type="submit" value="Guardar" name="btn_enviar_modificar_producto" class="btn btn-block btn-sm btn-info">
						<input type="button" value="Cancelar" name="btn_cancelar_modificar_directivo" class="btn btn-block btn-sm btn-info" onClick="can_mod_producto()"> 
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
else if($_SESSION['permiso']!='directivo'){
?>
<script>
alert("tu no tienes permiso para ver este contenido");
document.location.href="index.php?command=home";
</script>
<?php
}
?>